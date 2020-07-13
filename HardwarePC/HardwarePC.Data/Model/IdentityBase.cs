using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Data.Model
{
    public class IdentityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        [Required]
        public DateTime ChangedOn { get; set; }
        public string ChangedBy { get; set; }
    }
}
