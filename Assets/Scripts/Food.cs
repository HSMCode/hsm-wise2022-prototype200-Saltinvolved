using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject AstroBoi;
    public ParticleSystem Farts;
    public AudioSource fartSound;
    

    //Fruits get destroyed when Astroboi touches them
    private void OnTriggerEnter (Collider other)
    {
        Debug.Log (other.name + " just hit "+ gameObject.name);
        if(other.name == AstroBoi.name)
        {
            
        EmitParticles(); 
        fartSound.Play();
        Destroy (gameObject,0);
           
           
           

            
        }
    }

    void EmitParticles()
    {
        Farts.Emit(50);
    }

 
}
