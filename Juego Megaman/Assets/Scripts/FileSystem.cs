using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class FileSystem<T>
    where T : class
{
    public void Save(T data)
    {
        string fileName = Application.persistentDataPath + "/player.bin";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(fileName, FileMode.Create);
        formatter.Serialize(stream, JsonUtility.ToJson(data));
        stream.Close();
    }

    public T Load()
    {
        string fileName = Application.persistentDataPath + "/player.bin";
        if (File.Exists(fileName))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(fileName, FileMode.Open);
            T data = JsonUtility.FromJson<T>(formatter.Deserialize(stream).ToString());
            stream.Close();
            return data;
        }
        return default(T);
    }
}
