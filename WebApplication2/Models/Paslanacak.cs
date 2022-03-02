using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Paslanacak
    {
        public string kitapadi { get; set; }
        public string kisiadi { get; set; }
        public string telefonno { get; set; }
        public string beklenenteslim { get; set; }
        public string gercekteslim { get; set; }
        public string cezamiktar { get; set; }

        public Paslanacak()
        {
            this.kitapadi = "";
            this.kisiadi = "";
            this.telefonno = "";
            this.beklenenteslim = "";
            this.gercekteslim = "";
            this.cezamiktar = "";
        }
    }
}