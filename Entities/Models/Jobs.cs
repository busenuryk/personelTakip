
namespace Entities.Models
{
    public class Jobs
    {
        public int JobsId { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }

    }
}
