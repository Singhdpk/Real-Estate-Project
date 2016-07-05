using AdminRealState.Repositories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.Models
{
    [Table("tblMasterApartmentBuildQuality")]
    public class MasterApartmentBuildQuality
    {
        public int Id { get; set; }
        public string Name { get; set; }

        MasterApartmentBuildQualityRepository objMasterApartmentBuildQualityRepository = new MasterApartmentBuildQualityRepository();
        public List<MasterApartmentBuildQuality> GetAllData()
        {
            List<MasterApartmentBuildQuality> DataMasterApartmentBuildQuality = objMasterApartmentBuildQualityRepository.GetAllData();
            return DataMasterApartmentBuildQuality;
        }
        public bool AddNewMasterApartmentBuildQuality(MasterApartmentBuildQuality objMasterApartmentBuildQuality)
        {
            bool isAdded = objMasterApartmentBuildQualityRepository.AddNewMasterApartmentBuildQuality(objMasterApartmentBuildQuality);
            return isAdded;
        }
        public bool DeleteMasterApartmentBuildQualityById(int id)
        {
            bool isDeleted = objMasterApartmentBuildQualityRepository.DeleteMasterApartmentBuildQualityById(id);
            return isDeleted;
        }
    }
}