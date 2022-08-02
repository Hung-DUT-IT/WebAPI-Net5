namespace MyWebAPI_APP.Data
{
    public enum StatusBill
    {
        New = 0, Payment = 1, Complete = 2 , Cancel = -1 
    }
    public class Bill
    {
        public Guid IdBill { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public StatusBill Status { get; set; }
        public string NameCustomer { get; set; }
        public string DeliveryAddress { get; set; }
        public string Phone { get; set; }
        public ICollection<BillInfor> BillInfors { get; set; }
        public Bill()
        {
            BillInfors = new HashSet<BillInfor>();
        }
    }
}
