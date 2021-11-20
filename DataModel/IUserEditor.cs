using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR36_2020_POP2021
{
    public interface IUserEditor
    {
        void Modify();
        void SetDeleted();
        void ChangePassword();
    }
}
