using TRAODOITAILIEU.DataAccessLayer.Data;
using TRAODOITAILIEU.DataAccessLayer.Interfaces;
using TRAODOITAILIEU.DataAccessLayer.ModelFromDB;

namespace TRAODOITAILIEU.DataAccessLayer.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private TDTLContext db;



        public AccountRepository(TDTLContext _db)
        {
            db = _db;
        }
        public void Add(Account account)
        {
            db.Accounts.Add(account);
        }

        public Account GetByEmail(string email)
        {
            var account = db.Accounts.FirstOrDefault(a => a.UserProfiles.Any(up => up.Email == email));
            return account;
        }
        public Account GetByUsername(string username)
        {
            var account = db.Accounts.FirstOrDefault(a => a.Username == username);
            return account;
        }
        public Account GetByUsernamePassword(string username, string password)
        {
            var account = db.Accounts.FirstOrDefault(a => a.Username == username && a.Password == password);
            return account;
        }

        public UserProfile GetProfileByAccountId(int accountId)
        {
            UserProfile u = db.UserProfiles.FirstOrDefault(a => a.AccountId == accountId);
            return u;
        }

        public void AddProfile(UserProfile userProfile)
        {
            db.UserProfiles.Add(userProfile);
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
