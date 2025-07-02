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
    public class FeaturesService: IFeaturesService
    {
        private readonly IFeaturesRepository featuresRepository;

        public FeaturesService(IFeaturesRepository featuresRepository)
        {

            this.featuresRepository = featuresRepository;

        }
        public List<Feature> GetAllFEATURES()
        {
            return featuresRepository.GetAllFEATURES();
        }
        public Feature GetFEATURESById(int id)
        {
            return featuresRepository.GetFEATURESById(id);
        }
        public void CreateFEATURES(Feature feature)
        {
            featuresRepository.CreateFEATURES(feature);
        }
        public void UpdateFEATURES(Feature feature)
        {
            featuresRepository.UpdateFEATURES(feature);
        }
        public Feature DeleteFEATURES(int id)
        {
            return featuresRepository.DeleteFEATURES(id);
        }
    }
}
