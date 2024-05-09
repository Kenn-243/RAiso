using RAiso.Factory;
using RAiso.Models;
using System.Collections.Generic;
using System.Linq;

namespace RAiso.Repository
{
    public class CartRepositoriy
    {
        private static DatabaseEntities db = DatabaseSingleton.GetInstance();

        public static List<Cart> GetListCartsByUserId(int userId)
        {
            return db.Carts.Where(x => x.UserID == userId).ToList();
        }

        public static Cart GetCartByUserIdAndStationeryId(int userId, int stationeryId)
        {
            return db.Carts.FirstOrDefault(x => x.UserID == userId && x.StationeryID == stationeryId);
        }

        public static void UpdateCart(Cart cart, int quantity)
        {
            cart.Quantity = quantity;
            db.SaveChanges();
        }

        public static void RemoveCart(Cart cart) 
        {
            db.Carts.Remove(cart);
            db.SaveChanges();
        }

        public static void AddToCart(int userID, int stationeryID, int quantity)
        {
            Cart createCart = CartFactory.Create(userID, stationeryID, quantity);
            db.Carts.Add(createCart);
            db.SaveChanges();
        }
    }
}