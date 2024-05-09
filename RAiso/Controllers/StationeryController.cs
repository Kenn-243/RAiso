using RAiso.Handlers;
using RAiso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Controllers
{
    public class StationeryController
    {
        public static string AddStationery(string stationeryName, int stationeryPrice)
        {
            if (stationeryName.Length < 3 || stationeryName.Length > 50)
            {
                return "Stationery Name must be between 3 - 50 characters";
            }
            else if (stationeryPrice < 2000)
            {
                return "Stationery Price must be greater or equal to 2000";
            }
            
            return StationeryHandler.AddStationery(stationeryName, stationeryPrice);
        }

        public static string RemoveStationery(int stationeryId)
        {
            return StationeryHandler.RemoveStationery(stationeryId);
        }

        public static string UpdateStationery(int stationeryId, string stationeryName, int stationeryPrice)
        {
            if (stationeryName.Length < 3 || stationeryName.Length > 50)
            {
                return "Stationery Name must be between 3 - 50 characters";
            }
            else if (stationeryPrice < 2000)
            {
                return "Stationery Price must be greater or equal to 2000";
            }

            return StationeryHandler.UpdateStationery(stationeryId, stationeryName, stationeryPrice);
        }

        public static MsStationery GetStationeryByStationeryId(int id)
        {
            return StationeryHandler.GetStationeryByStationeryId(id);
        }

        public static List<MsStationery> GetListStationeries()
        {
            return StationeryHandler.GetListStationeries();
        }
    }
}