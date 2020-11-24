using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public GameObject canvas;
    private Image img;
    bool playFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        StartCoroutine(FadeInOutCoroutine());
    }

    private void Update()
    {
        if(playFlag == false)
        {
            StartCoroutine(FadeInOutCoroutine());
        }
    }
    IEnumerator FadeInOutCoroutine()
    {
        playFlag = true;

        Color col = img.color;

        while(col.a <= 1)
        {
            col.a += 0.02f;
            img.color = col;
            yield return new WaitForSeconds(0.02f);
        }
        while(col.a >= 0 )
        {
            col.a -= 0.02f;
            img.color = col;
            yield return new WaitForSeconds(0.02f);
        }
        playFlag = false;
        canvas.SetActive(false);
        yield return null;
    }
}
