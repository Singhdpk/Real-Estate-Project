using AdminRealState.Repositories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.Models
{
    [Table("tblMasterConstructionQualityParameter")]
    public class MasterConstructionQualityParameter
    {
        public int Id { get; set; }
        public string Name { get; set; }

        MasterConstructionQualityParameterRepository objMasterConstructionQualityParameterRepository = new MasterConstructionQualityParameterRepository();
        public List<MasterConstructionQualityParameter> GetAllData()
        {
            List<MasterConstructionQualityParameter> DataMasterConstructionQualityParameter = objMasterConstructionQualityParameterRepository.GetAllData();
            return DataMasterConstructionQualityParameter;
        }
        public bool AddNewMasterConstructionQualityParameter(MasterConstructionQualityParameter objMasterConstructionQualityParameter)
        {
            bool isAdded = objMasterConstructionQualityParameterRepository.AddNewMasterConstructionQualityParameter(objMasterConstructionQualityParameter);
            return isAdded;
        }

        public bool DeleteMasterConstructionQualityParameter(int id)
        {
            bool isDeleted = objMasterConstructionQualityParameterRepository.DeleteMasterConstructionQualityParameter(id);
            return isDeleted;
        }
    }
}