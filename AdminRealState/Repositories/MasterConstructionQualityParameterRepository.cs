using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class MasterConstructionQualityParameterRepository
    {
        public List<MasterConstructionQualityParameter> GetAllData()
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                List<tblMasterConstructionQualityParameter> datatblMasterConstructionQualityParameter = new List<tblMasterConstructionQualityParameter>();
                datatblMasterConstructionQualityParameter = db.tblMasterConstructionQualityParameters.ToList();
                List<MasterConstructionQualityParameter> dataMasterConstructionQualityParameter = new List<MasterConstructionQualityParameter>();

                for (var i = 0; i < datatblMasterConstructionQualityParameter.Count; i++)
                {
                    dataMasterConstructionQualityParameter.Add(new MasterConstructionQualityParameter() { Id = datatblMasterConstructionQualityParameter[i].Id, Name = datatblMasterConstructionQualityParameter[i].Name });
                }
                return dataMasterConstructionQualityParameter;
            }
        }

        public bool AddNewMasterConstructionQualityParameter(MasterConstructionQualityParameter objMasterConstructionQualityParameter)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblMasterConstructionQualityParameter objtblMasterConstructionQualityParameter = new tblMasterConstructionQualityParameter();
                    if (objMasterConstructionQualityParameter.Id == 0)
                    {
                        objtblMasterConstructionQualityParameter.Name = objMasterConstructionQualityParameter.Name;
                        db.tblMasterConstructionQualityParameters.AddObject(objtblMasterConstructionQualityParameter);
                        db.SaveChanges();
                    }
                    else
                    {
                        objtblMasterConstructionQualityParameter.Id = objMasterConstructionQualityParameter.Id;
                        objtblMasterConstructionQualityParameter.Name = objMasterConstructionQualityParameter.Name;
                        db.tblMasterConstructionQualityParameters.Attach(objtblMasterConstructionQualityParameter);
                        db.ObjectStateManager.ChangeObjectState(objtblMasterConstructionQualityParameter, EntityState.Modified);
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
        public bool DeleteMasterConstructionQualityParameter(int id)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblMasterConstructionQualityParameter objtblMasterConstructionQualityParameter = new tblMasterConstructionQualityParameter();
                    objtblMasterConstructionQualityParameter = db.tblMasterConstructionQualityParameters.FirstOrDefault(data => data.Id == id);
                    db.tblMasterConstructionQualityParameters.DeleteObject(objtblMasterConstructionQualityParameter);
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