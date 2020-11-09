using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    float tempRot;
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
        Database.instance.tempRot = 170.0f;
        while (CheckNextDay() == false)
        {
            tf.rotation = Quaternion.Euler(new Vector3(0, 0, Database.instance.tempRot));
            Database.instance.tempRot -= 0.27f;
            yield return new WaitForSeconds(1.0f);
        }
        Database.instance.tempRot = 170.0f;
    }

    bool CheckNextDay()
    {
        return Database.instance.isNextDay;
    }
}
