using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeritageGo.Models
{
    public class ImagesModel
    {
        public int ID { get; set; }
        public int HerID { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    }

    public class ImagesModel_lang
    {
        public int ID { get; set; }
        public int ImageID { get; set; }
        public string Langcode { get; set; }
        public string Description { get; set; }
    }


}