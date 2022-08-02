using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MyWebAPI_APP.Data
{
    [Table("Products")]
    public class Products
    {
        [Key]
        [Required]
        public Guid IdProduct { get; set; }
        [Required][MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0,double.MaxValue)]
        public double Price { get; set; }
        public byte Discount { get; set; }
        public int? IdType { get; set; }
        [ForeignKey("IdType")]
        public TypeProduct TypeProduct { get; set; }
        public ICollection<BillInfor> BillInfors { get; set; }
        public Products()
        {
            BillInfors = new HashSet<BillInfor>();
        }
    }
}
