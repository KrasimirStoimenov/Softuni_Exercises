using System.Linq;
using CarShop.Data;

namespace CarShop.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext data;

        public UserService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public bool IsUserMechanic(string userId)
            => this.data.Users
                .Any(u => u.Id == userId && u.IsMechanic);
    }
}
