using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSD.Models;

namespace PSD.Factories
{
    public class StationeryFactory
    {
        public static MsStationery CreateStationery(String name, int price)
        {
            MsStationery stat = new MsStationery();
            stat.StationeryName = name;
            stat.StationeryPrice = price;
            return stat;
        }
    }
}