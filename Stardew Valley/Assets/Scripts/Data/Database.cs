using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using System;

[System.Serializable]
public class Database
{
    //public static Database instance;


    //플레이어 관련 var
    public float playerSpeed;
    public float runSpeed;
    public bool coffeeDrink;
    public Vector3 playerPos;

    //아이템 관련 var
    public List<Item> itemList = new List<Item>();
    public bool sellEnabled = false;
    public int chosenItemID;
    public int chosenSlot = 0;
    public int chosenTile = 0;
    public bool inFarm = false;
    public bool isActivated = false;
    public bool tileActivated = false;
    public bool noticeActivated = false;
    public bool storeActivated = false;

    //시간 관련 var
    public enum SEASON
    {
        SPRING, SUMMER, FALL, WINTER
    }

    public GameObject clockHand;
    public float tempRot;
    public int minute;
    public int hour;
    public int day;
    public int sleepHour;
    public bool isSleeping;
    public bool reset;
    public bool sleepException;
    public SEASON season = SEASON.SPRING;

    public string minute_Text;
    public string hour_Text;
    public string day_Text;
    public string season_Text;

    public bool isNextDay;

    //플레이어 관련 var
    public const int MaxHp = 100;
    public int curHp = MaxHp;
    public int gold;
    public string gold_Text;


    //그 외
    public int curMapNum;

    //데이터 - UI텍스트 연동
    public void LinkDataToText()
    {
        minute_Text = minute.ToString("D2");
        hour_Text = hour.ToString("D2");
        day_Text = day.ToString();

        switch (season)
        {
            case SEASON.SPRING:
                season_Text = "spring";
                break;
            case SEASON.SUMMER:
                season_Text = "summer";
                break;
            case SEASON.FALL:
                season_Text = "fall";
                break;
            case SEASON.WINTER:
                season_Text = "winter";
                break;
        }

        gold_Text = gold.ToString();
    }

    //변수 초기화
    public void InitializeVariables()
    {
        minute = 0;
        hour = 7;
        day = 1;

        curHp = MaxHp;

        season = SEASON.SPRING;
        gold = 3000;

        isSleeping = false;
        reset = false;
        isNextDay = false;

        curMapNum = 0;

        //playerSpeed = 0.08f;
        //runSpeed = 0.05f;
        playerSpeed = 1f;
        runSpeed = 0.5f;
    }

    //아이템 관련 func
    public void AddItemList()
    {
        //Seed
        itemList.Add(new Item(10001, "컬리플라워 씨앗", "컬리플라워 씨앗. 자라는 데 6일이 걸린다.", Item.ItemType.Seed));
        itemList.Add(new Item(10002, "멜론 씨앗", "멜론 씨앗. 자라는 데 10일이 걸린다.", Item.ItemType.Seed));
        itemList.Add(new Item(10003, "감자 씨앗", "감자 씨앗. 자라는 데 5일이 걸린다.", Item.ItemType.Seed));
        itemList.Add(new Item(10004, "케일 씨앗", "케일 씨앗. 자라는 데 5일이 걸린다.", Item.ItemType.Seed));
        itemList.Add(new Item(10005, "밀 씨앗", "밀 씨앗. 자라는 데 4일이 걸린다.", Item.ItemType.Seed));

        //Crop
        itemList.Add(new Item(20001, "컬리플라워", "컬리플라워. HP를 8만큼 회복시킨다.", Item.ItemType.Crop));
        itemList.Add(new Item(20002, "멜론", "멜론. HP를 15만큼 회복시킨다.", Item.ItemType.Crop));
        itemList.Add(new Item(20003, "감자", "감자. HP를 5만큼 회복시킨다.", Item.ItemType.Crop));
        itemList.Add(new Item(20004, "케일", "케일. HP를 5만큼 회복시킨다.", Item.ItemType.Crop));
        itemList.Add(new Item(20005, "밀", "밀. HP를 3만큼 회복시킨다.", Item.ItemType.Crop));

        //Food
        itemList.Add(new Item(30001, "샐러드", "샐러드. 야채로 이루어져 HP를 25만큼 회복시킨다.", Item.ItemType.Food));
        itemList.Add(new Item(30002, "커피", "커피. 이동속도가 하루동안 일정 증가한다.", Item.ItemType.Food));
        itemList.Add(new Item(30003, "핑크 케이크", "핑크 케이크. 멜론과 밀로 제작 할 수 있으며 HP를 50만큼 회복시킨다.", Item.ItemType.Food));
        itemList.Add(new Item(30004, "빵", "빵. 밀로 제작할 수 있으며 HP를 15만큼 회복시킨다.", Item.ItemType.Food));
        itemList.Add(new Item(30005, "햄버거", "햄버거. 샐러드와 빵으로 제작할 수 있으며 HP를 50만큼 회복시킨다.", Item.ItemType.Food));
    }

    //플레이어 관련 func
    public void ChangeHP(int _value)
    {
        int temp = curHp + _value;

        if (temp >= MaxHp)
            curHp = MaxHp;
        else if (temp <= 0)
            curHp = 0;
        else
            curHp = temp;

        LinkDataToText();
    }

    public int CurrentHP()
    {
        return curHp;
    }

    public void ChangeGold(int _value)
    {
        gold += _value;
        LinkDataToText();
    }

    public int CurrentGold()
    {
        return gold;
    }

    //시간 관련 func
    public void ChangeMinute(int _value)
    {
        int temp = minute + _value;

        if (temp == 60)
        {
            minute = 0;
            ChangeHP(-5);
            if (hour == 24)
            {
                hour = 7;
                if (day == 28)
                {
                    if (season == SEASON.WINTER)
                    {
                        season = SEASON.SPRING;
                        day = 1;
                    }
                    else
                    {
                        season++;
                        day = 1;
                    }
                }
            }
            else
                hour++;
        }
        else
            minute = temp;
    }

    public void RenewalDay()
    {
        hour = 7;
        minute = 0;
        isNextDay = true;
        if (day == 28)
        {
            if (season == SEASON.WINTER)
            {
                season = SEASON.SPRING;
                day = 1;
            }
            else
            {
                season++;
                day = 1;
            }
        }
        else
            day++;

        LinkDataToText();
        sleepException = true;
        clockHand.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 170.0f));
        tempRot = 170.0f;
        isNextDay = false;
        playerSpeed = 0.08f;
        coffeeDrink = false;
        int rand = Random.Range(1,  4);
        BGMManager.instance.Play(rand);
        BGMManager.instance.FadeIn();
    }

    public void ResetDay()
    {
        hour = 7;
        minute = 0;
        curHp = MaxHp;

        //이후 당일 시작 전까지 저장된 데이터 로드.(인벤토리 상황 등)

        LinkDataToText();
    }

    public void ChangeSpeed(float _value)
    {
        playerSpeed += _value;
    }
}
