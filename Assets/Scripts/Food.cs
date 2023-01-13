using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject AstroBoi;

    //Fruits get destroyed when Astroboi touches them
    private void OnTriggerEnter (Collider other)
    {
        Debug.Log (other.name + " just hit " + gameObject.name);
        if(other.name == AstroBoi.name)
        {
            //destroy fruit after 0 seconds
            Destroy (gameObject,0);
        }
    }
}
