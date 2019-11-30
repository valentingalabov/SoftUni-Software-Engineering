using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Performer")]
    public class ImportPerformerDto
    {

        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }


        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }


        [Range(18, 70)]
        public int Age { get; set; }


        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal NetWorth { get; set; }

        [XmlArray("PerformersSongs")]
        public ImportPerformerSongsDto[] PerformerSongs { get; set; }

    }
}
