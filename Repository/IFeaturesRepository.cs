using MyChannel.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Repository
{
    public interface IFeaturesRepository
    {
        List<Feature> GetAllFEATURES();

        Feature GetFEATURESById(int id);

        void CreateFEATURES(Feature feature);

        void UpdateFEATURES(Feature feature);


        Feature DeleteFEATURES(int id);
    }
}
