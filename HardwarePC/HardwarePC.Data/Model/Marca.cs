using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Data.Model
{
    public class Marca : IdentityBase
    {
        public Marca()
        {
            this.Products = new HashSet<Producto>();
        }

        [Required]
        [DisplayName("Nombre marca")]
        public string NombreMarca { get; set; }

        public string LifeSpan { get; set; }

        [Required]
        [DisplayName("País")]
        public string Country { get; set; }

        [DisplayName("Descripción")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Recetas")]
        public int TotalProducts { get; set; }

        public virtual ICollection<Producto> Products { get; set; }
    }
}
