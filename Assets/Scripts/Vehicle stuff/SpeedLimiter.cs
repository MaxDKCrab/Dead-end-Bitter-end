using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLimiter : MonoBehaviour
{
    [SerializeField] private Rigidbody rbFront;
    public float maxSpeed;
    void Update()
    {
        if (rbFront.velocity.magnitude > maxSpeed)
        {
            rbFront.drag = 0.5F;
        }
        else
        {
            rbFront.drag = 0F;
        }
    }
}
