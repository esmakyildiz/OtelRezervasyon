//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Misafirler
    {
        public int MisafirId { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TcNo { get; set; }
        public string E_Mail { get; set; }
        public Nullable<int> OdaId { get; set; }
        public string TelefonNumarasi { get; set; }
        public string Mesaj { get; set; }
        public string Cinsiyet { get; set; }
    
        public virtual Oda Oda { get; set; }
    }
}