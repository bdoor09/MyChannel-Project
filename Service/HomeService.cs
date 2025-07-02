using MyChannel.Core;
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
    public class HomeService: IHomeService
    {
        private readonly IHomeRepository homeRepository;

        public HomeService(IHomeRepository homeRepository)
        {
            this.homeRepository = homeRepository;
        }

        public List<Home> GetAllHome()
        {
            return homeRepository.GetAllHome();

        }

        public Home GetHomeById(int id)
        {
            return homeRepository.GetHomeById(id);
        }

        public void CreateHome(Home home)
        {
            homeRepository.CreateHome(home);
        }

        public void UpdateHome(Home home)
        {
            homeRepository.UpdateHome(home);
        }
        public Home DeleteHome(int id)
        {
            return homeRepository.DeleteHome(id);
        }
    }
}
