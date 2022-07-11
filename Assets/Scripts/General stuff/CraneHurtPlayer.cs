using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneHurtPlayer : MonoBehaviour
{
    
    private ParticleSystem ps;
    private PlayerHealthManager health;
    
    void Start()
    {
        health = FindObjectOfType<PlayerHealthManager>();
        ps = GetComponent<ParticleSystem>();
    }
    
    private void OnParticleCollision(GameObject other)
    {
        health.TakeDamage(40);
    }
}
