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
    GameObject player;

    // Update is called once per frame
    void Update()
    {
        data.LinkDataToText();
    }

    public void Initialization()
    {
        player = FindObjectOfType<MovingObject>().gameObject;
        data.clockHand = FindObjectOfType<ArrowManager>().gameObject;
        data.InitializeVariables();
        data.LinkDataToText();
        data.AddItemList();
        player.transform.position = data.playerPos;
        MovingObject.instance.canWalk = true;
    }

    public void NewButton()
    {
        title.SetActive(false);
        string path = Path.Combine(Application.dataPath, "GameData.Json");
        data = new Database();
        SceneTransferManager.instance.TransferScene();
        Initialization();
        int rand = Random.Range(1, 4);
        BGMManager.instance.Play(rand);
    }

    public void LoadButton()
    {
        title.SetActive(false);
        string path = Path.Combine(Application.dataPath, "GameData.Json");
        string jsonData = File.ReadAllText(path);
        data = JsonUtility.FromJson<Database>(jsonData);
        SceneTransferManager.instance.TransferScene();
        player.transform.position = data.playerPos;
        int rand = Random.Range(1, 4);
        BGMManager.instance.Play(rand);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SaveButton()
    {
        title.SetActive(false);
        data.playerPos = player.transform.position;
        data.bGameStart = false;
        string jsonData = JsonUtility.ToJson(data);
        string path = Path.Combine(Application.dataPath, "GameData.Json");
        File.WriteAllText(path, jsonData);
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
