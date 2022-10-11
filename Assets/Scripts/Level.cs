using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int level = 1;
    public int levelCount = 0;
    public int expCurrent = 0;      //현재경험치
    public int expLeft = 1000;      //변수. 레벨업에 필요한 경험치
    public bool TimeStop = false;

    int expBase = 1000;      //상수. 레벨1→레벨2 필요한 경험치
    float expMod = 1.21f;    //경험치 증가량 (지수)

    int TO_LEVEL_UP
    {
        get 
        {
            return expLeft;
        }
    }

    void Update()
    {
        if (expCurrent >= expLeft)
        {
            CheckLevelUp();
        }

        if (levelCount > 0)
        {
            while (levelCount > 0)
            {
                Enhance();
                levelCount--;
            }
        }

        //캐릭터 기본공격
        if (Input.GetKeyDown(KeyCode.X))
        {
            //추가)if 플레이어의 무기 콜라이더와 에너미의 콜라이더가 부딪히면
            GainExp(500);
            Debug.Log("경험치 500 획득");
        }

        if (Time.timeScale == 0 && Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            TimeStop = false;
        }
    }

    public void GainExp(int amount)
    {
        expCurrent += amount;

        CheckLevelUp();
    }

    public void CheckLevelUp()
    {
        expLeft = (int)Mathf.Floor(expBase * Mathf.Pow(expMod, level));

        if (expCurrent >= TO_LEVEL_UP)  
        {
            expCurrent -= TO_LEVEL_UP;
            level++;
            levelCount++;

            Debug.Log(level + "레벨로 레벨업!");
        }
    }

    virtual public void Enhance()
    {
        Time.timeScale = 0;
        TimeStop = true;
        Debug.Log("강화");
    }
}
