using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Service
{
    public interface IResponseService
    {
        List<Respon> GetAllResponses();
        void CreateResponse(Respon respon);
        void UpdateResponse(Respon respon);
        void DeleteResponse(int id);
        Respon GetResponseById(int id);

        List<ResponsDTO> GetResponsByCommentid(int Commentid);
    }
}
