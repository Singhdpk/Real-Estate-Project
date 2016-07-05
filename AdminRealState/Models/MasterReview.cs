using AdminRealState.Models;
using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdminPanel.Models
{
    [Table("tblMasterReview")]
    public class MasterReview
    {
        public int Id { get; set; }
        public string Name { get; set; }

        MasterReviewRepository objMasterReviewRepository = new MasterReviewRepository();
        public List<MasterReview> GetAllData()
        {
            List<MasterReview> DataMasterReview = objMasterReviewRepository.GetAllData();
            return DataMasterReview;
        }

        public bool AddNewMasterReview(MasterReview objMasterReview)
        {
            bool isAdded = objMasterReviewRepository.AddNewMasterReview(objMasterReview);
            return isAdded;
        }

        public bool DeleteMasterReviewById(int id)
        {
            bool isDeleted = objMasterReviewRepository.DeleteMasterReviewById(id);
            return isDeleted;
        }
    }
}