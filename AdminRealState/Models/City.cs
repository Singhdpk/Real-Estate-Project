using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblCity")]
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        CityRepository objCityRepository = new CityRepository();
        public List<City> GetAllData()
        {
            List<City> dataCity = objCityRepository.GetAllData();
            return dataCity;
        }
    }
}