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
using System.Web;
namespace HeritageGo.Controllers.THINH.api
{
    // Route 
    [RoutePrefix("api/HeritagerInfor")]
    public class HeritagerInforController : ApiController
    {
        int perPage = commonHeritageGo._itemsofpage;
        // // dbHeritagerEntities object point
        dbHeritagerEntities dbContext = null;
        string currentURL = HttpContext.Current.Request.Url.Host;
        // Constructor 
        public HeritagerInforController()
        {
            // create instance of an object
            dbContext = new dbHeritagerEntities();
            //dbContext.Configuration.ProxyCreationEnabled = false;
        }
        [Route("GetMarkersList/{Lat}/{Long}")]
        [HttpPost]
        public IHttpActionResult MarkersList(string Lat,string Long)
        {
            Long=  HttpUtility.UrlDecode(Long);
            Lat = HttpUtility.UrlDecode(Lat);
            Long= Long.Replace(",", ".");
            Lat= Lat.Replace(",", ".");
            
            List<MarkersModel> Result = new List<MarkersModel>();
            Result = dbContext.Database.SqlQuery<MarkersModel>("GetListMarker 'POINT("+Long + " "+Lat + ")'").ToList();
            return Ok(Result);
        }

        [Route("GetHeritagerInfoByID/{heritagerID:min(1)}")]
        [HttpPost]
        public IHttpActionResult GetHeritagerInfoByID(int heritagerID)
        {
            tbHeritagerInforModels Result = new tbHeritagerInforModels();
            //List< tbHeritagerInforHomeModel > heri
            try
            {
                var imas = dbContext.Database.SqlQuery<tbtbImageModel>("GetImageHeritage").ToList();
                var vrs = dbContext.Database.SqlQuery<tbHeritagerInforModel>("GetHeritagerInfoID @ID",
                    new SqlParameter("@ID", heritagerID)).FirstOrDefault();

                if (vrs != null)
                //foreach (var i in vrs)
                {
                    var ims = (from ima in imas
                               where ima.HerID == vrs.ID
                               select new tbtbImageModel { ID = ima.ID, HerID = ima.HerID, ImagePath = currentURL + "/Image/" + ima.HerID + "/" + ima.ImagePath, Description = ima.Description });
                    vrs.imagedata = ims.ToList();

                }
                //Result.pdata = vrs;
                return Ok(vrs);
            }
            catch
            {
                return BadRequest();
            }

        }

        [Route("GetHeritagerInfoHomeLike/{curpage:min(1)}")]
        //[ResponseType(typeof(tbHeritagerInforHomeModels))]
        [HttpPost]
        public IHttpActionResult GetHeritagerInfoHomeLike(int curpage)
        {
            tbHeritagerInforHomeModels Result = new tbHeritagerInforHomeModels();
            int curPage = curpage;
            int nums = perPage * (curPage - 1);
            int nume = perPage;
            try
            {
                var imas = dbContext.Database.SqlQuery<tbImage>("select * from tbImages, tbHeritagerInfor where tbImages.HerID=tbHeritagerInfor.ID and tbImages.IsAvatar= 'true'").ToList();
                var vrs = dbContext.Database.SqlQuery<tbHeritagerInforHomeModel>("GetHeritagerInfolike @nums,@nume",
                    new SqlParameter("@nums", nums),
                    new SqlParameter("@nume", nume)).ToList();
                foreach (var i in vrs)
                {
                    i.ImagePath = currentURL + "/Image/" + i.ID + "/" + (from ima in imas
                                                                         where ima.HerID == i.ID
                                                                         select ima.ImagePath).FirstOrDefault();
                }
                Result.pdata = vrs;
                return Ok(Result);
            }
            catch
            {
                return BadRequest();
            }

        }

        [Route("GetHeritagerInfoHomeView/{curpage:min(1)}")]
        [ResponseType(typeof(tbHeritagerInforHomeModels))]
        [HttpPost]
        public IHttpActionResult GetHeritagerInfoHomeView(int curpage)
        {
            tbHeritagerInforHomeModels Result = new tbHeritagerInforHomeModels();
            int curPage = curpage;
            int nums = perPage * (curPage - 1);
            int nume = perPage;
            //try
            {

                var imas = dbContext.Database.SqlQuery<tbImage>("select * from tbImages, tbHeritagerInfor where tbImages.HerID=tbHeritagerInfor.ID and tbImages.IsAvatar= 'true'").ToList();
                var vrs = dbContext.Database.SqlQuery<tbHeritagerInforHomeModel>("GetHeritagerInfoview @nums,@nume",
                    new SqlParameter("@nums", nums),
                    new SqlParameter("@nume", nume)).ToList();
                foreach (var i in vrs)
                {
                    i.ImagePath = currentURL + "/Image/" + i.ID + "/" + (from ima in imas
                                                                         where ima.HerID == i.ID
                                                                         select ima.ImagePath).FirstOrDefault();
                }
                Result.pdata = vrs;
                return Ok(Result);
            }
            //catch
            {
                return BadRequest();
            }

        }

        [Route("SaveHeritagerInfo")]
        [HttpPost]
        //public IHttpActionResult UpdateHeritagerInfo(tbHeritagerInforModelPost par)
        //{
        //    //try
        //    {
        //        if (par.ID.checkIsNumber() > 0)
        //        {
        //            //int ID = par.ID.checkIsNumber();
        //            //tbHeritagerInfor p = (from i in dbContext.tbHeritagerInfors where i.ID == ID select i).FirstOrDefault();
        //            //if (p.ID > 0)
        //            //{
        //p.Address = par.Address;
        //    p.Contents = par.Contents;
        //    p.Description = par.Description;
        //    p.Location = System.Data.Entity.Spatial.DbGeography.PointFromText("Point(" + par.latitude + "," + par.Location + ")", System.Data.Entity.Spatial.DbGeography.DefaultCoordinateSystemId);
        //            //    p.Name = par.Name;
        //            //    p.Notes = par.Notes;
        //            //    p.TimeofBuild = par.TimeofBuild;

        //            //    tbHerinTag q = new tbHerinTag();
        //            //    q.HerID = p.ID;
        //            //    //q.TagID = Convert.ToInt32(from i in dbContext.tbTags where i.TagName == par.TagName select i.TagID);
        //            //    dbContext.SaveChanges();
        //            //    return Ok(1);
        //            //}



        //            return Ok(0);
        //        }
        //        else
        //        {
        //            tbHeritagerInfor p = new tbHeritagerInfor();
        //            p.Address = par.Address;
        //            p.Contents = par.Contents;
        //            p.Description = par.Description;
        //            p.Location = System.Data.Entity.Spatial.DbGeography.PointFromText(par.Location, System.Data.Entity.Spatial.DbGeography.DefaultCoordinateSystemId);
        //            p.Name = par.Name;
        //            p.Notes = par.Notes;
        //            p.TimeofBuild = par.TimeofBuild;
        //            dbContext.tbHeritagerInfors.Add(p);
        //            dbContext.SaveChanges();
        //            return Ok(1);
        //        }

        //    }
        //    //catch
        //    {
        //        return Ok(0);
        //    }
        //}

        [Route("DeleteHeritagerInfo")]
        [HttpDelete]
        public IHttpActionResult DeleteHeritagerInfo(int id)
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

        [Route("GetNameHeritager/{Prefix}")]
        [HttpPost]
        public IHttpActionResult GetNameHeritager(string Prefix)
        {
            var ListName = (from N in dbContext.tbHeritagerInfors
                            where N.Name.StartsWith(Prefix)
                            select new { N.Name }).ToList();
            return Ok(ListName);
        }

        [Route("SearchHeritager/{Prefix}/{curpage:min(1)}")]
        [HttpPost]
        public IHttpActionResult SearchHeritager(string Prefix, int curpage)
        {
            tbHeritagerInforHomeModels Result = new tbHeritagerInforHomeModels();
            int curPage = curpage;
            int nums = perPage * (curPage - 1);
            int nume = perPage;
            try
            {
                var imas = dbContext.Database.SqlQuery<tbImage>("select * from tbImages, tbHeritagerInfor where tbImages.HerID=tbHeritagerInfor.ID and tbImages.IsAvatar= 'true'").ToList();
                var vrs = dbContext.Database.SqlQuery<tbHeritagerInforHomeModel>("SearchFolollwingName @stringtemp,@nums,@nume",
                    new SqlParameter("@stringtemp", HttpUtility.UrlDecode(Prefix)),
                    new SqlParameter("@nums", nums),
                    new SqlParameter("@nume", nume)).ToList();
                foreach (var i in vrs)
                {
                    i.ImagePath = currentURL + "/Image/" + i.ID + "/" + (from ima in imas
                                                                         where ima.HerID == i.ID
                                                                         select ima.ImagePath).FirstOrDefault();
                }
                Result.pdata = vrs;
                return Ok(Result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("GetHeritagerInfoByTag/{tag}/{curpage:min(1)}")]
        [HttpPost]
        public IHttpActionResult GetHeritagerInfoByTag(string tag, int curpage)
        {
            tbHeritagerInforHomeModels Result = new tbHeritagerInforHomeModels();
            int curPage = curpage;
            int nums = perPage * (curPage - 1);
            int nume = perPage;
            try
            {
                var imas = dbContext.Database.SqlQuery<tbImage>("select * from tbImages, tbHeritagerInfor where tbImages.HerID=tbHeritagerInfor.ID and tbImages.IsAvatar= 'true'").ToList();
                var vrs = dbContext.Database.SqlQuery<tbHeritagerInforHomeModel>("SearchFollowingTag @stringtemp,@nums,@nume",
                    new SqlParameter("@stringtemp", tag),
                    new SqlParameter("@nums", nums),
                    new SqlParameter("@nume", nume)).ToList();
                foreach (var i in vrs)
                {
                    i.ImagePath = currentURL + "/Image/" + i.ID + "/" + (from ima in imas
                                                                         where ima.HerID == i.ID
                                                                         select ima.ImagePath).FirstOrDefault();
                }
                Result.pdata = vrs;
                return Ok(Result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public string LocationDistance(string X, string Y)
        {
            string abc = "";
            return abc;
        }
    }
}
