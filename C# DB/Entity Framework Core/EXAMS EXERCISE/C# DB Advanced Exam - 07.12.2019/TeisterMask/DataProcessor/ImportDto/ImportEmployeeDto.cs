﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeisterMask.Data.Models;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeDto
    {


        [Required]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"^[A-z]+[0-9]*$")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        public string Phone { get; set; }

        public int[] Tasks { get; set; }
    }
}

