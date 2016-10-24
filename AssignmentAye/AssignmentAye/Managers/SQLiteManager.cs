using System.Collections.Generic;
using System.Linq;
using AssignmentAye.DomainModels;
using AssignmentAye.Interfaces;

namespace AssignmentAye.Managers
{
    public class SQLiteManager : IDbManager
    {
        private ISQLite _iconn;

        public SQLiteManager(ISQLite iconnection)
        {
            _iconn = iconnection;
        }

        public void Initialize<T>()
        {
            using (var conn = _iconn.GetConnection())
            {
                conn.CreateTable<T>();
            }
        }

        public void AddEntry<T>(T entry)
        {
            using (var conn = _iconn.GetConnection())
            {
                conn.DeleteAll<T>();
                conn.Insert(entry);
            }
        }

        public T GetRecentLoggedUser<T>() where T : Domain
        {
            using (var conn = _iconn.GetConnection())
            {
                var entries = conn.Table<T>().ToList().FirstOrDefault();
                return entries;
            }
        }
        
        public void UpdateEntry<T>(T entry)
        {
            using (var conn = _iconn.GetConnection())
            {
                conn.Update(entry);
            }
        }







        public List<T> GetAllEntries<T>() where T : Domain
        {
            using (var conn = _iconn.GetConnection())
            {
                var entries = conn.Table<T>().ToList();
                return entries;
            }
        }

    }
}



