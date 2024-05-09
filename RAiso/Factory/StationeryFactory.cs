using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Factory
{
    public class StationeryFactory
    {
        public static MsStationery Create(int stationeryId, string stationeryName, int stationeryPrice)
        {
            return new MsStationery()
            {
                StationeryID = stationeryId,
                StationeryName = stationeryName,
                StationeryPrice = stationeryPrice
            };
        }
    }
}