using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 PlayerPos = player.transform.position;

        transform.position = new Vector3
            (PlayerPos.x, PlayerPos.y + 150f, transform.position.z);
    }
}
