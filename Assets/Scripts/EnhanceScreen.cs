using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnhanceScreen : Level
{
    
    public void Screen_zom_DDewar()
    {
        if(TimeStop == true)
        {
            gameObject.SetActive(true);
            Debug.Log("���� â�� ����ּ���");
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


}
