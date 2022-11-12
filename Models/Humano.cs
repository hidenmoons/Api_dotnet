using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Dotnet.Models
{
    public partial class Humano
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Sexo { get; set; }
        public int? Edad { get; set; }
        public int? Altura { get; set; }
        public int? Peso { get; set; }
    }
}
