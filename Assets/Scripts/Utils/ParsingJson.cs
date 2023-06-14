using System.IO;
using UnityEngine;

public class ParsingJson : MonoBehaviour
{
    public T GetInfo<T>(string path)
    {
        StreamReader strRead = new StreamReader(path);
        string json = strRead.ReadToEnd();
        return JsonUtility.FromJson<T>(json);
    }

    public void SetInfo<T>(T obj, string path)
    {
        File.WriteAllText(path, JsonUtility.ToJson(obj));      
    }
}