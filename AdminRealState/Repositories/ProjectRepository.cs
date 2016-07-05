using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{

    public class ProjectRepository
    {

        public bool CreateNewProperty(Project objProject, out int isProjectId)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {

                    tblProject objtblProject = new tblProject();
                    objtblProject.Name = objProject.Name;
                    objtblProject.Possession = objProject.Possession;
                    objtblProject.Pricing = objProject.Pricing;
                    //objtblProject.BuilderName = objProject.BuilderName;
                   // objtblProject.CoverPicture = objProject.CoverPictureDetail.FileName;

                    string physicalPathCoverPictures = System.Web.HttpContext.Current.Server.MapPath(("ProjectCoverPicture") + "\\" + objProject.CoverPictureDetail.FileName);
                    objProject.CoverPictureDetail.SaveAs(physicalPathCoverPictures);

                    //objtblProject.ProfilePicture = objProject.ProfilePictureDetail.FileName;

                    string physicalPathProfilePicture = System.Web.HttpContext.Current.Server.MapPath(("ProjectProfilePicture") + "\\" + objProject.ProfilePictureDetail.FileName);
                    objProject.ProfilePictureDetail.SaveAs(physicalPathProfilePicture);

                    db.tblProjects.AddObject(objtblProject);
                    db.SaveChanges();
                    isProjectId = objtblProject.Id;
                    return true;
                }

                catch (Exception ex)
                {
                    isProjectId = 0;
                    return false;
                }
            }
        }

        public Project CheckProjectIdIsPresent(int? projectId)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                Project objProject = new Project();
                try
                {
                    tblProject objtblProject = db.tblProjects.FirstOrDefault(project => project.Id == projectId);
                    objProject.Id = objtblProject.Id;
                    objProject.Name = objtblProject.Name;
                    objProject.Possession = objtblProject.Possession;
                    objProject.Pricing = objtblProject.Pricing;
                    //objProject.BuilderName = objtblProject.BuilderName;
                    //objProject.CoverPicture = objtblProject.CoverPicture;
                    //objProject.ProfilePicture = objtblProject.ProfilePicture;
                    return objProject;
                }
                catch (Exception ex)
                {
                    return objProject;
                }

            }
        }
        public bool DeleteProjectByProjectId(int projectId)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblProject objtblProject = new tblProject();

                    objtblProject = db.tblProjects.FirstOrDefault(project => project.Id == projectId);
                    db.tblProjects.DeleteObject(objtblProject);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool GetProjectById(int projectId, ref Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {

                    tblProject objtblProject = new tblProject();
                    objtblProject = db.tblProjects.FirstOrDefault(data => data.Id == projectId);
                    objProject.Id = objtblProject.Id;
                    objProject.Name = objtblProject.Name;
                    objProject.Possession = objtblProject.Possession;
                    objProject.Pricing = objtblProject.Pricing;
                    //objProject.BuilderName = objtblProject.BuilderName;
                    //objProject.CoverPicture = objtblProject.CoverPicture;
                    //objProject.ProfilePicture = objtblProject.ProfilePicture;

                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }
        public List<Project> GetAllData()
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                List<tblProject> datatblProject = new List<tblProject>();
                datatblProject = db.tblProjects.ToList();
                List<Project> dataProject = new List<Project>();

                for (var i = 0; i < datatblProject.Count; i++)
                {
                    dataProject.Add(new Project() { Id = datatblProject[i].Id, Name = datatblProject[i].Name });
                }
                return dataProject;
            }
        }
        public bool EditProject(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblProject objtblProject = new tblProject();
                    objtblProject.Id = objProject.Id;
                    objtblProject.Name = objProject.Name;
                    objtblProject.Possession = objProject.Possession;
                    objtblProject.Pricing = objProject.Pricing;
                   // objtblProject.BuilderName = objProject.BuilderName;
                    if (objProject.CoverPictureDetail != null)
                    {

                        string physicalPathCoverPicturesDelete = System.Web.HttpContext.Current.Server.MapPath("~\\" + ("ProjectCoverPicture") + "\\" + objProject.CoverPicture);
                        System.IO.File.Delete(physicalPathCoverPicturesDelete);
                      //  objtblProject.CoverPicture = objProject.CoverPictureDetail.FileName;
                        string physicalPathCoverPictures = System.Web.HttpContext.Current.Server.MapPath("~\\" + ("ProjectCoverPicture") + "\\" + objProject.CoverPictureDetail.FileName);
                        objProject.CoverPictureDetail.SaveAs(physicalPathCoverPictures);
                    }
                    if (objProject.ProfilePictureDetail != null)

                    {
                        string physicalPathProfilePictureDelete = System.Web.HttpContext.Current.Server.MapPath("~\\" + ("ProjectProfilePicture") + "\\" + objProject.ProfilePicture);
                        System.IO.File.Delete(physicalPathProfilePictureDelete);
                       // objtblProject.ProfilePicture = objProject.ProfilePictureDetail.FileName;
                        string physicalPathProfilePicture = System.Web.HttpContext.Current.Server.MapPath("~\\" + ("ProjectProfilePicture") + "\\" + objProject.ProfilePictureDetail.FileName);
                        objProject.ProfilePictureDetail.SaveAs(physicalPathProfilePicture);
                    }


                    db.tblProjects.Attach(objtblProject);
                    db.ObjectStateManager.ChangeObjectState(objtblProject, EntityState.Modified);
                    db.SaveChanges();



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
