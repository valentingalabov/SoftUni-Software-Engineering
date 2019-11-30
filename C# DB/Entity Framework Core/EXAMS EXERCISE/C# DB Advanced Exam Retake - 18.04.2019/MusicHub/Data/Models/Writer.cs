﻿
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class Writer
    {
        //        •	Id – integer, Primary Key
        //•	Name– text with min length 3 and max length 20 (required)
        //•	Pseudonym – text, consisting of two words separated with space and each word must start with one upper letter and continue with many lower-case letters(Example: "Freddie Mercury")
        //•	Songs – collection of type Song

        public Writer()
        {
            this.Songs = new HashSet<Song>();
        }
        public int Id { get; set; }

       
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+$")]
        public string Pseudonym { get; set; }

        public ICollection<Song> Songs { get; set; }

    }
}
