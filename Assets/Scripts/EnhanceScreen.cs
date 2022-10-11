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
            Debug.Log("제발 창을 띄워주세요");
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


}
