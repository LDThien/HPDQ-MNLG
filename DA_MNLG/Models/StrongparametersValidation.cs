using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DA_MNLG.Models;
namespace DA_MNLG.Models
{
    public class StrongparametersValidation
    {
        public int IDM { get; set; }
        public DateTime thoiGian { get; set; }

        public int caID { get; set; }
        public string Tenca { get; set; }

        public int meGang { get; set; }
        public int soThung { get; set; }
        public int sanRaGang { get; set; }
        public DateTime? Begind { get; set; }

        //Ngày kết thúc
        public DateTime? Endd { get; set; }
    }
}