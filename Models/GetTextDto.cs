using DiegoWebApi.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiegoWebApi.Models
{
    public class GetTextDto
    {
        [Required(ErrorMessage = "TextToOrder es requerido")]
        public string TextToOrder { get; set; }

        [Required]
        public OrderOptionsEnum OrderOption { get; set; }
    }
}