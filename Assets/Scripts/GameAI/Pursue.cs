using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : Seek
{
    public float maxPredeiction;
    private GameObject targetAux;
    private Agent targetAgent;
    SpriteRenderer spriteRenderer;

    public override void Awake()
    {
        base.Awake();
        targetAgent = target.GetComponent<Agent>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        targetAux = target;
        target = new GameObject();
    }

    void OnDestroy()
    {
        Destroy(targetAux);
    }

    public override Steering GetSteering()
    {
        Vector2 direction = targetAux.transform.position - transform.position;
        float distance = direction.magnitude;
        float speed = agent.velocity.magnitude;
        float prediction;

        if (speed <= distance / maxPredeiction)
            prediction = maxPredeiction;
        else
            prediction = distance / speed;

        target.transform.position = targetAux.transform.position;
        target.transform.position += (Vector3)targetAgent.velocity * prediction;

        if (target.transform.position.x >= transform.position.x)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;

        return base.GetSteering();
    }
}
