using System.Threading.Tasks;
using Domain;

namespace Api.Interfaces
{
    public interface IAutodidactService
    {
        Task<bool> IsUserRegistered(UserBotChannel user);
    }
}
