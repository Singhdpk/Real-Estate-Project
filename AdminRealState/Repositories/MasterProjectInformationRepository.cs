using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class MasterProjectInformationRepository
    {
        public List<MasterProjectInformation> GetAllData()
        {


            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                List<tblMasterProjectInformation> datatblMasterProjectInformation = new List<tblMasterProjectInformation>();
                datatblMasterProjectInformation = db.tblMasterProjectInformations.ToList();
                List<MasterProjectInformation> dataMasterProjectInformation = new List<MasterProjectInformation>();

                for (var i = 0; i < datatblMasterProjectInformation.Count; i++)
                {
                    dataMasterProjectInformation.Add(new MasterProjectInformation() { Id = datatblMasterProjectInformation[i].Id, Name = datatblMasterProjectInformation[i].Name });
                }
                return dataMasterProjectInformation;
            }
        }

        public bool AddNewMasterProjectInformation(MasterProjectInformation objMasterProjectInformation)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {

                    tblMasterProjectInformation objtblMasterProjectInformation = new tblMasterProjectInformation();
                    if (objMasterProjectInformation.Id == 0)
                    {
                        objtblMasterProjectInformation.Name = objMasterProjectInformation.Name;
                        db.tblMasterProjectInformations.AddObject(objtblMasterProjectInformation);
                        db.SaveChanges();
                    }
                    else
                    {
                        objtblMasterProjectInformation.Id = objMasterProjectInformation.Id;
                        objtblMasterProjectInformation.Name = objMasterProjectInformation.Name;
                        db.tblMasterProjectInformations.Attach(objtblMasterProjectInformation);
                        db.ObjectStateManager.ChangeObjectState(objtblMasterProjectInformation, EntityState.Modified);
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
        public bool DeleteMasterProjectInformationById(int id)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblMasterProjectInformation objtblMasterProjectInformation = new tblMasterProjectInformation();
                    objtblMasterProjectInformation = db.tblMasterProjectInformations.FirstOrDefault(data => data.Id == id);
                    db.tblMasterProjectInformations.DeleteObject(objtblMasterProjectInformation);
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