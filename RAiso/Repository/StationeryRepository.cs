using RAiso.Factory;
using RAiso.Models;
using System.Collections.Generic;
using System.Linq;

namespace RAiso.Repository
{
    public class StationeryRepository
    {
        private static DatabaseEntities db = DatabaseSingleton.GetInstance();

        public static int GenerateID()
        {
            int newID = db.MsStationeries.Select(x => x.StationeryID).ToList().LastOrDefault();
            if (newID == 0)
            {
                newID = 1;
            }
            else
            {
                newID++;
            }

            return newID;
        }

        public static void AddStationery(string stationeryName, int stationeryPrice)
        {
            int stationeryId = GenerateID();
            MsStationery createStationery = StationeryFactory.Create(stationeryId, stationeryName, stationeryPrice);
            db.MsStationeries.Add(createStationery);
            db.SaveChanges();
        }

        public static void UpdateStationery(MsStationery stationery, string stationeryName, int stationeryPrice)
        { 
            stationery.StationeryName = stationeryName;
            stationery.StationeryPrice = stationeryPrice;
            db.SaveChanges();
        }

        public static void RemoveStationery(MsStationery stationery)
        {
            db.MsStationeries.Remove(stationery);
            db.SaveChanges();
        }

        public static MsStationery GetStationeryByStationeryId(int stationeryId)
        {
            return db.MsStationeries.FirstOrDefault(x => x.StationeryID == stationeryId);
        }

        public static List<MsStationery> GetListStationeries()
        {
            return db.MsStationeries.ToList();
        }
    }
}