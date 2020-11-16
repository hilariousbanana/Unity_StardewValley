using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public GameObject optionPanel;
    bool isActivated;
    public Slider bgmSlider;
    public Slider sfxSlider;
    BGMManager bgm;
    AudioManager sfx;
    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
        bgm = BGMManager.instance;
        sfx = AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isActivated)
            {                
                isActivated = !isActivated;
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
        isActivated = !isActivated;
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
