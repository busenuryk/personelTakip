namespace Entities.RequestFeatures
{
    public class UserParameters : RequestParameters
    {
        public string? SearchTerm { get; set; }
        public UserParameters()
        {
            OrderBy = "id";
        }
    }
}
