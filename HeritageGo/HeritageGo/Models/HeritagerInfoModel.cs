using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SqlServer;
namespace HeritageGo.Models
{
    public class HeritagerInfoModel
    {
    }
    public partial class tbtbImageModel
    {
        public int ID { get; set; }
        public int HerID { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    }

    public partial class tbHeritagerInforModelPost
    {
        public List<tbtbImageModel> imagedata { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string TimeofBuild { get; set; }
        public string Address { get; set; }
        public string Contents { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public List<TagModel> tagdata { get; set; }
    }

    public partial class tbHeritagerInforModel
    {
        public List<tbtbImageModel> imagedata { get; set; }

        public int ID { get; set; }
        public string Name { get; set; }
        public string TimeofBuild { get; set; }
        
        public string Address { get; set; }
        public string Contents { get; set; }

        public string Description { get; set; }
        //public System.Data.Entity.Spatial.DbGeometry Location { get; set; }
        public string Notes { get; set; }
        public int? Liked { get;set; }

        public int? Viewed { get; set; }
        
        public int? Commented { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }

    public partial class tbHeritagerInforHomeModel
    {
        public string ImagePath { get; set; }

        public int ID { get; set; }
        public string Name { get; set; }
        public int? Liked { get; set; }

        public int? Viewed { get; set; }
    }
    public  class tbHeritagerInforHomeModels
    {
        //public List <LocationXY> userlocation { get; set; }
        public List<tbHeritagerInforHomeModel> pdata { get; set; }
    }
    public class tbHeritagerInforModels
    {
        public List<tbHeritagerInforModel> pdata { get; set; }
    }

    public class tbHerinTagModel
    {
        public int ID { get; set; }
        public int HerID { get; set; }
        public int TagID { get; set; }
    }

    public class MarkersModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }

    public partial class LocationXY
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}