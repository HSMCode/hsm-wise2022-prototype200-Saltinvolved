using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipGoal : MonoBehaviour

{
    public GameObject AstroBoi;
    //public AudioSource audioSource;
    public ParticleSystem playParticleSystem;
    public ParticleSystem emitParticleSystem;
    //Get Game Over Bools 
    public ScriptUI script;
    
 
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + "triggerd into" + gameObject.name);

         // When roboter collides with goal 
        if(other.name == AstroBoi.name)
        { 
            //audioSource.Play();
            //Debug.Log("Victory");

            //Using a ParticleSystem for emission 
            EmitParticles();
           
           // Using a ParticleSystem with play and Stop - play true
        
            PlayParticles(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {

        Debug.Log(other.name + "triggered into" + gameObject.name);

        //when roboter collides with goal 
        if(other.name == AstroBoi.name)
        {
            Debug.Log("Exit");
            //using a ParticleSystem with Play and Stop - play false 
            PlayParticles(false); 
            EmitParticles();
            
            script._countingDown = false;
            script._gameWon = true;
            script._gameOver=true;
            

            
        }
    }

    //custom method to execute emitting of partiles 
     void EmitParticles()
     {
         emitParticleSystem.Emit(50);
    }
    void PlayParticles(bool on)
    {
        if(on)
        {
            playParticleSystem.Play();
        }
        else if(!on)
        {
            playParticleSystem.Stop();
        }
    }

}