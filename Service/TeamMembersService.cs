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
    public class TeamMembersService: ITeamMembersService
    {

        private readonly ITeamMembersRepository TeamMembersRepository;

        public TeamMembersService(ITeamMembersRepository TeamMembersRepository)
        {
            this.TeamMembersRepository = TeamMembersRepository;
        }

        public List<Teammember> GetAllTeam()
        {
            return TeamMembersRepository.GetAllTeam();

        }

        public Teammember GetTeamById(int id)
        {
            return TeamMembersRepository.GetTeamById(id);
        }

        public void CreateTeam(Teammember teammember)
        {
            TeamMembersRepository.CreateTeam(teammember);
        }

        public void UpdateTeam(Teammember teammember)
        {
            TeamMembersRepository.UpdateTeam(teammember);
        }
        public Teammember DeleteTeam(int id)
        {
            return TeamMembersRepository.DeleteTeam(id);
        }

    }
}
