using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLimiter : MonoBehaviour
{
    [SerializeField] private Rigidbody rbFront;
    [SerializeField] private Rigidbody rbBack;
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
        if (rbBack.velocity.magnitude > maxSpeed)
        {
            rbBack.drag = 0.5F;
        }
        else
        {
            rbFront.drag = 0F;
        }
    }
}
