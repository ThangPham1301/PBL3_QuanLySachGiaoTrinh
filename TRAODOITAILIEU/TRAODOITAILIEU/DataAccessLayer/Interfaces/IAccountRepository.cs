using TRAODOITAILIEU.DataAccessLayer.ModelFromDB;

namespace TRAODOITAILIEU.DataAccessLayer.Interfaces
{
    public interface IAccountRepository
    {


        public Account GetByEmail(string email);
        public Account GetByUsernamePassword(string username, string password);
        public Account GetByUsername(string username);
        public UserProfile GetProfileByAccountId(int accountId);
        public void Add(Account account);
        public void AddProfile(UserProfile userProfile);
        void SaveChanges();
    }
}
