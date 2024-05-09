using RAiso.Handlers;
using RAiso.Models;
using System.Collections.Generic;

namespace RAiso.Controllers
{
    public class CartController
    {
        public static List<Cart> GetListCartsByUserId(int userId)
        {
            return CartHandler.GetListCartsByUserId(userId);
        }

        public static Cart GetCartByUserIdAndStationeryId(int userId, int stationeryId)
        {
            return CartHandler.GetCartByUserIdAndStationeryId(userId, stationeryId);
        }

        public static string UpdateCart(int userId, int stationeryId, int quantity)
        {
            if(quantity <= 0)
            {
                return "Must be filled and more than 0";
            }
            
            return CartHandler.UpdateCart(userId, stationeryId, quantity);
        }

        public static string RemoveCart(int userId, int stationeryId)
        {
            return CartHandler.RemoveCart(userId, stationeryId);
        }

        public static string AddToCart(int userId, int stationeryId, int quantity)
        {
            if(quantity <= 0)
            {
                return "Must be filled and more than 0";
            }

            return CartHandler.AddToCart(userId, stationeryId, quantity);
        }
    }
}