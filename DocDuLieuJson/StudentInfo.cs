using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocDuLieuJson
{
    internal class StudentInfo
    {

        // Phương thức tạo lập
        public StudentInfo(string mssv, string hoten, int tuoi, double
       diem, bool tongiao)
        {
            this.MSSV = mssv;
            this.Hoten = hoten;
            this.Tuoi = tuoi;
            this.Diem = diem;
            this.TonGiao = tongiao;
        }

        // Các thuộc tính
        public string MSSV { get; set; }
        public string Hoten { get; set; }
        public int Tuoi { get; set; }
        public double Diem { get; set; }
        public bool TonGiao { get; set; }
    }
}
