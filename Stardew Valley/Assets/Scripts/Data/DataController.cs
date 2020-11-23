using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Data;
using UnityEngine.UIElements;

public sealed class DataController : MonoSingleton<DataController>
{
    public Database data = new Database();
    public GameObject title;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        data.LinkDataToText();
    }

    public void Initialization()
    {
        data.InitializeVariables();
        data.LinkDataToText();
        data.AddItemList();
        player.transform.position = data.playerPos;
    }

    public void NewButton()
    {
        string path = Path.Combine(Application.dataPath, "GameData.Json");
        //if(File.Exists(path))
        //{
        //    string jsonData = File.ReadAllText(path);
        //    data = JsonUtility.FromJson<Database>(jsonData);
        //}
        //else
        //{
        //    data = new Database();
        //}
        data = new Database();
        Initialization();
        int rand = Random.Range(1, 4);
        BGMManager.instance.Play(rand);
        title.SetActive(false);
    }

    public void LoadButton()
    {
        string path = Path.Combine(Application.dataPath, "GameData.Json");
        string jsonData = File.ReadAllText(path);
        data = JsonUtility.FromJson<Database>(jsonData);
        player.transform.position = data.playerPos;
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
        data.playerPos = player.transform.position;
        string jsonData = JsonUtility.ToJson(data);
        string path = Path.Combine(Application.dataPath, "GameData.Json");
        File.WriteAllText(path, jsonData);
        title.SetActive(false);
    }

    public void OnApplicationQuit()
    {
        SaveButton();
    }

    public void UpdateVariable()
    {
        data.playerPos = player.transform.position;
        data.inventory = Inventory.instance.inventoryItemList;
    }
}
