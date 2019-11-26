using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class OfficerDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }


        [XmlElement("Money")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Money { get; set; }

        [XmlElement("Position")]
        [Required]
        public string Positon { get; set; }

        [XmlElement("Weapon")]
        [Required]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        [Required]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public PrisonerXmlDto[] Prisoners { get; set; }

    }
}
