using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]
    Button btn1, btn2, btn3;
    protected float attackSpeed = 1.5f;          //���ݼӵ�
    float attackRange;           //���ݹ���
    protected int attackPower = 20;        //���ݷ�
    int avoidanceRate = 0;       //ȸ����
    int maxHP = 10;               //�ִ� ���
    public int currentHP;               //���� ���
    int attackPowerCount = 0;
    int attackSpeedCount = 0;
    int attackRangeCount = 0;
    int avoidanceRateCount = 0;
    int hpCount = 0;

    private void Start()
    {
        currentHP = maxHP;
        Image spr1 = GameObject.Find("Canvas").transform.Find("UpgradePanel").transform.Find("UpgradeBtn1").transform.Find("Image1").GetComponent<Image>();
        Image spr2 = GameObject.Find("Canvas").transform.Find("UpgradePanel").transform.Find("UpgradeBtn2").transform.Find("Image2").GetComponent<Image>();
        Image spr3 = GameObject.Find("Canvas").transform.Find("UpgradePanel").transform.Find("UpgradeBtn3").transform.Find("Image3").GetComponent<Image>();
        btn1.onClick.AddListener(delegate { StatUp(spr1.sprite.name); });
        btn2.onClick.AddListener(delegate { StatUp(spr2.sprite.name); });
        btn3.onClick.AddListener(delegate { StatUp(spr3.sprite.name); });
    }

    public void TakeDamage()
    {
        currentHP--;
    }

    public void StatUp(string spriteName)
    {
        switch (spriteName)
        {
            case "AttackPower":
                //int inc = (attackPower / 100) * 35;  //������ ���, 35% = (���ݷ� / 100) *35;
                //attackPower += inc;
                attackPowerCount++;
                Debug.Log("���ݷ� ����~!");
                break;
            case "AttackRange":
                attackRangeCount++;
                Debug.Log("���� ���� ����~!");
                break;
            case "AttckSpeed":
                //attackSpeed -= 0.07; //�����ֱ�(�ð�) ����
                attackSpeedCount++;
                Debug.Log("���� �ӵ� ����~!");
                break;
            case "Avoidance":
                //avoidanceRate += 5;
                avoidanceRateCount++;
                Debug.Log("ȸ���� ����~!");
                break;
            case "HpUp":
                hpCount++;
                maxHP += 1;
                Debug.Log("��� �� �� ����~!");
                break;
        }
    }
}