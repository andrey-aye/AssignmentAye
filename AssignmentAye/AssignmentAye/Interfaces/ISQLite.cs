using SQLite.Net;

namespace AssignmentAye.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}