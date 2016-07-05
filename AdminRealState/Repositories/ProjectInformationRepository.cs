using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class ProjectInformationRepository
    {
        public bool FillProjectInformation(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {

                    foreach (var projInfo in objProject.ProjectInformations)
                    {
                        tblProjectInformation objtblProjectInformation = (new tblProjectInformation()
                        {
                            ProjectId = objProject.Id,
                            MasterProjectInformationId =projInfo.MasterProjectInformationId,
                            Value =projInfo.Value,
                        });
                        db.tblProjectInformations.AddObject(objtblProjectInformation);
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
        public bool DeleteProjectInformationByProjectId(int projectId)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblProjectInformation> projectInformation = db.tblProjectInformations.Where(data => data.ProjectId == projectId);
                    foreach (tblProjectInformation objtblProjectInformation in projectInformation.ToList())
                    {
                        db.tblProjectInformations.DeleteObject(objtblProjectInformation);
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
        public bool GetProjectInformationByProjectId(int projectId, ref Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblProjectInformation> projectInformations = db.tblProjectInformations.Where(data => data.ProjectId == projectId);
                    objProject.ProjectInformations = new List<ProjectInformation>();
                    foreach (tblProjectInformation objtblProjectInformation in projectInformations)
                    {
                        objProject.ProjectInformations.Add(new ProjectInformation() { Id = objtblProjectInformation.Id, MasterProjectInformationId = objtblProjectInformation.MasterProjectInformationId, ProjectId = objtblProjectInformation.ProjectId, Value = objtblProjectInformation.Value });
                    }

                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }
        public bool EditProjectInformation(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    for (var i = 0; i < objProject.ProjectInformations.Count; i++)
                    {
                        tblProjectInformation objtblProjectInformation = new tblProjectInformation()
                        {
                            Id = objProject.ProjectInformations[i].Id,
                            ProjectId = objProject.ProjectInformations[i].ProjectId,
                            MasterProjectInformationId = objProject.ProjectInformations[i].MasterProjectInformationId,
                            Value = objProject.ProjectInformations[i].Value,
                        };
                        if (objtblProjectInformation != null)
                        {
                            db.tblProjectInformations.Attach(objtblProjectInformation);
                            db.ObjectStateManager.ChangeObjectState(objtblProjectInformation, EntityState.Modified);
                            db.SaveChanges();
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