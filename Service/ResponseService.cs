using Azure;
using MyChannel.Core.Data;
using MyChannel.Core.DTO;
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
    public class ResponseService: IResponseService
    {
        private readonly IResponseRepository responseRepository;

        public ResponseService(IResponseRepository _responseRepository)
        {
            this.responseRepository = _responseRepository;
        }

        public List<Respon> GetAllResponses()
        {
            return responseRepository.GetAllResponses();
        }

        public void CreateResponse(Respon respon)
        {
            responseRepository.CreateResponse(respon);
        }

        public void UpdateResponse(Respon respon)
        {
            responseRepository.UpdateResponse(respon);
        }

        public void DeleteResponse(int id)
        {
            responseRepository.DeleteResponse(id);
        }

        public Respon GetResponseById(int id)
        {
            return responseRepository.GetResponseById(id);
        }

        public List<ResponsDTO> GetResponsByCommentid(int Commentid)
        {
            return responseRepository.GetResponsByCommentid(Commentid);
        }
    }
}
