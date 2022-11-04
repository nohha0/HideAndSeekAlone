using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardFireWave : MonoBehaviour
{
    SpriteRenderer rend;
    public SpriteRenderer plarerRenderer;  //플레이어 랜더러 가져오기
    public float speed;


    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        plarerRenderer = GetComponent<SpriteRenderer>();
        Invoke("OnDestroy", 2);
    }

    void Update()
    {
        if(transform.rotation.y ==0)
        {
            rend.flipX = true;
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else
        {
            rend.flipX = false;
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        }
        
    }
    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
