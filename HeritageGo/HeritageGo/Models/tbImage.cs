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
    
    public partial class tbImage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbImage()
        {
            this.tbImages_lang = new HashSet<tbImages_lang>();
        }
    
        public int ID { get; set; }
        public Nullable<int> HerID { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsAvatar { get; set; }
    
        public virtual tbHeritagerInfor tbHeritagerInfor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbImages_lang> tbImages_lang { get; set; }
    }
}
