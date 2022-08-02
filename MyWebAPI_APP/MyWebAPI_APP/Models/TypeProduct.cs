using System.ComponentModel.DataAnnotations;

namespace MyWebAPI_APP.Models
{
    public class TypeProductModel
    {
        [Required]
        [MaxLength(50)]
        public string NameType { get; set; }
    }
}
