using PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD.Factories
{
    public class CartFactory
    {
        public static Cart CreateCart(int userId, int stationeryId, int quantity)
        {
            Cart cart = new Cart();
            cart.UserID = userId;
            cart.StationeryID = stationeryId;
            cart.Quantity = quantity;
            return cart;
        }
    }
}