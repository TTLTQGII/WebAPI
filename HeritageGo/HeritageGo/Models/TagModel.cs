using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeritageGo.Models
{
    public class TagModel
    {
        public int TagID { get; set; }
        public Nullable<int> TagIDParent { get; set; }
        public string TagName { get; set; }
        public string TagDescription { get; set; }
    }

    public class TagModel_lang
    {
        public int TagID { get; set; }
        public Nullable<int> TagIDParent { get; set; }
        public string TagName { get; set; }
        public string TagDescription { get; set; }
    }
}