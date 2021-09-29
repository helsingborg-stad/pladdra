using System.Reflection;
using UnityEngine;
using Newtonsoft.Json;
// Used to save scripts to json that implement ISaveable
// based on https://github.com/UnityTechnologies/UniteNow20-Persistent-Data


public static class SaveDataManager
{
    public static void SaveJsonData(ISaveable saveable)
    {
        if (FileManager.WriteToFile(saveable.FileNameToUseForData(), saveable.ToJson()))
        {
            Debug.Log("Save successful");
        }
        else
        {

            Debug.Log("Save failed");
        }
    }

    public static void LoadJsonData(ISaveable saveable, bool create = false)
    {
        if (FileManager.LoadFromFile(saveable.FileNameToUseForData(), out var json))
        {
            saveable.LoadFromJson(json);
            // Debug.Log("Load complete");
            return;
        }

        if (create)
        {
            SaveJsonData(saveable);
            SaveDataManager.LoadJsonData(saveable);
        }
    }
}

public interface ISaveable
{
    string ToJson();
    void LoadFromJson(string a_Json);
    string FileNameToUseForData();
}


[System.Serializable]
public class Savable<T> : ISaveable where T : class
{
    public string fileName;
    public T instance;

    public void Load()
    {
        if (instance == null || fileName == null)
            return;
        SaveDataManager.LoadJsonData(this, true);
    }
    public void Save()
    {
        if (instance == null || fileName == null)
            return;
        SaveDataManager.SaveJsonData(this);
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(instance);
    }

    public void LoadFromJson(string jsonToLoadFrom)
    {
        T jsonData = JsonConvert.DeserializeObject<T>(jsonToLoadFrom);

        var fields = instance.GetType().GetFields(BindingFlags.Public);
        foreach (var field in jsonData.GetType().GetFields())
        {
            var value = field.GetValue(jsonData);
            if (value != null)
                instance.GetType().GetField(field.Name).SetValue(instance, value);
        }

        var propeties = instance.GetType().GetProperties(BindingFlags.Public);
        foreach (var propety in jsonData.GetType().GetProperties())
        {
            var value = propety.GetValue(jsonData);
            if (value != null)
                instance.GetType().GetProperty(propety.Name).SetValue(instance, value);
        }
    }

    public string FileNameToUseForData()
    {
        return fileName;
    }
}