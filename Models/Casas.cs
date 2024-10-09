using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagosHogwarts.Models
{
    public class Casas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CasaId { get; set; }

        public string Nombre { get; set; } = string.Empty;
    }
}
