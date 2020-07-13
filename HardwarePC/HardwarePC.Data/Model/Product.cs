using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HardwarePC.Data.Model
{
    public class Product : IdentityBase
    {
        public Product()
        {
            Image = "empty.png";
        }
        [Required]
        [DisplayName("Título")]
        public string Title { get; set; }

        [DisplayName("Descripción")]
        [Required]
        public string Description { get; set; }

        [DisplayName("Artista")]
        [Required]
        public int ArtistId { get; set; }

        [DisplayName("Imagen")]
        public string Image { get; set; }

        [DisplayName("Precio")]
        [Required]
        public double Price { get; set; }

        [DisplayName("Cantidad vendida")]
        [Required]
        public int QuantitySold { get; set; }

        [DisplayName("Ranking")]
        public double AvgStars { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
