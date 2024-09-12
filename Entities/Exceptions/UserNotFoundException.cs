namespace Entities.Exceptions
{
    public abstract partial class NotFoundException
    {
        public sealed class UserNotFoundException : NotFoundException
        //kalıtılmayacak class
        {
            public UserNotFoundException(int id) //id alıyor string ile birleştirerel
                : base($" The user with id {id} could not found") //bizden string bekliyordu
            {
            }
        }
    }
}
