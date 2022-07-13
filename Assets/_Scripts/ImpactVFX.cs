using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactVFX : MonoBehaviour
{
    [SerializeField] private GameObject impactVFX;
    private GameObject impactVFXInstance;
    
    private bool notInteantiated = true;
    
    private void OnTriggerEnter(Collider other)
    {
        if (impactVFX != null) //check if the impactVFX exist
        {
            if (other.transform.CompareTag("Meteor")) //check if the meteor hit the planet
            {    
                var collisionPoint = other.ClosestPointOnBounds(transform.position); //get the collision point
                var collisionNormal = transform.position - collisionPoint; //get the normal of the collision
                if (notInteantiated) //checking that impactvfx instance exist or not
                {
                    var impactVFXInstance = Instantiate(this.impactVFX, collisionPoint,
                        Quaternion.FromToRotation(Vector3.up, collisionNormal)) as GameObject; //create the impactvfx instance
                    notInteantiated = false;
                    Destroy(impactVFXInstance, 2f); //destroy the impactvfx instance after 2 seconds
                    notInteantiated = true; //set the notInteantiated to true so that the impactvfx instance can be created again
                }
                
            }
                
        }
    }
    
//this script is used to create the impactvfx instance when the meteor hit the planet
}
