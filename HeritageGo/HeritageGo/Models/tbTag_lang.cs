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
    
    public partial class tbTag_lang
    {
        public int ID { get; set; }
        public int TagID { get; set; }
        public string Langcode { get; set; }
        public string TagName { get; set; }
        public string TagDescription { get; set; }
    
        public virtual tbLanguage tbLanguage { get; set; }
        public virtual tbTag tbTag { get; set; }
    }
}
