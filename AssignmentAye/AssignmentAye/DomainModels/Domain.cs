using SQLite.Net.Attributes;

namespace AssignmentAye.DomainModels
{
    abstract public class Domain
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}