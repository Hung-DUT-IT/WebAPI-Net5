namespace MyWebAPI_APP.Models
{
    public class ProductsVM
    {
        public string? TenHangHoa { get; set; }
        public double DonGia { get; set; }
    }
    public class Products : ProductsVM
    {
        public Guid MaHangHoa { get; set; }
    }
}
