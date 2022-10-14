using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    private Sprite[] Images;
    public int level = 1;
    public int levelCount = 0;
    public int expCurrent = 0;      //현재경험치
    public int expLeft = 1000;      //변수. 레벨업에 필요한 경험치
    int expBase = 1000;      //상수. 레벨1→레벨2 필요한 경험치
    float expMod = 1.21f;    //경험치 증가량 (지수)

    [SerializeField] UpgradePanelManager upgradePanel;

    int TO_LEVEL_UP
    {
        get 
        {
            return expLeft;
        }
    }

    private void Update()
    {
        CheckLevelUp();

        if (levelCount > 0)
        {
            Enhance();
        }

        //캐릭터 기본공격
        if (Input.GetKeyDown(KeyCode.X))
        {
            //추가)if 플레이어의 무기 콜라이더와 에너미의 콜라이더가 부딪히면
            GainExp(5000);
            Debug.Log("경험치 5000 획득");
        }
    }

    public void GainExp(int amount)
    {
        expCurrent += amount;
    }

    public void CheckLevelUp()
    {
        if (expCurrent >= TO_LEVEL_UP)
        {
            expLeft = (int)Mathf.Floor(expBase * Mathf.Pow(expMod, level));
            expCurrent -= TO_LEVEL_UP;
            level++;
            levelCount++;

            Debug.Log(level + "레벨로 레벨업!");
        }
    }

    public void Enhance()
    {
        int i;
        //0~4 랜덤숫자 뽑는 코드
        i = Random.Range(0, 5);

        Images = Resources.LoadAll<Sprite>("Upgrades");

        //Image img1 = GameObject.Find("Canvas").transform.FindChild("UpgradePanel").transform.FindChild("Image1").GetComponent<Image>();
        //img1.sprite = Images[i];

        upgradePanel.OpenPanel();
        Debug.Log("강화");
    }

    public void LevelCountDown()
    {
        levelCount--;
    }

}
