using CSI_Platform.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI_Platform.Repository.Repository.IRepository
{
    public interface IHomeRepository : IRepository<User>
    {
        void Update(User user);

        String Login(string email, string password);
        void save();
    }
}
