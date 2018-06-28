using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeritageGo.Models
{
    public class ViewedModel
    {
        public long ID { get; set; }
        public int Viewed { get; set; }
        public System.Data.Entity.Spatial.DbGeography UserLocation { get; set; }
        public string UserName { get; set; }
        public string InforPlatform { get; set; }
        public int HerID { get; set; }
        public Nullable<System.DateTime> TimeViewed { get; set; }
    }

    public partial class ViewedPost
    {
        public long ID { get; set; }
        public int HerID { get; set; }
        public string UserLocation { get; set; }
        public string UserName { get; set; }
        public string InforPlatform { get; set; }

        public int Viewed { get; set; }
        public DateTime TimeViewed { get; set; }
    }
}