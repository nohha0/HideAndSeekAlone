using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    public float space;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 PlayerPos = player.transform.position;

        transform.position = new Vector3
            (PlayerPos.x, PlayerPos.y + space, transform.position.z);
    }
}
