using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminRealState.Models
{
    [Table("tblMasterBuilderProfile")]
    public class MasterBuilderProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }

        MasterBuilderProfileRepository objMasterBuilderProfileRepository = new MasterBuilderProfileRepository();
        public List<MasterBuilderProfile> GetAllData()
        {
            List<MasterBuilderProfile> DataMasterBuilderProfile = objMasterBuilderProfileRepository.GetAllData();
            return DataMasterBuilderProfile;
        }
        public bool AddNewMasterBuilderProfile(MasterBuilderProfile objMasterBuilderProfile)
        {
            bool isAdded = objMasterBuilderProfileRepository.AddNewMasterBuilderProfile(objMasterBuilderProfile);
            return isAdded;
        }

        public bool DeleteMasterBuilderProfileById(int id)
        {
            bool isDeleted = objMasterBuilderProfileRepository.DeleteMasterBuilderProfileById(id);
            return isDeleted;
        }
    }
}