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
    public class RoleService: IRoleService
    {
        private readonly IRoleRepository rolerepository;

        public RoleService(IRoleRepository _rolerepository)
        {
            this.rolerepository = _rolerepository;
        }
        public List<Role> GetallRole()
        {
            return rolerepository.GetallRole();
        }
        public void CreateRole(Role role)
        {
             rolerepository.CreateRole(role);
        }

        public void UpdateRole(Role role)
        {
            rolerepository.UpdateRole(role);
        }

        public void DeleteRole(int id)
        {
            rolerepository.DeleteRole(id);
        }

        public Role GetRoleById(int id)
        {
            return rolerepository.GetRoleById(id);
        }
    }
}
