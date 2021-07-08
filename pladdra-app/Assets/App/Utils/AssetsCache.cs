using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

// Use this class to store user session data to use for refreshing tokens
[System.Serializable]
public class AssetsCache : ISaveable

{
    public List<Pladdra.API.Types.Asset> items = new List<Pladdra.API.Types.Asset>();

    public string updatedAt;

    public AssetsCache() { }

    public string ToJson()
    {

        return JsonConvert.SerializeObject(this);
    }

    public void LoadFromJson(string jsonToLoadFrom)
    {
        AssetsCache jsonData = JsonConvert.DeserializeObject<AssetsCache>(jsonToLoadFrom);
        var fields = this.GetType().GetFields();
        foreach (var field in jsonData.GetType().GetFields())
        {
            var value = field.GetValue(jsonData);
            if (value != null)
                this.GetType().GetField(field.Name).SetValue(this, value);
        }
    }

    public string FileNameToUseForData()
    {
        return "assets.json";
    }
}
