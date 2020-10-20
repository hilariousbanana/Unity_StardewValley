using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    public enum TSTATE
    {
        PLANTABLE,      //밭에 씨앗을 심을 수 있는 상태
        ACTIVATED,      //플레이어 반경 내에 타일이 있는 상태
        STAGE1,
        STAGE2,
        STAGE3,
        STAGE4,
        STAGE5          //Crop. 추수가 가능한 상태
    }
    public TSTATE tileState;

    private GameObject player;
    public Image noticePanel;
    public Button butn;

    private float distance;
    private int seedType;
    public int tileNumber;
    private int slotNumber =0;

    private int plantedDay = 0;
    private int plantedHour = 0;

    private bool isPlanted = false;
    private bool isStarted = false;
    private bool isReaped = false;
    private bool isReset = false;
    private bool dayAfter = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MovingObject>().gameObject;
        tileState = TSTATE.PLANTABLE;
    }

    void Update()
    {
        slotNumber = Database.instance.chosenSlot;

        if (!isPlanted) //심은게 없는 경우
        {
            if (GetDistance() <=234.0f) //수치 수정해야함.
            {
                ChangeState(TSTATE.ACTIVATED);
            }
            else
            {
                ChangeState(TSTATE.PLANTABLE);
            }
        }
        else //있는 경우
        {
            if(!isStarted)
            {
                isStarted = true;
                plantedDay = Database.instance.day;
                plantedHour = Database.instance.hour;

                CropTimer(plantedDay, plantedHour);
            }
        }

        if (Database.instance.day == 1 && !isReset) //새로운 달로 넘어가면 타일을 모두 리셋해줌.
        {
            ResetTile();
        }
    }

    void ChangeState(TSTATE _state)
    {
        tileState = _state;

        switch(_state)
        {
            case TSTATE.PLANTABLE:
                break;
            case TSTATE.ACTIVATED:
                break;
            case TSTATE.STAGE1:
                break;
            case TSTATE.STAGE2:
                break;
            case TSTATE.STAGE3:
                break;
            case TSTATE.STAGE4:
                break;
            case TSTATE.STAGE5:
                {
                    if (isReaped)
                        ChangeState(TSTATE.PLANTABLE);
                }
                break;
        }
    }

    float GetDistance()
    {
        distance = Vector3.Distance(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
                                                 new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z));
        return distance;
    }

    void CropTimer(int _day, int _hour)
    {
        switch(seedType)
        {
            case 10001:
                {
                    if(_hour <= 20)
                    {
                        
                    }
                    else
                    {

                    }
                }
                break;
            case 10002:
                break;
            case 10003:
                break;
            case 10004:
                break;
            case 10005:
                break;
        }
    }

    public void Clicked()
    {
        //Database.instance.chosenTile = tileNumber;

        if (tileState == TSTATE.STAGE5) //추수
        {
            isReaped = true;
            isPlanted = false;
            isStarted = false;
        }
        else if(tileState == TSTATE.ACTIVATED && Inventory.instance.isEmpty == false) //심기
        {
            if (Inventory.instance.inventoryItemList[slotNumber].itemType == Item.ItemType.Seed)
            {
                seedType = Inventory.instance.inventoryItemList[slotNumber].itemID;
                ChangeState(TSTATE.STAGE1);
                Debug.Log("is Clicked. And SeedType is" + seedType);
                butn.image.sprite = Resources.Load($"ItemIcon/{seedType}_{tileState}", typeof(Sprite)) as Sprite;
                Inventory.instance.UseAnItem(slotNumber);
                isPlanted = true;
            }
            else
            {
                noticePanel.sprite = Resources.Load("Sprites/" + "SeedOnly_Notice", typeof(Sprite)) as Sprite;
                noticePanel.gameObject.SetActive(true);
            }
        }
        else if(tileState == TSTATE.PLANTABLE && Inventory.instance.isEmpty == false) //너무 멀리 있음
        {
            noticePanel.sprite = Resources.Load("Sprites/" + "FarTile_Notice", typeof(Sprite)) as Sprite;
            noticePanel.gameObject.SetActive(true);
        }
    }

    void ResetTile()
    {
        isReset = true;
        Color temp = butn.image.color;
        temp.a = 0;
        butn.image.color = temp;
    }

    //IEnumerator CheckTimer()
    //{
    //    yield return new WaitUntil();
    //}

    void UpdateVariable()
    {
        //if()
    }
}
