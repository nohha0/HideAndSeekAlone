using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnhanceList : MonoBehaviour
{
    [SerializeField] Button btn1, btn2, btn3;
    

    public int attackPower = 20;    //공격력 
    public double attackSpeed;      //공격속도
    public float attackRange;       //공격범위
    public int avoidanceRate = 0;   //회피율
    public int HP = 4;

    public int attackPowerCount = 0;
    public int attackSpeedCount = 0;
    public int attackRangeCount = 0;
    public int avoidanceRateCount = 0;
    public int hpCount = 0;

    public void StatUp(string spriteName)
    {
        Image spr1 = GameObject.Find("Image1").GetComponent<Image>();
        Image spr2 = GameObject.Find("Image1").GetComponent<Image>();
        Image spr3 = GameObject.Find("Image1").GetComponent<Image>();
        btn1.onClick.AddListener(delegate { StatUp(spr1.sprite.name); });
        btn1.onClick.AddListener(delegate { StatUp(spr2.sprite.name); });
        btn1.onClick.AddListener(delegate { StatUp(spr3.sprite.name); });

        switch (spriteName)
        {
            case "AttackPower":
                //int inc = (attackPower / 100) * 35;  //증가율 계산, 35% = (공격력 / 100) *35;
                //attackPower += inc;
                Debug.Log("공격력증가");
                attackPowerCount++;
                break;
            case "AttackRange":
                Debug.Log("공범증가");
                attackRangeCount++;
                break;
            case "AttckSpeed":
                //attackSpeed -= 0.07; //공격주기(시간) 감소
                Debug.Log("공속증가");
                attackSpeedCount++;
                break;
            case "Avoidance":
                //avoidanceRate += 5;
                Debug.Log("회피율증가");
                avoidanceRateCount++;
                break;
            case "HpUp":
                //HP += 1;
                Debug.Log("목숨증가");
                hpCount++;
                break;
        }
    }
}