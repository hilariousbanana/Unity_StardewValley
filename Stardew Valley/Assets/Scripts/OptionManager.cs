using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    public GameObject optionPanel;
    bool isActivated;
    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isActivated)
            {                
                isActivated = !isActivated;
                optionPanel.SetActive(true);
            }
            else
            {
                CloseWindow();
            }
        }
    }

    public void CloseWindow()
    {
        isActivated = !isActivated;
        optionPanel.SetActive(false);
    }
}
