using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class MasterReviewRepository
    {
        public List<MasterReview> GetAllData()
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                List<tblMasterReview> datatblMasterReview = new List<tblMasterReview>();
                datatblMasterReview = db.tblMasterReviews.ToList();
                List<MasterReview> dataMasterReview = new List<MasterReview>();

                for (var i = 0; i < datatblMasterReview.Count; i++)
                {
                    dataMasterReview.Add(new MasterReview() { Id = datatblMasterReview[i].Id, Name = datatblMasterReview[i].Name });
                }
                return dataMasterReview;
            }
        }

        public bool AddNewMasterReview(MasterReview objMasterReview)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    
                        tblMasterReview objtblMasterReview = new tblMasterReview();
                    if (objMasterReview.Id == 0)
                    {
                        objtblMasterReview.Name = objMasterReview.Name;
                        db.tblMasterReviews.AddObject(objtblMasterReview);
                        db.SaveChanges();
                    }
                    else
                    {
                        objtblMasterReview.Id = objMasterReview.Id;
                        objtblMasterReview.Name = objMasterReview.Name;
                        db.tblMasterReviews.Attach(objtblMasterReview);
                        db.ObjectStateManager.ChangeObjectState(objtblMasterReview, EntityState.Modified);
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
        public bool DeleteMasterReviewById(int id)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {

                    tblMasterReview objtblMasterReview = new tblMasterReview();
                    objtblMasterReview = db.tblMasterReviews.FirstOrDefault(data => data.Id == id);
                    db.tblMasterReviews.DeleteObject(objtblMasterReview);
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