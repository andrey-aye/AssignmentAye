using System.Collections.Generic;
using AssignmentAye.DomainModels;

namespace AssignmentAye.Interfaces
{
    public interface IDbManager
    {
        void Initialize<T>();
        void AddEntry<T>(T entry);
        void UpdateEntry<T>(T entry);
        T GetRecentLoggedUser<T>() where T : Domain;
        List<T> GetAllEntries<T>() where T : Domain;
    }
}