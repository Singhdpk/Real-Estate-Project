using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class MasterLivabilityRepository
    {
        public List<MasterLivability> GetAllData()
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                List<tblMasterLivability> datatblMasterLivability = new List<tblMasterLivability>();
                datatblMasterLivability = db.tblMasterLivabilities.ToList();
                List<MasterLivability> dataMasterLivability = new List<MasterLivability>();

                for (var i = 0; i < datatblMasterLivability.Count; i++)
                {
                    dataMasterLivability.Add(new MasterLivability() { Id = datatblMasterLivability[i].Id, Name = datatblMasterLivability[i].Name });
                }
                return dataMasterLivability;
            }
        }

        public bool AddNewMasterLivability(MasterLivability objMasterLivability)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblMasterLivability objtblMasterLivability = new tblMasterLivability();
                    if (objMasterLivability.Id == 0)
                    {
                        objtblMasterLivability.Name = objMasterLivability.Name;
                        db.tblMasterLivabilities.AddObject(objtblMasterLivability);
                        db.SaveChanges();
                    }

                    else
                    {
                        objtblMasterLivability.Id = objMasterLivability.Id;
                        objtblMasterLivability.Name = objMasterLivability.Name;
                        db.tblMasterLivabilities.Attach(objtblMasterLivability);
                        db.ObjectStateManager.ChangeObjectState(objtblMasterLivability, EntityState.Modified);
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
        public bool DeleteMasterLivabilityById(int id)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblMasterLivability objtblMasterLivability = new tblMasterLivability();
                    objtblMasterLivability = db.tblMasterLivabilities.FirstOrDefault(data => data.Id == id);
                    db.tblMasterLivabilities.DeleteObject(objtblMasterLivability);
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
