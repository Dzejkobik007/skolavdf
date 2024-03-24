using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class VoidTeleport : MonoBehaviour
{
    public Transform teleportPosition;
    public float yThreshold = -100;
    public bool resetVelocity = true;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < yThreshold)
        {
            transform.position = teleportPosition.position;
            if (resetVelocity)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }
}
