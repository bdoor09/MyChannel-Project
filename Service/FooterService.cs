using MyChannel.Core;
using MyChannel.Core.Data;
using MyChannel.Core.Repository;
using MyChannel.Core.Service;
using MyChannel.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.Service
{
    public class FooterService: IFooterService
    {
        private readonly IFooterRepository footerRepository;

        public FooterService(IFooterRepository _footerRepository)
        {
            this.footerRepository = _footerRepository;
        }

        public List<Footer> GetAllFooter()
        {
            return footerRepository.GetAllFooter();
        }

        public Footer GetFooterById(int id)
        {
            return footerRepository.GetFooterById(id);
        }

        public void CreateFooter(Footer footer)
        {

            footerRepository.CreateFooter(footer);
        }

        public void UpdateFootert(Footer footer)
        {
            footerRepository.UpdateFootert(footer);
        }
        public Footer DeleteFooter(int id)
        {
            return footerRepository.DeleteFooter(id);
        }
    }
}
