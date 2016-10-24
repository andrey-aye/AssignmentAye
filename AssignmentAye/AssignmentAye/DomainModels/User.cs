namespace AssignmentAye.DomainModels
{
    public class User : Domain
    {
        public string Name { get; set; }
        public string Pass { get; set; }
        public bool IsLogged { get; set; }
    }
}