using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    PlayerController Playstats;
    Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.C)) // ���� �ִϸ��̼�
        {
            Debug.Log("����! attack true");
            animator.SetTrigger("attack");
        }
    }

    
}
