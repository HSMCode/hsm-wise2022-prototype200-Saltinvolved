using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipGoal : MonoBehaviour

{
    public GameObject player;
    public ParticleSystem goalParticles;
    public  bool _hasLanded= false;

    
    // Game Over when Goal ist reached 
    public void OnTriggerEnter(Collider other)
    {
       if(other.name == player.name)
        { 
            PlayParticles(true);
        
            //setting bool for Winning Condition in ScriptUI
            _hasLanded = true;
        }
    }
    void PlayParticles(bool on)
    {
        if(on)
        {
            goalParticles.Play();
        }
        else if(!on)
        {
            goalParticles.Stop();
        }
    }
    
}