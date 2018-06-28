using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HeritageGo.Models;
namespace HeritageGo.Controllers.api
{
    public class LanguageController : ApiController
    {
        dbHeritagerEntities dbContext = null;

        public LanguageController()
        {
            // create instance of an object
            dbContext = new dbHeritagerEntities();

            //dbContext.Configuration.ProxyCreationEnabled = false;
        }

        [Route("UpdateLang")]
        //[ResponseType(typeof(tbHeritagerInforHomeModels))]
        [HttpPost]
        public IHttpActionResult UpdateLang(LanguageModel par)
        {
            try
            {
                tbLanguage p = new tbLanguage();
                p.Langcode= par.Langcode;
                p.LangName= par.LangName;
                p.IsDefault= par.IsDefault;
                dbContext.tbLanguages.Add(p);
                dbContext.SaveChanges();
                return Ok(1);
            }
            catch
            {
                return Ok(1);
            }

        }
        [Route("DeleteLang")]
        [HttpDelete]
        public IHttpActionResult DeleteLang( int id)
        {
            try
            {
                var student = dbContext.tbHeritagerInfors.Where(x => x.ID == id).FirstOrDefault();
                dbContext.tbHeritagerInfors.Attach(student);
                dbContext.tbHeritagerInfors.Remove(student);
                dbContext.SaveChanges();
                return Ok(1);
            }
            catch
            {

                return Ok(0);
            }
        }
    }
}
