using System.Collections.Generic;
using System.IO;

public class TXTWritter
{
    private string savePath;

    public void CreateNewFile()
    {
        savePath = Directory.GetCurrentDirectory() + "//save.txt";

        FileStream stream = File.Create(savePath);
        stream.Close();
    }

    public void SaveData(List<string> lines)
    {
        using (StreamWriter writer = new StreamWriter(savePath))
        {
            foreach (string line in lines)
            {
                writer.WriteLine(line);
            }
        }
    }

    public List<string> ReadData()
    {
        if (!File.Exists(savePath))
            return null;

        List<string> dataLines = new List<string>();
        using (StreamReader writer = new StreamReader(savePath))
        {
            dataLines.Add(writer.ReadLine());
        }

        return dataLines;
    }

    public void DeleteTxt() 
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            savePath = null;
        }
    }
}
