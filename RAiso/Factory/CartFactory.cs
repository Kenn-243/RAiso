using RAiso.Models;

namespace RAiso.Factory
{
    public class CartFactory
    {
        public static Cart Create(int userId, int stationertyId, int quantity)
        {
            return new Cart()
            {
                UserID = userId,
                StationeryID = stationertyId,
                Quantity = quantity
            };
        }
    }
}