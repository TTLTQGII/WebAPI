using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HeritageGo.Models;
using System.Data.SqlClient;
using System.Data.Entity.Validation;

namespace HeritageGo.Controllers.api
{
    [RoutePrefix("api/Tags")]
    public class TagController : ApiController
    {
        // // dbHeritagerEntities object point
        dbHeritagerEntities dbContext = null;
        
        public TagController()
        {
            // create instance of an object
            dbContext = new dbHeritagerEntities();
            //dbContext.Configuration.ProxyCreationEnabled = false;
        }
        [Route("SaveTag")]
        //[ResponseType(typeof(tbHeritagerInforHomeModels))]
        [HttpPost]
        public IHttpActionResult UpdateTag(TagModel par)
        {
            try
            {
                if (!dbContext.tbTags.Where(x => x.TagName == par.TagName).Any())
                {
                    tbTag p = new tbTag();
                    p.TagIDParent = par.TagIDParent;
                    p.TagName = par.TagName;
                    p.TagDescription = par.TagDescription;
                    dbContext.tbTags.Add(p);
                    dbContext.SaveChanges();
                    return Ok(1);
                }
                return Ok(0);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("GetTag")]
        [HttpPost]
        public IHttpActionResult GetTag()
        {
            var gettag = from m in dbContext.tbTags
                         select m.TagName;
            return Ok(gettag);
        }
    }
}
