using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int level = 1;
    public int levelCount = 0;
    public int expCurrent = 0;      //�������ġ
    public int expLeft = 1000;      //����. �������� �ʿ��� ����ġ
    public bool TimeStop = false;

    int expBase = 1000;      //���. ����1�淹��2 �ʿ��� ����ġ
    float expMod = 1.21f;    //����ġ ������ (����)

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

        //ĳ���� �⺻����
        if (Input.GetKeyDown(KeyCode.X))
        {
            //�߰�)if �÷��̾��� ���� �ݶ��̴��� ���ʹ��� �ݶ��̴��� �ε�����
            GainExp(500);
            Debug.Log("����ġ 500 ȹ��");
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

            Debug.Log(level + "������ ������!");
        }
    }

    virtual public void Enhance()
    {
        Time.timeScale = 0;
        TimeStop = true;
        Debug.Log("��ȭ");
    }
}
