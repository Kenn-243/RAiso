using RAiso.Models;
using RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Web.Caching;

namespace RAiso.Handlers
{
    public class StationeryHandler
    {
        public static string AddStationery(string stationeryName, int stationeryPrice)
        {
            StationeryRepository.AddStationery(stationeryName, stationeryPrice);
            return "Success";
        }

        public static string RemoveStationery(int stationeryId)
        {
            MsStationery stationery = StationeryRepository.GetStationeryByStationeryId(stationeryId);

            if (stationery != null)
            {
                StationeryRepository.RemoveStationery(stationery);
                return "Success";
            }

            return "Stationery Not Found";
        }

        public static string UpdateStationery(int stationeryId, string stationeryName, int stationeryPrice)
        {
            MsStationery stationery = StationeryRepository.GetStationeryByStationeryId(stationeryId);
            if(stationery != null)
            {
                StationeryRepository.UpdateStationery(stationery, stationeryName, stationeryPrice);
                return "Success";
            }

            return "Stationery Not Found";
        }

        public static MsStationery GetStationeryByStationeryId(int id)
        {
            MsStationery stationery = StationeryRepository.GetStationeryByStationeryId(id);
            if (stationery != null)
            {
                return stationery;
            }

            return null;
        }

        public static List<MsStationery> GetListStationeries()
        {
            List<MsStationery> stationeries = StationeryRepository.GetListStationeries();
            if(stationeries != null)
            {
                return stationeries;
            }

            return null;
        }
    }
}