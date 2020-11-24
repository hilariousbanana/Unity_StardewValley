using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Data;
using UnityEngine.UIElements;

public sealed class DataController : MonoSingleton<DataController>
{
    public GameObject titlePanel;
    public GameObject fadePanel;
    public Database data;

    private void Update()
    {
        data.LinkDataToText();

        if(data.isNextDay)
        {
            SaveData();
        }
    }

    void CreateNewData()
    {
        data = new Database();
        data.InitData();
    }

    void LoadData()
    {
        string filePath = Path.Combine(Application.dataPath, "GameData.Json");
        string FromJsonData = File.ReadAllText(filePath);
        data = JsonUtility.FromJson<Database>(FromJsonData);
        data.DeserializeObject();
    }

    void SaveData()
    {
        string ToJsonData = JsonUtility.ToJson(data);
        string filePath = Path.Combine(Application.dataPath, "GameData.Json");
        File.WriteAllText(filePath, ToJsonData);
    }

    public void NewButton()
    {
        CreateNewData();
        AudioManager.instance.Play("Clilck");
        fadePanel.SetActive(true);
        titlePanel.SetActive(false);
        int rand = Random.Range(1, 4);
        BGMManager.instance.Play(rand);
        SceneTransferManager.instance.TransferScene();
    }

    public void LoadButton()
    {
        LoadData();
        AudioManager.instance.Play("Clilck");
        fadePanel.SetActive(true);
        titlePanel.SetActive(false);
        int rand = Random.Range(1, 4);
        BGMManager.instance.Play(rand);
        SceneTransferManager.instance.TransferScene();
    }

    public void ExitButton()
    {
        AudioManager.instance.Play("Clilck");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

    public void SaveAndExitButton()
    {
        AudioManager.instance.Play("Clilck");
        SaveData();
        ExitButton();
    }
}
