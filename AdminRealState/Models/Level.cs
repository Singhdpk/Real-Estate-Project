using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblLevel")]
    public class Level
    {
        public int Id { get; set; }
        public Nullable<int> value { get; set; }
    }
}