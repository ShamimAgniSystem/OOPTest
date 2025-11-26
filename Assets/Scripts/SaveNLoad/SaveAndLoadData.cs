using System.IO;
using System.Net;
using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorJsonUtility;

public abstract class SaveAndLoadData : MonoBehaviour
{
    public virtual void SaveData(object objctData, string fileName, string folderPath)
    {
        string fullPath = Path.Combine(Application.dataPath,fileName, folderPath);
        if (!Directory.Exists(fullPath))
        {
            Directory.CreateDirectory(fullPath);
            Debug.Log("Created directory: " + fullPath);
        }

        // Combine the folder path with the file name
        string filePath = Path.Combine(fullPath, fileName);

        // Convert PlayerData to JSON
        string json = JsonUtility.ToJson(objctData);

        // Write JSON to file
        File.WriteAllText(filePath, json);
        Debug.Log("Player data saved to: " + filePath);

        // Refresh the Asset Database (Editor-only)
#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }

    public virtual object  LoadData(string filename,object objctData)
    {
        if (File.Exists(filename))
        {
            File.ReadAllText(filename);
        }
        return objctData;
    }   
}
