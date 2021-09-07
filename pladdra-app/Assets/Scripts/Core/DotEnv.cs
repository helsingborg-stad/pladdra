
using System;
using System.IO;
using UnityEngine;


public static class DotEnv
{
    public static void Load(string filePath)
    {
        if (!File.Exists(filePath))
            return;

        foreach (var line in File.ReadAllLines(filePath))
        {
            var parts = line.Split('=');

            if (parts.Length != 2)
                continue;

            Environment.SetEnvironmentVariable(parts[0], parts[1]);
        }
    }

    public static void SetEnvVariables()
    {

        var root = Application.dataPath;
        Debug.Log(Application.dataPath);

        var dotenv = Path.Combine(root, ".env");
        DotEnv.Load(dotenv);
    }
}
