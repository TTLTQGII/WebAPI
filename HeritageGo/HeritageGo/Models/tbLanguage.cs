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
    
    public partial class tbLanguage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbLanguage()
        {
            this.tbHeritagerInfor_lang = new HashSet<tbHeritagerInfor_lang>();
            this.tbImages_lang = new HashSet<tbImages_lang>();
            this.tbTag_lang = new HashSet<tbTag_lang>();
        }
    
        public string Langcode { get; set; }
        public string LangName { get; set; }
        public bool IsDefault { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHeritagerInfor_lang> tbHeritagerInfor_lang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbImages_lang> tbImages_lang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbTag_lang> tbTag_lang { get; set; }
    }
}
