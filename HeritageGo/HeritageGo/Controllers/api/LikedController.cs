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
    [RoutePrefix("api/Liked")]
    public class LikedController : ApiController
    {
        dbHeritagerEntities dbContext = null;
        public LikedController()
        {
            // create instance of an object
            dbContext = new dbHeritagerEntities();
            //dbContext.Configuration.ProxyCreationEnabled = false;
        }
        [Route("LikeID")]
        [HttpPost]
        public IHttpActionResult Liked(LikedPost id)
        {
            try
            {
                tbLiked c = new tbLiked();
                c.HerID = id.HerID;
                c.InforPlatform = id.InforPlatform;
                c.LikedTime = DateTime.Now;
                c.UserLocation = System.Data.Entity.Spatial.DbGeography.PointFromText($"Point({id.Longitude} {id.Latitude})", System.Data.Entity.Spatial.DbGeography.DefaultCoordinateSystemId);
                c.UserName = id.UserName;
                c.Liked = 1;
                dbContext.tbLikeds.Add(c);
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
