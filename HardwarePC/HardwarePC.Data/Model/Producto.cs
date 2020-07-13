using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Data.Model
{
    public class Producto : IdentityBase
    {

    
        [DisplayName("Titulo")] 
        public string Title { get; set; }
        [DisplayName("Descripción")]
        public string Description { get; set; }
        [DisplayName("Marca Id")]
        public int MarcaId { get; set; }
        [DisplayName("Imagen")]
        public string Image { get; set; }
        [DisplayName("Precio")]
        public double Price { get; set; }
        [DisplayName("Cant. Vendida")]
        public int QuantitySold { get; set; }
        [DisplayName("Reputación")]
        public double AvgStars { get; set; }

        //Metodo virtual para poder sobrescribir
        public virtual Marca Marca { get; set; }
    }
}
