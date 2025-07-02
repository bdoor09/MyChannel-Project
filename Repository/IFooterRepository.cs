using MyChannel.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Repository
{
    public interface IFooterRepository
    {
        List<Footer> GetAllFooter();

        Footer GetFooterById(int id);

        void CreateFooter(Footer footer);

        void UpdateFootert(Footer footer);

        Footer DeleteFooter(int id);
    }

}
