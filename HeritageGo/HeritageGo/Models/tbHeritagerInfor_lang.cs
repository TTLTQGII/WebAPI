//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HeritageGo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbHeritagerInfor_lang
    {
        public int ID { get; set; }
        public int HerID { get; set; }
        public string Langcode { get; set; }
        public string Name { get; set; }
        public string TimeofBuild { get; set; }
        public string Address { get; set; }
        public string Contents { get; set; }
        public string Description { get; set; }
    
        public virtual tbHeritagerInfor tbHeritagerInfor { get; set; }
        public virtual tbLanguage tbLanguage { get; set; }
    }
}
