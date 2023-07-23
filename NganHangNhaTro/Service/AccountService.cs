using Microsoft.EntityFrameworkCore;
using NganHangNhaTro.Data;
using NganHangNhaTro.Models.DataModels;
using NganHangNhaTro.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace NganHangNhaTro.Service
{
    public interface IAccountService
    {
        bool CheckExist(string loginName);
        Agent GetUser(VM_Login login);
        Task<bool> RegisterUser(VM_Register registerUser);
        bool IsValidUser(int userId, int realEstateId);

    }
    public class AccountService : IAccountService
    {
        private readonly MyDbContext _context; 

        public AccountService (MyDbContext context)
        {
            _context = context;
        }

        public bool CheckExist(string loginName)
        {
            return _context.Agent.Any(x => x.LoginName.Equals(loginName));
        }

        public Agent GetUser(VM_Login login)
        {
            var user = _context.Agent.SingleOrDefault(x => x.LoginName == login.LoginName && x.Password == login.Password);
            return user;
        }

        public bool IsValidUser(int userId, int realEstateId)
        {
            var realEstate = _context.RealEstate.Find(realEstateId);
            var user = _context.Agent.Find(userId);
            if (realEstate != null && user != null)
            {
                return user.LevelId == 1 || userId == realEstate.UserId;
            }
            return false;
        }

        public async Task<bool> RegisterUser(VM_Register registerUser)
        {
            try
            {
                if (registerUser != null)
                {
                    var user = new Agent()
                    {
                        LoginName = registerUser.LoginName,
                        Password = registerUser.Password,
                        AgentName = registerUser.AgentName,
                        LevelId = 3,
                        IsActive = true,
                        PhoneNumber = registerUser.PhoneNumber,
                        ConfirmPhoneNumber = false
                    };
                    _context.Agent.Add(user);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

    }
}
