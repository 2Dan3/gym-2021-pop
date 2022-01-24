using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR36_2020_POP2021.Services
{
    public interface IUserService
    {
        void ReadUsers(string filename);
        void SaveUsers(string filename);
        void DeleteUser(string jmbg);
        void ReadAddresses(string filename);
        void SaveAddresses(string filename);
    }
}
