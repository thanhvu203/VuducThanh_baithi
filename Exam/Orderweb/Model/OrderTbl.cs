using System.ComponentModel.DataAnnotations;

namespace Orderweb.Model
{
    public class OrderTbl
    {
        [Key]
        public int ItemCode { get; set; }
        [Required] public string ItemName { get; set; }
        [Required] public int ItemQty { get; set; }
        [Required] public DateTime OrderDelivery { get; set; }
        [Required] public string OrderAddress { get; set; }
        [Required] public string PhoneNumber { get; set; }
    }
}
