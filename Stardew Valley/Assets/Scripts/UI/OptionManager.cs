using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public GameObject optionPanel;
    public Slider bgmSlider;
    public Slider sfxSlider;
    BGMManager bgm;
    AudioManager sfx;
    // Start is called before the first frame update
    void Start()
    {
        bgm = BGMManager.instance;
        sfx = AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!DataController.instance.data.optionActivated)
            {
                DataController.instance.data.optionActivated = !DataController.instance.data.optionActivated;
                sfx.Play("OpenWindow");
                optionPanel.SetActive(true);
            }
            else
            {
                CloseWindow();
            }
        }
        BGMVolumeCheck();
        SFXVolumeCheck();
    }

    public void CloseWindow()
    {
        DataController.instance.data.optionActivated = !DataController.instance.data.optionActivated;
        sfx.Play("OpenWindow");
        optionPanel.SetActive(false);
    }

    void BGMVolumeCheck()
    {
        bgm.SetVolume(bgmSlider.value);
    }

    void SFXVolumeCheck()
    {
        sfx.SetVolume(sfxSlider.value);
    }
}
