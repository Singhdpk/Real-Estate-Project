using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class ImagesRepository
    {
        public bool FillImages(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    for (var i = 0; i < objProject.ProjectImagesDetails.Count; i++)
                    {
                        tblImage objtblImage = new tblImage()
                        {
                            ProjectId = objProject.Id,
                           // ImageName = objProject.ProjectImagesDetails[i].FileName,
                        };
                        db.tblImages.AddObject(objtblImage);
                        db.SaveChanges();

                        string physicalPath = System.Web.HttpContext.Current.Server.MapPath(("ProjectImages") + "\\" + objProject.ProjectImagesDetails[i].FileName);
                        objProject.ProjectImagesDetails[i].SaveAs(physicalPath);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public bool DeleteImagesByProjectId(int projectId)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {

                try
                {
                    IEnumerable<tblImage> image = db.tblImages.Where(data => data.ProjectId == projectId);
                    foreach (tblImage objtblImage in image.ToList())
                    {
                        db.tblImages.DeleteObject(objtblImage);
                        db.SaveChanges();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public bool GetImageByProjectId(int projectId, ref Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblImage> images = db.tblImages.Where(data => data.ProjectId == projectId);
                    int i = 0;
                    objProject.Images = new List<Images>();
                    foreach (tblImage objtblImage in images)
                    {
                       // objProject.Images.Add(new Images() { Id = objtblImage.Id, ProjectId = objtblImage.ProjectId, Image = objtblImage.ImageName });
                    }

                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }
        public bool EditImages(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {


                    for (var j = 0; j < objProject.ImageToBeDeleted.Count; j++)
                    {
                        if (objProject.ImageToBeDeleted[j].deleted)
                        {
                            int imageIdToBeDeleted = objProject.ImageToBeDeleted[j].imageId;
                            tblImage objtblImage = new tblImage();
                            objtblImage = db.tblImages.FirstOrDefault(data => data.Id == imageIdToBeDeleted);
                            //string physicalPathImageDelete = System.Web.HttpContext.Current.Server.MapPath("~\\" + ("ProjectImages") + "\\" + objtblImage.ImageName);
                            //System.IO.File.Delete(physicalPathImageDelete);
                            db.tblImages.DeleteObject(objtblImage);
                            db.SaveChanges();
                        }
                    }


                    for (var i = 0; i < objProject.ProjectImagesDetails.Count; i++)
                    {
                        tblImage objtblImage = new tblImage();

                        if (objProject.ProjectImagesDetails[i] != null)
                        {
                            objtblImage.Id = objProject.Images[i].Id;
                            objtblImage.ProjectId = objProject.Images[i].ProjectId;
                           // objtblImage.ImageName = objProject.ProjectImagesDetails[i].FileName;

                            db.tblImages.Attach(objtblImage);
                            db.tblImages.AddObject(objtblImage);
                            db.SaveChanges();
                            string physicalPath = System.Web.HttpContext.Current.Server.MapPath("~\\" + ("ProjectImages") + "\\" + objProject.ProjectImagesDetails[i].FileName);
                            objProject.ProjectImagesDetails[i].SaveAs(physicalPath);
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }
    }
}
