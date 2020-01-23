namespace PetStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation;
    using static DataValidation;
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        [MaxLength(DescriptionMaxLenght)]
        public string Description { get; set; }

        public Gender Gender { get; set; }

        public string Breed { get; set; }

        public ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();
        public ICollection<Toy> Toys { get; set; } = new HashSet<Toy>();
        public ICollection<Food> Foods { get; set; } = new HashSet<Food>();

    }
}
