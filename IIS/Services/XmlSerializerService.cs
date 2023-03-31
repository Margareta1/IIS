using IIS.Models;
using NuGet.Protocol;
using System.Text;
using System.Xml.Serialization;

namespace IIS.Services
{
    public class XmlSerializerService
    {


        public static void CreateXmlFile(BillboardTopSongs songs)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BillboardTopSongs));
            FileStream fs = File.Create(@"..\IIS\Assets\billboardrecents.xml");
            serializer.Serialize(fs, songs);
            fs.Dispose();
        }

        public static void SaveXmlInput(IFormFile input)
        {
            var inputStream = ReadAsString(input);
            FileStream fs = File.Create(@"..\IIS\Assets\ForValidation.xml");

            StreamWriter s = new StreamWriter(fs);
            s.WriteLine(inputStream);
            s.Close();
            fs.Close();
        }


        public static string ReadAsString(IFormFile file)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(reader.ReadLine());
            }
            return result.ToString();
        }


    }
}
