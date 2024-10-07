using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocDuLieuJson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Phương thức đọc tập tin JSON
        /// </summary>
        /// <param name="Path">Đường dẫn tập tin</param>
        /// <returns>Danh sách các đối tượng từ tập tin JSON</returns>
        private List<StudentInfo> LoadJSON(string Path)
        {
            // Khai báo danh sách lưu trữ
            List<StudentInfo> List = new List<StudentInfo>();
            // Đối tượng đọc tập tin
            StreamReader r = new StreamReader(Path);
            string json = r.ReadToEnd(); // Đọc hết
                                         // Chuyển về thành mảng các đối tượng
            var array = (JObject)JsonConvert.DeserializeObject(json);
            // Lấy đối tượng sinhvien
            var students = array["sinhvien"].Children();
            foreach (var item in students) // Duyệt mảng
            {
                // Lấy các thành phần
                string mssv = item["mssv"].Value<string>();
                string hoten = item["hoten"].Value<string>();
                int tuoi = item["tuoi"].Value<int>();
                double diem = item["diem"].Value<double>();
                bool tongiao = item["tongiao"].Value<bool>();
                // Chuyển vào đối tượng StudentInfo
                StudentInfo info = new StudentInfo(mssv, hoten, tuoi, diem,tongiao);
                List.Add(info);// Thêm vào danh sách
            }
            return List;
        }

        private void btnJSON_Click(object sender, EventArgs e)
        {
            string Str = ""; // chuỗi lưu trữ
            string Path = "C:\\Users\\ASUS\\source\\repos\\Lab05_DocDuLieu\\DocDuLieuJson\\JSONExample.json"; // Đường dẫn tập tin
            List<StudentInfo> list = LoadJSON(Path); // Gọi phương thức
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].TonGiao)
                    Str+= string.Format($"Student {i} có MSSV: {list[i].MSSV}, Họ tên: {list[i].Hoten}, điểm TB: {list[i].Diem} , Tôn giáo: Phật giáo\n");
                else
                    Str += string.Format($"Student {i} có MSSV: {list[i].MSSV}, Họ tên: {list[i].Hoten}, điểm TB: {list[i].Diem} , Tôn giáo: Công giáo\n");

            }
            MessageBox.Show(Str);
        }
    }
}
