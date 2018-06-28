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

namespace HeritageGo.Controllers.api
{
    [RoutePrefix("api/Viewed")]
    public class ViewedController : ApiController
    {
        dbHeritagerEntities dbContext = null;
        
        public ViewedController()
        {
            // create instance of an object
            dbContext = new dbHeritagerEntities();
            //dbContext.Configuration.ProxyCreationEnabled = false;
        }

        [HttpPost]
        public HttpResponseMessage Viewed(ViewedPost id)
        {
            int result = 0;
            tbViewed c = new tbViewed();
            c.HerID = id.HerID;
            c.InforPlatform = id.InforPlatform;
            c.TimeViewed = DateTime.Now;
            c.UserLocation = System.Data.Entity.Spatial.DbGeography.PointFromText(id.UserLocation, System.Data.Entity.Spatial.DbGeography.DefaultCoordinateSystemId);
            c.UserName = id.UserName;
            c.Viewed = 1;
            dbContext.tbVieweds.Add(c);
            dbContext.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
