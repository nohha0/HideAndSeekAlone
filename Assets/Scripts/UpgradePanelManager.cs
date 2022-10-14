using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    Level level;
    [SerializeField] GameObject panel;

    private void Start()
    {
        level = GameObject.Find("Player").GetComponent<Level>();
    }

    public void OpenPanel()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        level.Wait = false;
        Time.timeScale = 1f;
        panel.SetActive(false);

        //여기서 멈추고 있던 원인을 제거

    }
}
