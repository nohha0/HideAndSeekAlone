using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEN : MonoBehaviour
{
    void Start()
    {
        Invoke("Destroy", 2);
    }

    void Update()
    {
        //�ð��Ǹ� �Ӹ������� �÷��̾����� ���ư��� ���� ���� ��� ���ϱ���
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
