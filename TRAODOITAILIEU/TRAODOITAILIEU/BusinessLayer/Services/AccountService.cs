using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TRAODOITAILIEU.BusinessLayer.DTOs;
using TRAODOITAILIEU.BusinessLayer.Interfaces;
using TRAODOITAILIEU.DataAccessLayer.Interfaces;
using TRAODOITAILIEU.DataAccessLayer.ModelFromDB;

namespace TRAODOITAILIEU.BusinessLayer.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository userRepo;
        private readonly IConfiguration _config;
        public static int account_id = 0;
        public AccountService(IAccountRepository userrepo)
        {
            userRepo = userrepo;
        }
        public UserDTO Register(RegisterRequest request)
        {
            var existingUser1 = userRepo.GetByEmail(request.Email);
            var existingUser2 = userRepo.GetByUsername(request.UserName);
            if (existingUser1 != null || existingUser2 != null)
            {
                throw new Exception("Account already exists");
            }

            var account = new Account
            {
                Username = request.UserName,
                Password = request.Password,
                Role = 1
            };
            userRepo.Add(account);
            UserProfile profile;
            try
            {
                userRepo.SaveChanges();

                profile = new UserProfile
                {
                    AccountId = account.AccountId,
                    FullName = request.FullName,
                    Email = request.Email,
                    Phone = request.PhoneNumber,
                    Birth = request.Birth,
                    Address = request.Address
                };

                userRepo.AddProfile(profile);
                userRepo.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException?.Message);
                throw;
            }

            return new UserDTO
            {
                UserName = account.Username,
                Email = profile.Email,
                PhoneNumber = profile.Phone
            };
        }
        public UserDTO Login(LoginRequest request)
        {
            Account acc = userRepo.GetByUsernamePassword(request.username, request.password);
            if (acc != null)
            {
                var userProfile = userRepo.GetProfileByAccountId(acc.AccountId);
                account_id = acc.AccountId;
                return new UserDTO
                {
                    UserName = acc.Username,
                    Email = userProfile.Email,
                    PhoneNumber = userProfile.Phone
                };
            }
            else
            {
                throw new Exception("Login failed!");
            }
        }



    }
}
