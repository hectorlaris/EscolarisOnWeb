using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ProgramId { get; set; }
        public string ProgramName { get; set; } = ""; // in case Acad Program name changes
        public double Price { get; set; }
        public int BeforeQty { get; set; }
        public int SoldQty { get; set; }
        public string CashierName { get; set; } = "";
    }
}
