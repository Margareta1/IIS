using System.Xml.Schema;
using System.Xml;
using System.Xml.Linq;
using Commons.Xml.Relaxng;

namespace IIS.Services
{
    public class RngValidationService
    {

        public static string Validate()
        {

            string rngFilePath = @"..\IIS\Assets\schema.rng";
            string xmlFilePath = @"..\IIS\Assets\ForValidation.xml";
            string validationMessage = "";

            using (XmlReader instance = new XmlTextReader(xmlFilePath))
            using (XmlReader grammar = new XmlTextReader(rngFilePath))
            using (var reader = new RelaxngValidatingReader(instance, grammar))
            {
                try
                {
                    while (reader.Read()) { }
                    validationMessage = "The XML is valid according to the RNG.";

                }
                catch (Exception ex)
                {
                    validationMessage = ex.Message;
                }

            }
            return validationMessage;

        }
    }
}
