using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using MyChannel.Core.Repository;
using MyChannel.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.Service
{
    public class FeedbackService: IFeedbackService
    {
        private readonly IFeedbackRepository feedbackrepository;
        public FeedbackService(IFeedbackRepository _feedbackrepository)
        {
            this.feedbackrepository = _feedbackrepository;
        }

        public List<Feedback> GetallFeedback()
        {
            return feedbackrepository.GetallFeedback();
        }

        public void CreateFeedback(Feedback feedback)
        {
            feedbackrepository.CreateFeedback(feedback);
        }

        public void UpdateFeedback(Feedback feedback)
        {
            feedbackrepository.UpdateFeedback(feedback);
        }

        public void DelteFeedback(int id)
        {
            feedbackrepository.DelteFeedback(id);
        }

        public Feedback GetFeedbackById(int id)
        {
            return feedbackrepository.GetFeedbackById(id);
        }

        public List<GetFeedbackuser> GetallFeedbackUser()
        {
            return feedbackrepository.GetallFeedbackUser();
        }
        public List<GetFeedbackuser> GetTop4Feedback()
        {
            return feedbackrepository.GetallFeedbackUser();
        }


        public List<top4feedback> topfourfeedback()
        {
            return feedbackrepository.topfourfeedback();
        }
    }
}
