using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

    private DateTime plantedTime;

    private bool isPlanted = false;
    private bool isStarted = false;
    private bool isReaped = false;

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
            if (GetDistance() <= 315.5)
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
                plantedTime = System.DateTime.Now;
                isStarted = true;
            }
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

    void CropTimer()
    {

        switch(seedType)
        {
            case 10001:
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
        }
        else if(tileState == TSTATE.ACTIVATED) //심기
        {
            if (Inventory.instance.inventoryItemList[slotNumber].itemType == Item.ItemType.Seed)
            {
                seedType = Inventory.instance.inventoryItemList[slotNumber].itemID;
                tileState = TSTATE.STAGE1;
                Debug.Log("is Clicked. And SeedType is" + seedType);
                butn.image.sprite = Resources.Load($"ItemIcon/{seedType}_{tileState}", typeof(Sprite)) as Sprite;
                Inventory.instance.UseAnItem(slotNumber);
            }
            else
            {
                noticePanel.sprite = Resources.Load("Sprites/" + "SeedOnly_Notice", typeof(Sprite)) as Sprite;
                noticePanel.gameObject.SetActive(true);
            }
        }
        else if(tileState == TSTATE.PLANTABLE)
        {
            noticePanel.sprite = Resources.Load("Sprites/" + "FarTile_Notice", typeof(Sprite)) as Sprite;
            noticePanel.gameObject.SetActive(true);
        }
    }
}
