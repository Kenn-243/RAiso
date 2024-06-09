using RAiso.Models;
using RAiso.Repository;
using System.Collections.Generic;

namespace RAiso.Handlers
{
    public class CartHandler
    {
        public static List<Cart> GetListCartsByUserId(int userId)
        {
            List<Cart> carts = CartRepositoriy.GetListCartsByUserId(userId);
            if(carts != null)
            {
                return carts;
            }

            return null;
        }

        public static Cart GetCartByUserIdAndStationeryId(int userId, int stationeryId)
        {
            Cart cart = CartRepositoriy.GetCartByUserIdAndStationeryId(userId, stationeryId);
            if(cart != null)
            {
                return cart;
            }

            return null;
        }

        public static string UpdateCart(int userId, int stationeryId, int quantity)
        {
            Cart cart = CartRepositoriy.GetCartByUserIdAndStationeryId(userId, stationeryId);
            if(cart != null)
            {
                CartRepositoriy.UpdateCart(cart, quantity);
                return "Success";
            }

            return "Cart Not Found";
        }

        public static string RemoveCart(int userId, int stationeryId)
        {
            Cart cart = CartRepositoriy.GetCartByUserIdAndStationeryId(userId, stationeryId);
            if(cart != null)
            {
                CartRepositoriy.RemoveCart(cart);
                return "Success";
            }

            return "Cart Not Found";
        }

        public static string AddToCart(int userId, int stationeryId, int quantity)
        {
            Cart cart = CartRepositoriy.GetCartByUserIdAndStationeryId(userId, stationeryId);
            if (cart == null)
            {
                CartRepositoriy.AddToCart(userId, stationeryId, quantity);
                return "Success";
            }
            return "Item is already in the cart";
        }
    }
}