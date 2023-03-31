using System.Xml.Schema;
using System.Xml;

namespace IIS.Services
{
    public class XsdValidationService
    {

        public static string Validate()
        {
            string xmlFilePath = @"..\IIS\Assets\ForValidation.xml";
            string xsdFilePath = @"..\IIS\Assets\XsdValidation.xsd";

            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(null, XmlReader.Create(new StringReader(File.ReadAllText(xsdFilePath))));

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = schemas;

            bool isValid = true;
            string validationMessage = "";

            using (XmlReader reader = XmlReader.Create(new StringReader(File.ReadAllText(xmlFilePath)), settings))
            {
                try
                {
                    while (reader.Read()) { }
                }
                catch (XmlException ex)
                {
                    isValid = false;
                    validationMessage = ex.Message;
                }
                catch (XmlSchemaValidationException ex)
                {
                    isValid = false;
                    validationMessage = ex.Message;
                }
            }

            if (isValid)
            {
                return "The XML is valid according to the XSD.";
            }
            else
            {
                return $"The XML is not valid according to the XSD: {validationMessage}";
            }


        }
    }
}
