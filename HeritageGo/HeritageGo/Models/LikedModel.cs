using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeritageGo.Models
{
    public class LikedModel
    {
        public long ID { get; set; }
        public int HerID { get; set; }
        public System.Data.Entity.Spatial.DbGeography UserLocation { get; set; }
        public string UserName { get; set; }
        public string InforPlatform { get; set; }
        public Nullable<int> Liked { get; set; }
        public Nullable<System.DateTime> LikedTime { get; set; }
    }

    public partial class LikedPost
    {
        public int HerID { get; set; }
        public string UserName { get; set; }
        public string InforPlatform { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}