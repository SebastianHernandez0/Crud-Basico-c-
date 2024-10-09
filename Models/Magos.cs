using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagosHogwarts.Models
{
    public class Magos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int CasaId { get; set; }
        public string Imagen { get; set; } = string.Empty;
        public string Wiki { get; set; } = string.Empty;

        [ForeignKey("CasaId")]
        public virtual Casas Casas { get; set; } = null!;

    }
}
