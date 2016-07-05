using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class ConstructionQualityParameterRepository
    {
        public bool FillConstructionQualityParameter(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    
                    for (var i = 0; i < objProject.ConstructionQualityParameters.Count; i++)
                    {
                        tblConstructionQualityParameter objtblConstructionQualityParameter = new tblConstructionQualityParameter()
                        {
                            ProjectId = objProject.Id,
                            MasterConstructionQualityParameterId = objProject.ConstructionQualityParameters[i].MasterConstructionQualityParameterId,
                           Value = objProject.ConstructionQualityParameters[i].Value,
                        };
                            db.tblConstructionQualityParameters.AddObject(objtblConstructionQualityParameter);
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
        public bool DeleteConstructionQualityParameterByProjectId(int projectId)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblConstructionQualityParameter> constructionQualityParameter = db.tblConstructionQualityParameters.Where(data => data.ProjectId == projectId);
                    foreach (tblConstructionQualityParameter objtblConstructionQualityParameter in constructionQualityParameter.ToList())
                    {
                        db.tblConstructionQualityParameters.DeleteObject(objtblConstructionQualityParameter);
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
        public bool GetConstructionQualityParameterByProjectId(int projectId, ref Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblConstructionQualityParameter> constructionQualityParameters = db.tblConstructionQualityParameters.Where(data => data.ProjectId == projectId);
                    int i = 0;
                    objProject.ConstructionQualityParameters = new List<ConstructionQualityParameter>();
                    foreach (tblConstructionQualityParameter objtblConstructionQualityParameters in constructionQualityParameters)
                    {
                        objProject.ConstructionQualityParameters.Add(new ConstructionQualityParameter() { Id = objtblConstructionQualityParameters.Id, MasterConstructionQualityParameterId = objtblConstructionQualityParameters.MasterConstructionQualityParameterId, ProjectId = objtblConstructionQualityParameters.ProjectId, Value = objtblConstructionQualityParameters.Value });
                    }

                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }
        public bool EditConstructionQualityParameter(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try {
                    for (var i = 0; i < objProject.ConstructionQualityParameters.Count; i++)
                    {
                        tblConstructionQualityParameter objtblConstructionQualityParameter = new tblConstructionQualityParameter()
                        {
                            Id = objProject.ConstructionQualityParameters[i].Id,
                            ProjectId = objProject.ConstructionQualityParameters[i].ProjectId,
                            MasterConstructionQualityParameterId = objProject.ConstructionQualityParameters[i].MasterConstructionQualityParameterId,
                            Value = objProject.ConstructionQualityParameters[i].Value,
                        };
                        if (objtblConstructionQualityParameter != null)
                        {
                            db.tblConstructionQualityParameters.Attach(objtblConstructionQualityParameter);
                            db.ObjectStateManager.ChangeObjectState(objtblConstructionQualityParameter, EntityState.Modified);
                            db.SaveChanges();
                        }
                    }
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
    }
}