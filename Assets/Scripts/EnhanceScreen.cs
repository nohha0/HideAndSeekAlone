using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnhanceScreen : PlayerController
{
    
    public void Screen_zom_DDewar()
    {
        if(TimeStop == true)
        {
            gameObject.SetActive(true);
            Debug.Log("¤»¤»");
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


}
