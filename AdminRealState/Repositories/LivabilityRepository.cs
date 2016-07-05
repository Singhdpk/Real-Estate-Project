using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class LivabilityRepository
    {
        public bool FillLivability(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {

                    for (var i = 0; i < objProject.Livabilities.Count; i++)
                    {
                        tblLivability objtblLivability = new tblLivability()
                        {
                            ProjectId = objProject.Id,
                            MasterLivabilityId = objProject.Livabilities[i].MasterLivabilityId,
                            Name = objProject.Livabilities[i].Name,
                            Value = objProject.Livabilities[i].Value,
                        };
                        db.tblLivabilities.AddObject(objtblLivability);
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
        public bool DeleteLivabilityByProjectId(int projectId)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblLivability> livability = db.tblLivabilities.Where(data => data.ProjectId == projectId);
                    foreach (tblLivability objtblLivability in livability.ToList())
                    {
                        db.tblLivabilities.DeleteObject(objtblLivability);
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
        public bool GetLivabilityByProjectId(int projectId, ref Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblLivability> livabilities = db.tblLivabilities.Where(data => data.ProjectId == projectId);
                    int i = 0;
                    objProject.Livabilities = new List<Livability>();
                    foreach (tblLivability objtblLivability in livabilities)
                    {
                        objProject.Livabilities.Add(new Livability() { Id = objtblLivability.Id, MasterLivabilityId = objtblLivability.MasterLivabilityId, ProjectId = objtblLivability.ProjectId, Value = objtblLivability.Value, Name = objtblLivability.Name });
                    }

                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }
        public bool EditLivability(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    for (var i = 0; i < objProject.Livabilities.Count; i++)
                    {
                        tblLivability objtblLivability = new tblLivability()
                        {
                            Id = objProject.Livabilities[i].Id,
                            ProjectId = objProject.Livabilities[i].ProjectId,
                            MasterLivabilityId = objProject.Livabilities[i].MasterLivabilityId,
                            Name = objProject.Livabilities[i].Name,
                            Value = objProject.Livabilities[i].Value,
                        };
                        if (objtblLivability != null)
                        {
                            db.tblLivabilities.Attach(objtblLivability);
                            db.ObjectStateManager.ChangeObjectState(objtblLivability, EntityState.Modified);
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