using StreamBED.Backend.Helper;
using StreamBED.Backend.Models.ProtocolModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamBED.Frontend.UWP.Models
{
    public class AssessmentDataModel
    {
        private static string newLine = "• ";

        private static Dictionary<Keyword, Dictionary<int, ReferenceImageDataModel>> referenceImage = new Dictionary<Keyword, Dictionary<int, ReferenceImageDataModel>>()
        {
            {
                EpifaunalSubstrateModel.Keywords.Cobble, new Dictionary<int, ReferenceImageDataModel>
                {
                    { 0, new ReferenceImageDataModel("", newLine + "No cobble in the stream\n"
                                                        + newLine + "No vegetation on cobble (least stable)") }
                }
            },

        };

        public static IReadOnlyDictionary<Keyword, Dictionary<int, ReferenceImageDataModel>> ReferenceImage { get { return referenceImage; } }

        
    }
}
