
namespace Entities.Exceptions
{
    public abstract partial class NotFoundException
    {
        public sealed class JobNotFoundException : NotFoundException
        {
            public JobNotFoundException(int id) 
                : base($" The user with id {id} could not found") 
            {
            }
        }

    }
