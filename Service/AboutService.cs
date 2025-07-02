using MyChannel.Core.Data;
using MyChannel.Core.Repository;
using MyChannel.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.Service
{
    public class AboutService: IAboutService
    {
        private readonly IAboutRepository aboutRepository;

        public AboutService(IAboutRepository aboutRepository)
        {
            this.aboutRepository = aboutRepository;
        }

        public List<About> GetAllAbout()
        {
            return aboutRepository.GetAllAbout();

        }

        public About GetAboutById(int id)
        {
            return aboutRepository.GetAboutById(id);
        }

        public void CreateAbout(About about)
        {
            aboutRepository.CreateAbout(about);
        }

        public void UpdateAbout(About about)
        {
            aboutRepository.UpdateAbout(about);
        }
        public About DeleteAbout(int id)
        {
            return aboutRepository.DeleteAbout(id);
        }
    }
}
