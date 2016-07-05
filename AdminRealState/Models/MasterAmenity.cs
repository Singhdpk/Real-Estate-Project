using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblMasterAmenity")]
    public class MasterAmenity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        MasterAmenityRepository objMasterAmenityRepository = new MasterAmenityRepository();
        public List<MasterAmenity> GetAllData()
        {
            List<MasterAmenity> DataMasterAmenity = objMasterAmenityRepository.GetAllData();
            return DataMasterAmenity;
        }
        public bool AddNewMasterAmenity(MasterAmenity objMasterAmenity)
        {
            bool isAdded = objMasterAmenityRepository.AddNewMasterAmenity(objMasterAmenity);
            return isAdded;
        }

        public bool DeleteMasterAmenityById(int id)
        {
            bool isDeleted = objMasterAmenityRepository.DeleteMasterAmenityById(id);
            return isDeleted;
        }
    }
}