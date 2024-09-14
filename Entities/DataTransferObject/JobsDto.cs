
namespace Entities.DataTransferObject
{
    public class JobsDto
    {
        public int JobsId { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}
