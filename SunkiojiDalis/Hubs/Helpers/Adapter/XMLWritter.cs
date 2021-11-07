using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

public class XMLWritter
{
    private string savePath = null;
    public Dictionary<string, string> ReadXmlFile()
    {
        if (File.Exists(savePath))
        {
            using(StreamReader read = new StreamReader(savePath))
            {
                read.ReadLine();
                XElement rootElement = XElement.Parse(read.ReadToEnd());
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (var el in rootElement.Elements())
                {
                    dict.Add(el.Name.LocalName, el.Value);
                }
                return dict;
            }
        }

        return null;
    }

    public void Save(Dictionary<string, string> data) 
    {
        XElement el = new XElement("data", data.Select(kv => new XElement(kv.Key, kv.Value)));

        XElement root = new XElement("root");
        savePath = Directory.GetCurrentDirectory() + "//save.xml";

        root.Add(el);

        root.Save(savePath);

    }

    public void DeleteXml()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            savePath = null;
        }
    }

}