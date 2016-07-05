using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class MasterLegalClarityRepository
    {
        public List<MasterLegalClarity> GetAllData()
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                List<tblMasterLegalClarity> datatblMasterLegalClarity = new List<tblMasterLegalClarity>();
                datatblMasterLegalClarity = db.tblMasterLegalClarities.ToList();
                List<MasterLegalClarity> dataMasterLegalClarities = new List<MasterLegalClarity>();

                for (var i = 0; i < datatblMasterLegalClarity.Count; i++)
                {
                    dataMasterLegalClarities.Add(new MasterLegalClarity() { Id = datatblMasterLegalClarity[i].Id, Name = datatblMasterLegalClarity[i].Name });
                }
                return dataMasterLegalClarities;
            }
        }

        public bool AddNewMasterLegalClarity(MasterLegalClarity objMasterLegalClarity)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblMasterLegalClarity objtblMasterLegalClarity = new tblMasterLegalClarity();
                    if (objMasterLegalClarity.Id == 0)
                    {
                        objtblMasterLegalClarity.Name = objMasterLegalClarity.Name;
                        db.tblMasterLegalClarities.AddObject(objtblMasterLegalClarity);
                        db.SaveChanges();
                    }

                    else
                    {
                        objtblMasterLegalClarity.Id = objMasterLegalClarity.Id;
                        objtblMasterLegalClarity.Name = objMasterLegalClarity.Name;
                        db.tblMasterLegalClarities.Attach(objtblMasterLegalClarity);
                        db.ObjectStateManager.ChangeObjectState(objtblMasterLegalClarity, EntityState.Modified);
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
        public bool DeleteMasterLegalClarityById(int id)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblMasterLegalClarity objtblMasterLegalClarity = new tblMasterLegalClarity();
                    objtblMasterLegalClarity = db.tblMasterLegalClarities.FirstOrDefault(data => data.Id == id);
                    db.tblMasterLegalClarities.DeleteObject(objtblMasterLegalClarity);
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