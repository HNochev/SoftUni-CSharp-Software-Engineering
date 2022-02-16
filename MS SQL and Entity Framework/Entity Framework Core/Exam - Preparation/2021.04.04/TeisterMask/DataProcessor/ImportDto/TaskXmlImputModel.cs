using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class TaskXmlImputModel
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [Required]
        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        [EnumDataType(typeof(ExecutionType))]
        public string ExecutionType { get; set; }

        [XmlElement("LabelType")]
        [EnumDataType(typeof(LabelType))]
        public string LabelType { get; set; }
    }
}