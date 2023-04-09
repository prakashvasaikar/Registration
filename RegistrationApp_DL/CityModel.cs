using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationApp_DL
{
    [Table("tblCity")]
    public class CityModel
    {
        [Key]
        public int Id { get; set; }
        public int refID_StateMst { get; set; }
        public string CityName { get; set; }
    }
}
