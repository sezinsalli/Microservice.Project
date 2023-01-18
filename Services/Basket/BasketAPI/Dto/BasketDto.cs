using System.Collections.Generic;
using System.Linq;

namespace BasketAPI.Dto
{
    public class BasketDto
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public List<BasketItemDto> basketItems { get; set; }
        public decimal TotalPrice
        {
            get => basketItems.Sum(x => x.Price * x.Quantity);
        }

    }
}
