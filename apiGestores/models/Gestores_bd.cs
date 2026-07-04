using System.ComponentModel.DataAnnotations;

namespace apiGestores.models
{
    public class Gestores_bd
    {
        [Key]
        public int id { get; set; }
        [Required]
        public required string nombre { get; set; }
        [Required]
        public int lanzamiento { get; set; }
        [Required]
        public required string desarrollador { get; set; }


    }
}
