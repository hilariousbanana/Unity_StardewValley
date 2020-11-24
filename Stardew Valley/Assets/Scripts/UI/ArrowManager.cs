using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        StartCoroutine(MoveCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        CheckNextDay();
    }

    IEnumerator MoveCoroutine()
    {
        while (CheckNextDay() == false)
        {
            tf.rotation = Quaternion.Euler(new Vector3(0, 0, DataController.instance.data.tempRot));
            DataController.instance.data.tempRot -= 0.27f;
            yield return new WaitForSeconds(1.0f);
        }
        DataController.instance.data.tempRot = 170.0f;
    }

    bool CheckNextDay()
    {
        return DataController.instance.data.isNextDay;
    }
}
