using BCrypt.Net;
using CSI_Platform.Entities.Model;
using CSI_Platform.Repository.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI_Platform.Repository.Repository
{
    public class HomeRepository : Repository<User>, IHomeRepository
    {
        private CiContext _ciContext;

        public HomeRepository(CiContext ctx) : base(ctx)
        {
            _ciContext = ctx;
        }
        public void Update(User user)
        {
            _ciContext.Users.Update(user);
        }

        public void save()
        {
            _ciContext.SaveChanges();
        }

        public string Login(string email, string password)
        {
            var obj = _ciContext.Users.FirstOrDefault(x => x.Email == email);
            if (obj == null || !BCrypt.Net.BCrypt.Verify(password, obj.Password))
            {
                return "Invalid";
            }
            else
            {
                return "Valid";
            }
        }
    }
}
