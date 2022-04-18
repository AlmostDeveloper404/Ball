using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoadProgress
{
    
    public static void SaveData(Result? result)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath+"/playerProgress.bn";
        FileStream fileStream = new FileStream(path,FileMode.Create);

        binaryFormatter.Serialize(fileStream,result);
        fileStream.Close();
    }

    public static Result? LoadData()
    {
        string path = Application.persistentDataPath + "/playerProgress.bn";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

            Result? playerProgress= formatter.Deserialize(stream) as Result?;
            stream.Close();

            return playerProgress;
        }
        else
        {
            Debug.Log($"File doesn't found! Path: {path} ");
            return null;
        }
    }

    public static void DeleteData()
    {
        string path = Application.persistentDataPath + "/playerProgress.bn";
        File.Delete(path);
    }
}
