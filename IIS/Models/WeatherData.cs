using System.Xml.Serialization;

namespace IIS.Models
{
    [XmlRoot(ElementName = "DatumTermin")]
    public class DatumTermin
    {

        [XmlElement(ElementName = "Datum")]
        public string Datum { get; set; }

        [XmlElement(ElementName = "Termin")]
        public string Termin { get; set; }
    }

    [XmlRoot(ElementName = "Podatci")]
    public class Podatci
    {

        [XmlElement(ElementName = "Temp")]
        public string Temp { get; set; }

        [XmlElement(ElementName = "Vlaga")]
        public string Vlaga { get; set; }

        [XmlElement(ElementName = "Tlak")]
        public string Tlak { get; set; }

        [XmlElement(ElementName = "TlakTend")]
        public string TlakTend { get; set; }

        [XmlElement(ElementName = "VjetarSmjer")]
        public string VjetarSmjer { get; set; }

        [XmlElement(ElementName = "VjetarBrzina")]
        public string VjetarBrzina { get; set; }

        [XmlElement(ElementName = "Vrijeme")]
        public string Vrijeme { get; set; }

        [XmlElement(ElementName = "VrijemeZnak")]
        public string VrijemeZnak { get; set; }
    }

    [XmlRoot(ElementName = "Grad")]
    public class Grad
    {

        [XmlElement(ElementName = "GradIme")]
        public string GradIme { get; set; }

        [XmlElement(ElementName = "Lat")]
        public string Lat { get; set; }

        [XmlElement(ElementName = "Lon")]
        public string Lon { get; set; }

        [XmlElement(ElementName = "Podatci")]
        public Podatci Podatci { get; set; }

        [XmlAttribute(AttributeName = "autom")]
        public string Autom { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Hrvatska")]
    public class WeatherData
    {

        [XmlElement(ElementName = "DatumTermin")]
        public DatumTermin DatumTermin { get; set; }

        [XmlElement(ElementName = "Grad")]
        public List<Grad> Gradovi { get; set; }
    }
}
