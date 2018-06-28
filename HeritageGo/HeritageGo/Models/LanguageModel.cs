using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeritageGo.Models
{
    public class LanguageModel
    {
        public string Langcode { get; set; }
        public string LangName { get; set; }
        public bool IsDefault { get; set; }
    }
}