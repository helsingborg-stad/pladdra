using UnityEngine;
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