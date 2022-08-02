namespace MyWebAPI_APP.Data
{
    public class BillInfor
    {
        public Guid IdProduct { get; set; }
        public Guid IdBill { get; set; }
        public int Counts { get; set; }
        public double Price { get; set; } // đơn giá lúc mua
        public byte Discount { get; set; } // giảm giá lúc mua

        // relationship
        public Bill Bill { get; set; }
        public Products Products { get; set; }
    }
}
