using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLight : MonoBehaviour
{
    protected GameObject targetGameObject;
    public float speed;
    Vector2 direction;
    void Start()
    {
        targetGameObject = GameObject.FindWithTag("Player");
        direction = (targetGameObject.transform.position - transform.position).normalized; //���� ����
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
