using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAPI_APP.Data
{
    [Table("TypeProduct")]
    public class TypeProduct
    {
        [Key]
        public int IdType { get; set; }
        [Required][MaxLength(50)]
        public string NameType { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
