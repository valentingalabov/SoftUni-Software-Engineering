﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class Producer
    {
        //        •	Id – integer, Primary Key
        //•	Name– text with min length 3 and max length 30 (required)
        //•	Pseudonym – text, consisting of two words separated with space and each word must start with one upper letter and continue with many lower-case letters(Example: "Bon Jovi")
        //•	PhoneNumber – text, consisting only of three groups(separated by space) of three digits and starting always with "+359" (Example: "+359 887 234 267")
        //•	Albums – collection of type Album

        public Producer()
        {
            this.Albums = new HashSet<Album>();
        }
        public int Id { get; set; }

      
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+$")]
        public string Pseudonym { get; set; }

        [RegularExpression(@"^[+]359 [0-9]{3} [0-9]{3} [0-9]{3}$")]
        public string PhoneNumber { get; set; }

        public ICollection<Album> Albums { get; set; }

    }
}
