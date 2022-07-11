using UnityEngine;


public class particleWheel : MonoBehaviour
{
    
    [SerializeField] private GameObject pBack;
    [SerializeField] private ParticleSystem dustParticles;
    [SerializeField] private float speedThreshold;
   
    private Rigidbody pbackmyrb;
   
    private bool particlesPlaying;
    private bool goingForward;
    private bool goingBackward;
    private bool belowThreshold;
    private Vector3 velocity;
    private void Start()
    {
        pbackmyrb = pBack.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //We check if we are spawning particles or not
        //Checking speed value of rigid body
        velocity = pbackmyrb.velocity;
      
        //checking speed value is greater than threshold
        goingForward = !particlesPlaying && (velocity.sqrMagnitude > speedThreshold);
      
        //checking speed value is lesser than threshold
        goingBackward = !particlesPlaying && (velocity.sqrMagnitude < -speedThreshold);
      
        //checking speed value is within positive & negative threshold 
        belowThreshold = particlesPlaying &&
                         (velocity.sqrMagnitude < speedThreshold && velocity.sqrMagnitude > -speedThreshold);
      
        if (goingForward || goingBackward)
        {
            particlesPlaying = true;
            SpawnParticles();
        }
        else if(belowThreshold) 
        {
            particlesPlaying = false;
            dustParticles.Stop();
        }
    }
    private void SpawnParticles()
    {
        dustParticles.Play();
    }
}