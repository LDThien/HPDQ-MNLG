using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_MNLG.Models
{
    public class PhysicalparametersValidation
    {
        public int IDVL { get; set; }
        public int thoiGianRaGang { get; set; }

        public int gianCach { get; set; }
        public int thoiGianRaXi { get; set; }

        public float tiLeTGGangXi { get; set; }
        public float doSauLoGang { get; set; }

        public float luongBunBit { get; set; }
        public float sanLuong { get; set; }
        public float nhietDoGang { get; set; }
        public float khoiLuong { get; set; }
        public int loaiGang { get; set; }
    }
}