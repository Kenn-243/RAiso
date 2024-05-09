using RAiso.Models;

namespace RAiso.Repository
{
    public class DatabaseSingleton
    {
        private static DatabaseEntities db;

        public static DatabaseEntities GetInstance()
        {
            if (db == null)
            {
                db = new DatabaseEntities();
            }

            return db;
        }
    }
}