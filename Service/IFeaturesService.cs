using MyChannel.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Service
{
    public interface IFeaturesService
    {
        List<Feature> GetAllFEATURES();

        Feature GetFEATURESById(int id);

        void CreateFEATURES(Feature feature);

        void UpdateFEATURES(Feature feature);


        Feature DeleteFEATURES(int id);
    }
}
