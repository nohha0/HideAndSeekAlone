using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ����Ʈ 
public class AttackEffects : MonoBehaviour
{
    //���� ��ũ��Ʈ
    private Attack script;
    GameObject player;  //�÷��̾� ���� ����
    void Start()
    {
        Invoke("OnDestroy", 0.4f);
        script = GameObject.Find("Player").GetComponent<Attack>();  //��ũ��Ʈ ����
        player = GameObject.Find("Player");   //�÷��̾� ����
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("create", 0.1f);
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
    void create()
    {
        transform.localScale = new Vector3(script.boxSize.x, script.boxSize.y, 1);

    }

}
