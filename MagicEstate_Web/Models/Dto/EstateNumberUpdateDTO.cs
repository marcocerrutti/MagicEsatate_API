﻿using System.ComponentModel.DataAnnotations;

namespace MagicEsatate_Web.Models.Dto
{
    public class EstateNumberUpdateDTO
    {
        [Required]
        public int EstateNo { get; set; }

        [Required]
        public int EstateID { get; set; }
        public string SpecialDetails { get; set; }
    }
}
