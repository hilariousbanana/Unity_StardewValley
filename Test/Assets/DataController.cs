using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataController : MonoBehaviour
{
    static public DataController instance;
    public Data data = new Data();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Save()
    {
        string jsonData = JsonUtility.ToJson(data);
        string path = Path.Combine(Application.dataPath, "GameData.Json");
        File.WriteAllText(path, jsonData);
    }

    public void Load()
    {
        string path = Path.Combine(Application.dataPath, "GameData.Json");
        string jsonData = File.ReadAllText(path);
        data = JsonUtility.FromJson<Data>(jsonData);
    }
}
