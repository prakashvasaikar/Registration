using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationApp_DL
{
    [Table("tblState")]
    public class StateModel
    {
        [Key]
        public int Id { get; set; }
        public string StateName { get; set; }

    }
}
