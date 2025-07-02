using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Service
{
    public interface IFeedbackService
    {
        List<Feedback> GetallFeedback();
        void CreateFeedback(Feedback feedback);
        void UpdateFeedback(Feedback feedback);
        void DelteFeedback(int id);
        Feedback GetFeedbackById(int id);

        public List<GetFeedbackuser> GetallFeedbackUser();
        public List<GetFeedbackuser> GetTop4Feedback();

        List<top4feedback> topfourfeedback();
    }
}
