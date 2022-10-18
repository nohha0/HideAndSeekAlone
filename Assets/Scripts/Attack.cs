using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    PlayerController Playstats;
    public bool attacked = false;


    void Start()
    {
        Animator animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    void AttackTrue()
    {
        attacked = true;
    }
    void AttackFalse()
    {
        attacked = false;
    }
    void SetAttackSpeed(float speed)
    {
    }
}
