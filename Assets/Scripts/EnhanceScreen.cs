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
            EnhanceSc.transform.Find("Panel").gameObject.SetActive(true);
            EnhanceSc.transform.Find("E1").gameObject.SetActive(true);
            EnhanceSc.transform.Find("E2").gameObject.SetActive(true);
            EnhanceSc.transform.Find("E3").gameObject.SetActive(true);
        }
        else
        {
            EnhanceSc.transform.Find("Panel").gameObject.SetActive(false);
            EnhanceSc.transform.Find("E1").gameObject.SetActive(false);
            EnhanceSc.transform.Find("E2").gameObject.SetActive(false);
            EnhanceSc.transform.Find("E3").gameObject.SetActive(false);
        }
    }
}
