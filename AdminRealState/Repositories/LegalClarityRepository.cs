using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class LegalClarityRepository
    {
        public bool FillLegalClarity(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {

                    for (var i = 0; i < objProject.LegalClarities.Count; i++)
                    {
                        tblLegalClarity objtblLegalClarity = new tblLegalClarity()
                        {
                            ProjectId = objProject.Id,
                            MasterLegalClarityId = objProject.LegalClarities[i].MasterLegalClarityId,
                            Value = objProject.LegalClarities[i].Value,
                        };
                        db.tblLegalClarities.AddObject(objtblLegalClarity);
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
        public bool DeleteLegalClarityByProjectId(int projectId)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblLegalClarity> legalClarity = db.tblLegalClarities.Where(data => data.ProjectId == projectId);
                    foreach (tblLegalClarity objtblLegalClarity in legalClarity.ToList())
                    {
                        db.tblLegalClarities.DeleteObject(objtblLegalClarity);
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
        public bool GetLegalClarityByProjectId(int projectId, ref Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblLegalClarity> legalClarities = db.tblLegalClarities.Where(data => data.ProjectId == projectId);
                    int i = 0;
                    objProject.LegalClarities = new List<LegalClarity>();
                    foreach (tblLegalClarity objtblLegalClarity in legalClarities)
                    {
                        objProject.LegalClarities.Add(new LegalClarity() { Id = objtblLegalClarity.Id, MasterLegalClarityId = objtblLegalClarity.MasterLegalClarityId, ProjectId = objtblLegalClarity.ProjectId, Value = objtblLegalClarity.Value });
                    }

                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }
        public bool EditLegalClarity(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {

                    for (var i = 0; i < objProject.LegalClarities.Count; i++)
                    {
                        tblLegalClarity objtblLegalClarity = new tblLegalClarity()
                        {
                            Id = objProject.LegalClarities[i].Id,
                            ProjectId = objProject.LegalClarities[i].ProjectId,
                            MasterLegalClarityId = objProject.LegalClarities[i].MasterLegalClarityId,
                            Value = objProject.LegalClarities[i].Value,
                        };
                        if (objtblLegalClarity != null)
                        {
                            db.tblLegalClarities.Attach(objtblLegalClarity);
                            db.ObjectStateManager.ChangeObjectState(objtblLegalClarity, EntityState.Modified);
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