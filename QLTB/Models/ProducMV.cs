using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTB.Models
{
    public class ProducMV
    {
        public int IDTHIETBI { get; set; }
        public int IDNGUOIDUNG { get; set; }
        public int IDPHONGBAN { get; set; }
        public int IDLOAITHIETBI { get; set; }
        public string TENTHIETBI { get; set; }
        public string MOTA { get; set; }
        public string XUATXU { get; set; }
        public string CAUHINH { get; set; }
        public double SOIP { get; set; }
        public int SOLUONG { get; set; }
        public System.DateTime NHAYNHAP { get; set; }
        public double GIA { get; set; }
        public string GHICHU { get; set; }
    }
}