using MyChannel.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Repository
{
    public interface IHomeRepository
    {
        List<Home> GetAllHome();

        Home GetHomeById(int id);

        void CreateHome(Home home);

        void UpdateHome(Home home);

        Home DeleteHome(int id);
    }
}
