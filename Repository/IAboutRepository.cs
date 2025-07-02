using MyChannel.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Repository
{
    public interface IAboutRepository
    {
        List<About> GetAllAbout();

        About GetAboutById(int id);

        void CreateAbout(About about);

        void UpdateAbout(About about);

        About DeleteAbout(int id);
    }
}
