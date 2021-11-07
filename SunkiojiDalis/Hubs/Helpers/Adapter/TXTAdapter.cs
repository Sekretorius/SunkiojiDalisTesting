using System.Collections.Generic;
using System;
using SignalRWebPack.Hubs;
public class TXTAdapter : ISaveFileAdapter
{
    public TXTWritter txtWritter;
    public TXTAdapter(TXTWritter txtWritter)
    {
        this.txtWritter = txtWritter;
    }

    public void DeleteSave()
    {
        txtWritter.DeleteTxt();
    }

    public List<string> Read()
    {
        return txtWritter.ReadData();
    }

    public void Save(List<Player> data)
    {
        txtWritter.CreateNewFile();
        List<string> convertedData = new List<string>();
        foreach(Player player in data)
        {
            convertedData.Add(Newtonsoft.Json.JsonConvert.SerializeObject(player));
        }
        txtWritter.SaveData(convertedData);
    }
}