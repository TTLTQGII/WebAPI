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
    [RoutePrefix("api/Commentary")]
    public class CommentaryController : ApiController
    {
        int perPage = commonHeritageGo._itemsofpage;
        // // dbHeritagerEntities object point
        dbHeritagerEntities dbContext = null;
        public CommentaryController()
        {
            // create instance of an object
            dbContext = new dbHeritagerEntities();
            //dbContext.Configuration.ProxyCreationEnabled = false;
        }

        [Route("SaveComment")]
        [ResponseType(typeof(tbCommentary))]
        [HttpPost]
        public HttpResponseMessage SaveComment(tbCommentaryModelPost id)
        {
            int result = 0;
            try
            {

                tbCommentary c = new tbCommentary();
                c.HerID = id.HerID;
                c.Audited = 0;
                c.PostTime = DateTime.Now;
                c.InforPlatform = id.InforPlatform;
                c.UserLocation = System.Data.Entity.Spatial.DbGeography.PointFromText($"Point({id.Longitude} {id.Latitude})", System.Data.Entity.Spatial.DbGeography.DefaultCoordinateSystemId);

                c.UserName = id.UserName;
                c.Commented =1;
                c.Contents = id.Contents;
                dbContext.tbCommentaries.Add(c);
                dbContext.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


        [Route("GetCommentaryByHerID/{heritagerID:int}/{curpage:int}")]
        [HttpPost]
        public tbCommentaryModels GetCommentaryByID(int heritagerID,int curpage)
        {

            tbCommentaryModels Result = new tbCommentaryModels();
            int curPage = curpage;
            int nums = perPage * (curPage - 1);
            int nume = perPage;
            //List< tbHeritagerInforHomeModel > heri
            try
            {
                tbCommentary c = new tbCommentary();

                var vrs = dbContext.Database.SqlQuery<tbCommentaryModelGet>("GetCommentaryByID @ID, @nums, @nume",
                    new SqlParameter("@ID", heritagerID),
                    new SqlParameter("@nums", nums),
                    new SqlParameter("@nume", nume)).ToList();


                Result.pdata = vrs;

            }
            catch (Exception e)
            {
            }

            return Result;
        }


    }
}
