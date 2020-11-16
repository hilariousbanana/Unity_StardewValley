using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Data;
using UnityEngine.UIElements;

public class DataController : MonoBehaviour
{
    static public DataController instance;
    public Database data = new Database();
    public GameObject title;

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
    void Start()
    {
        data.InitializeVariables();
        data.LinkDataToText();
        data.AddItemList();
    }

    // Update is called once per frame
    void Update()
    {
        data.LinkDataToText();
    }

    public void NewButton()
    {
        string path = Path.Combine(Application.dataPath, "GameData.Json");
        if(File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            data = JsonUtility.FromJson<Database>(jsonData);
        }
        else
        {
            data = new Database();
        }

        int rand = Random.Range(1, 4);
        BGMManager.instance.Play(rand);
        title.SetActive(false);
    }

    public void LoadButton()
    {
        data.playerPos = MovingObject.instance.UpdatePos();
        string path = Path.Combine(Application.dataPath, "GameData.Json");
        string jsonData = File.ReadAllText(path);
        data = JsonUtility.FromJson<Database>(jsonData);
        int rand = Random.Range(1, 4);
        BGMManager.instance.Play(rand);
        title.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SaveButton()
    {
        data.playerPos = MovingObject.instance.UpdatePos();
        string jsonData = JsonUtility.ToJson(data);
        string path = Path.Combine(Application.dataPath, "GameData.Json");
        File.WriteAllText(path, jsonData);
        title.SetActive(false);
    }

    public void OnApplicationQuit()
    {
        SaveButton();
    }
}
