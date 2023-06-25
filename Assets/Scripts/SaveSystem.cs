using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SaveSystemTutorial;
using UnityEngine;

public static class SaveSystem
{
    #region PlayerPrefs
    public static void SaveByPlayerPrefs(string key, object data)
    {
        var json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key,json);
        PlayerPrefs.Save();
    }

    public static string LoadFromPlayerPrefs(string key)
    {
        return PlayerPrefs.GetString(key, null);
    }
    

    #endregion

    
    public static void SaveByJson(string saveFileName, object data)
    {
        var json = JsonUtility.ToJson(data);
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        
        File.WriteAllText(path,json);
        Debug.Log($"Successfully saved data to {path}.");
    
        // try
        // {
        //     File.WriteAllText(path,json);
        //     Debug.Log($"Successfully saved data to {path}.");
        // }
        // catch (System.Exception e)
        // {
        //     Debug.Log($"Failed to save data to{path}. \n{e}");
        // }
    }
    
    public static T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        var json = File.ReadAllText(path);
        var data = JsonUtility.FromJson<T>(json);
        return data;
    }
    
    public static void DeleteSaveFile(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        File.Delete(path);
    }
}
