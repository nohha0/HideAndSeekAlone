using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public float maxSpeed;
    public float maxAccel;
    //public float orientation;
    //public float rotation;
    public Vector2 velocity;
    protected Steering steering;

    void Start()
    {
        velocity = Vector2.zero;
        steering = new Steering();

    }

    public void SetSteering (Steering steering)
    {
        this.steering = steering;
    }

    public virtual void Update()
    {
        Vector2 displacement = velocity * Time.deltaTime;
        
        transform.Translate(displacement, Space.World);
        //transform.rotation, transform.Rotate
    }

    public virtual void LateUpdate()
    {
        velocity += steering.linear * Time.deltaTime;
        if (velocity.magnitude > maxSpeed)  
        {
            velocity.Normalize();
            velocity = velocity * Time.deltaTime;
        }
        if (steering.linear.sqrMagnitude == 0.0f)   
        {
            velocity = Vector2.zero;
        }

        steering = new Steering();
    }
}
