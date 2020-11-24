using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransferManager : MonoSingleton<SceneTransferManager>
{
    public AsyncOperation op;
    public void TransferScene()
    {
         op = SceneManager.LoadSceneAsync("MainScene");
    }
}
