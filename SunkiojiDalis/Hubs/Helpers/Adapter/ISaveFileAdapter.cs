using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using SignalRWebPack.Hubs;
public interface ISaveFileAdapter
{
    void Save(List<Player> data);
    List<string> Read();
    void DeleteSave();
}