using System;
using System.ComponentModel.DataAnnotations;

namespace IRunesApp.Models
{
    public class Track
    {
        public Track()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public string AlbumID { get; set; }

        public Album Album { get; set; }

    }
}
