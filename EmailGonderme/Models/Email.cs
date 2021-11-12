using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailGonderme.Models
{
    public class Email
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}