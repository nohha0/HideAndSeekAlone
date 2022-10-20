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
        
        if(Input.GetKeyDown(KeyCode.C)) // 공격 애니메이션
        {
            Debug.Log("공격! attack true");
            animator.SetTrigger("attack");
        }
    }

    
}
