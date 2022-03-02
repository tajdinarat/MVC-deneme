using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.Entity;

namespace WebApplication2.Models
{
    public class MyViewModel
    {
        public TBLKITAPLAR tblkitaplar { get; set; }
        public TBLISLEMLER tblislemler { get; set; }
        public string kisininAdi { get; set; }

        public MyViewModel()
        {
            this.tblislemler = new TBLISLEMLER();
            this.tblkitaplar = new TBLKITAPLAR();
            this.kisininAdi = "";
        }
    }
}