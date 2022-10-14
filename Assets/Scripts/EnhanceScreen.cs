using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnhanceScreen : MonoBehaviour
{
    private GameObject EnhanceSc;

    private void Start()
    {
        EnhanceSc = GameObject.Find("Canvas");
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            EnhanceSc.transform.Find("UpgradePanel").gameObject.SetActive(true);
        }
        else
        {
            EnhanceSc.transform.Find("UpgradePanel").gameObject.SetActive(false);
        }
    }
}
