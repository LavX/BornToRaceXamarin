using SQLite;

namespace BornToRace
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

