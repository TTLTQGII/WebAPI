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
    
    public partial class tbLiked
    {
        public long ID { get; set; }
        public int HerID { get; set; }
        public System.Data.Entity.Spatial.DbGeography UserLocation { get; set; }
        public string UserName { get; set; }
        public string InforPlatform { get; set; }
        public Nullable<int> Liked { get; set; }
        public Nullable<System.DateTime> LikedTime { get; set; }
    
        public virtual tbHeritagerInfor tbHeritagerInfor { get; set; }
    }
}