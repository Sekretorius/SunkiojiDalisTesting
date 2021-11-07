using System.Collections.Generic;
using SignalRWebPack.Hubs;
using Newtonsoft.Json;
public class XMLAdapter : ISaveFileAdapter
{
    public XMLWritter xmlWritter;

    public XMLAdapter(XMLWritter xmlWritter)
    {
        this.xmlWritter = xmlWritter;
    }

    public void DeleteSave()
    {
        xmlWritter.DeleteXml();
    }

    public List<string> Read()
    {
        Dictionary<string, string> data = xmlWritter.ReadXmlFile();
        return new List<string>(data.Values);
    }

    public void Save(List<Player> data)
    {
        Dictionary<string, string> convertedData = new Dictionary<string, string>();

        foreach(Player player in data)
        {
            convertedData.Add("id_" + player.getId().ToString(), Newtonsoft.Json.JsonConvert.SerializeObject(player));
        }

        xmlWritter.Save(convertedData);
    }
}
