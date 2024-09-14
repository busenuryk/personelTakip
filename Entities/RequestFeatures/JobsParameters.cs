
namespace Entities.RequestFeatures
{
    public class JobsParameters : RequestParameters
    {
        public string? SearchTerm { get; set; }
        public JobsParameters()
        {
            OrderBy = "id";
        }
    }
}
