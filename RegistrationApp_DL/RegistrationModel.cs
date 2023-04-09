using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationApp_DL
{
    [Table("tblUserRegistration")]
    public class RegistrationModel
    {
        [Key]
        public int Id { get; set; }
        public int refID_StateMst { get; set; }
        public int refID_CityMst { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        
    }
}
