using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace HeritageGo.Models
{
    public class CommentaryModel
    {
    }

    public partial class tbCommentaryModelGet
    {
        public long ID { get; set; }
        public string UserName { get; set; }
        public string Contents { get; set; }
        public string PostTime { get; set; }
    }

    public partial class tbCommentaryModelPost
    {
        public int HerID { get; set; }
        public string UserName { get; set; }
        public string InforPlatform { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Contents { get; set; }

    }


    public class tbCommentaryModels
    {
        public List<tbCommentaryModelGet> pdata { get; set; }
    }
}