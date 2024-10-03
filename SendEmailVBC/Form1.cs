using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Reflection;
using System.IO;
using System.Windows.Controls;
using Microsoft.Win32;


namespace SendEmailVBC
{
    public partial class Form1 : Form
    {
        DataSet oDs = new DataSet();
        string tenTableThongtin = "thongtinSV";
        string tencot1 = "STT";
        string tencot2 = "Email-2";
        string tencot3 = "Họ và tên";
        string tencot4 = "Email";

        int soLuongNV, soCot, soDong;
        
        private bool isLoaded = false; // Cờ để theo dõi trạng thái form, liên quan đến SelectedIndexChanged cmbGV 

        DataView dataView;
        DataTable tblData;

        // Tạo một HashSet lưu các phần tử là stt các hàng bị trùng lịch
        HashSet<double> dsChuaLAB = new HashSet<double>();

        string[] subdirectories; // mảng một chiều lưu danh sách tên các thư mục

        private string GetColor(int index)
        {
            // Danh sách màu sắc  
            string[] colors = {
            "LightGreen"
        };
            return colors[index % colors.Length]; // Lặp lại màu sắc nếu vượt quá số màu
        }


        public Form1()
        {
            InitializeComponent();
        }

        public void XoaLuoiDuLieu()
        {
            oDs.Tables.Clear();
            oGrid.DataSource = null;
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void btnCheck_Click(object sender, EventArgs e)
        {
            dsChuaLAB.Clear(); // danh sách stt các dòng bị trùng lịch

            // Bước - lấy danh sách tất cả sinh viên từ datatable 
            /*
            var danhSach = oDs.Tables[tenTableThongtin]
           .AsEnumerable() // Chuyển đổi thành Enumerable
           .Select(row => new
               {
                   STT = row.Field<Double>(tencot1),
                   Email2 = row.Field<string>(tencot2),
                   HoTen = row.Field<string>(tencot3),
                   Email = row.Field<string>(tencot4),
                }).ToList(); // Chuyển đổi thành danh sách
            foreach (var sv in danhSach)
            {
               MessageBox.Show($"Tên: {sv.STT}, Điểm: {sv.Email2}");
            }
            */
            var danhSach = oDs.Tables[tenTableThongtin]
             .AsEnumerable() // Chuyển đổi thành Enumerable
             .Where(row => true).ToList();
            /* foreach (var row in danhSach)
                  MessageBox.Show($"Tên: {row.Field<double>(tencot1)}, Điểm: {row.Field<string>(tencot2)}");
            */
            string colorGV = GetColor(0); // lấy màu của GV thứ sttColor
            foreach (var row in danhSach)
            {
                // lấy địa chỉ email2
                double sttSV = row.Field<double>(tencot1);
                string dcEmail2 = row.Field<string>(tencot2);
                // kiểm tra có trong danh sách thư mục hay không, nếu có thì đã up bài, ngược lại thì chưa up
                // lấy số thứ tự trên lưới, để tô màu, nếu chưa up
                bool daUp = subdirectories.Any(item => item.IndexOf(dcEmail2, StringComparison.OrdinalIgnoreCase) >= 0);
                if (daUp)
                {
                }
                else
                {
                    ToMauGrid(sttSV, colorGV);
                    dsChuaLAB.Add(sttSV); // thêm vào danh sách chưa làm LAB
                }


            }

        }

        private void ToMauGrid(double sttDong,string colorGV)
        {
            foreach (DataGridViewRow row in oGrid.Rows)
            {
                // Kiểm tra xem giá trị trong cột STT có bằng targetSTT không
                if (row.Cells["STT"].Value != null && row.Cells["STT"].Value.ToString() == sttDong.ToString())
                {
                    // Tô màu nền đỏ cho dòng này
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.FromName(colorGV);
                    // Dừng vòng lặp ngay sau khi đã tô màu cho một dòng
                    break;
                }
            }
        }

      
        private void btExcel_Click(object sender, EventArgs e)
        {
            string ConnectionString;
            string tenFile;

            // /////////////// chon tap tin 
            OpenFileDialog1.Filter = "Tập tin Excel (*.xls;*.xlsx)|*.xls;*.xlsx";
            OpenFileDialog1.Title = " Chọn tập tin dữ liệu ";
            OpenFileDialog1.FileName = "";
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileDuLieu.Text = OpenFileDialog1.FileName;
            }
            else
            {
                return;
            }
            XoaLuoiDuLieu();
            tenFile = txtFileDuLieu.Text; // tenFile = Application.StartupPath & "\" & "dataExcel.xls"
                                          // Kiểm tra định dạng file
            if (tenFile.EndsWith(".xls")) // phương thức của lớp string,kiểm tra xem một chuỗi có kết thúc bằng một chuỗi khác hay không
            {
                ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + tenFile + ";Extended Properties='Excel 8.0;HDR=YES';";
            }
            else if (tenFile.EndsWith(".xlsx"))
            {
                ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + tenFile + ";Extended Properties='Excel 12.0 Xml;HDR=YES';";
            }
            else
            {
                throw new Exception("Định dạng file không hợp lệ. Chỉ hỗ trợ .xls và .xlsx.");
            }
            //////////////////////////////////////////////////////////
            using (OleDbConnection oCnn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    oCnn.Open();

                    // Lấy tên bảng đầu tiên
                    DataTable dtSchema = oCnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string firstSheetName = dtSchema.Rows[0]["TABLE_NAME"].ToString();
                    // Đọc dữ liệu từ bảng đầu tiên
                    string query = $"SELECT * FROM [{firstSheetName}]";
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, oCnn))
                    {
                        oDs.Clear();
                        adapter.Fill(oDs, tenTableThongtin);
                        tblData = oDs.Tables[tenTableThongtin];

                        dataView = new DataView(tblData);
                        oGrid.DataSource = dataView;  // Gán DataView làm nguồn dữ liệu cho GridView

                        soLuongNV = oGrid.RowCount - 1;  // không đếm dòng tiêu đề
                        txtSoLuongNV.Text = soLuongNV.ToString();
                        soCot = oGrid.Columns.Count; // chu y, cot sẽ bat dau tu 0
                        soDong = oGrid.Rows.Count - 1; // dong tren luoi luôn có 1 dòng empty bên dưới
                                                       //chu y, dong sẽ bat dau tu 0 (trong do cos 1 dong tieu de trong file Excel)
                                                       // có 1 dòng là bắt đầu từ 0 đến 0




                        // Định dạng hiển thị sau khi đã load dữ liệu cho lưới
                        oGrid.ScrollBars = ScrollBars.Both; // Hoặc ScrollBars.Vertical hoặc ScrollBars.Horizontal
                        oGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }







            //////////////////////////////////////////////////////////

            isLoaded = true; // Đặt cờ là true khi form đã tải xong, ogrid đã có dữ liệu

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra nếu phím nhấn là Esc
            if (e.KeyCode == Keys.Escape)
            {
                this.Close(); // Đóng form
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            dieuChinhKichThuocForm();
        }

        private void cmbGV_SelectedIndexChanged(object sender, EventArgs e)
        {
          
       
        }

        private void btnExpExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(oGrid);
        }


        private void ExportToExcel(DataGridView dataGridView)
        {
        }

        private void btnCheck2_Click(object sender, EventArgs e)
        { // duyệt và tô màu các dòng bị trùng dựa theo Stt 
            
        }


     
        private void XoaTrenGrid(double sttToRemove)
        {
            foreach (DataGridViewRow row in oGrid.Rows)
            {
                // Kiểm tra xem ô "STT" có giá trị bằng sttToRemove hay không
                if (row.Cells["STT"].Value != null && row.Cells["STT"].Value.ToString() == sttToRemove.ToString())
                {
                    // Xóa dòng
                    oGrid.Rows.Remove(row);
                    break; // Thoát khỏi vòng lặp sau khi xóa
                }
            }
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hiển thị FolderBrowserDialog
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn thư mục được chọn
                string selectedPath = folderBrowserDialog1.SelectedPath;

                // Lấy tên thư mục từ đường dẫn
                //string folderName = System.IO.Path.GetFileName(selectedPath);
                // Hiển thị tên thư mục trong TextBox
                //txtTenThuMuc.Text = folderName;
                txtTenThuMuc.Text = selectedPath;

                // Lấy tên tất cả các thư mục con cấp 1
                if (subdirectories != null)
                { 
                    Array.Clear(subdirectories, 0, subdirectories.Length); // xóa dữ liệu đã có
                }
                subdirectories = System.IO.Directory.GetDirectories(selectedPath);

                // Đếm tổng số thư mục con - có n thư mục con thì khả năng
                // đã có n sinh viên up bài
                int totalDirectories = subdirectories.Length;

                // duyệt kiểm tra từng sinh viên, có thư mục dữ liệu
                // điều kiện là các thư mục có tên khác nhau

                txtSLThuMuc.Text = totalDirectories.ToString();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // xóa các dòng không có trong hasset (các sinh viên đã up lab)
            RemoveRowsWithSTT(dsChuaLAB);
        }
            
        private void RemoveRowsWithSTT(HashSet<double> sttToKeepSet)
        {
            // Xóa các dòng từ dưới lên để tránh lỗi chỉ số
            for (int i = oGrid.Rows.Count - 1; i >= 0; i--)
            {
                // Lấy giá trị trong ô đầu tiên của dòng hiện tại
                double sttValue;
                if (double.TryParse(oGrid.Rows[i].Cells[0].Value?.ToString(), out sttValue))
                {
                    // Kiểm tra xem giá trị có nằm trong HashSet không
                    if (!sttToKeepSet.Contains(sttValue))
                    {
                        oGrid.Rows.RemoveAt(i); // Xóa dòng nếu số thứ tự nằm trong HashSet
                    }
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void dieuChinhKichThuocForm()
        {
            // Tính toán chiều cao và chiều rộng mới
            int newHeight = this.Height; // Chiều cao bằng chiều cao của form 
            int newWidth = this.Width; // Chiều rộng bằng chiều rộng của form

            // Cập nhật kích thước cho GridView
            oGrid.Height = newHeight-150;
            oGrid.Width = newWidth;

            // Đặt vị trí của DataGridView để đáy nằm sát đáy của form
            oGrid.Top = this.ClientSize.Height - oGrid.Height;  // Đặt vị trí trên cùng
        }

    }
}
