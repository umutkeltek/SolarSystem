using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeteorMovement : MonoBehaviour
{
    private GameObject[] celestials;
    Transform[] celestialTransforms;
    private Transform _targetCelestial=null;
    [SerializeField] private float minSpeed = 10f;
    [SerializeField] private float maxSpeed = 20f;
    bool isLockToCelestial;
    
    void Start()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestial"); //get all celestial objects
        celestialTransforms = new Transform[celestials.Length]; //create array of transforms for all celestials
        for (int i = 0; i < celestials.Length; i++)
        {
            celestialTransforms[i] = celestials[i].transform;//assign transform of each celestial to array
        }
        
    }

     void Update()
    {   
        
        if (isLockToCelestial == false) //if the meteor is not locked to a celestial - it needs to decide which celestial to follow
        {
            DecideWhichCelestialToFollow(); //decide which celestial to follow
            isLockToCelestial = true;
        }

        if (isLockToCelestial == true) //when the meteor locked to celestial - it needs to move towards to that celestial
        {   
            float speed = Random.Range(minSpeed, maxSpeed); //get random meteor speed between min and max speed
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _targetCelestial.position, Time.deltaTime * speed); //move towards target celestial
        }
        
    }

     void DecideWhichCelestialToFollow()
     {   var distanceToCelestialList = new List<float>(); // create list of distances to celestials
         for (int i = 0; i < celestialTransforms.Length; i++)
         {   
             distanceToCelestialList.Add(Vector3.Distance(transform.position, celestialTransforms[i].position)); //assign distance to list
         }
         float minDistance = distanceToCelestialList.Min(); //get min distance
         int indexMinDistance = distanceToCelestialList.IndexOf(minDistance); //get index of min distance
         _targetCelestial = celestials[indexMinDistance].transform; //assign target celestial to the one with min distance
         Destroy(this.gameObject, 60f);//destroy meteor after 60 seconds


     }
     /*private void OnCollisionEnter(Collision collision)
     {
         ContactPoint contact = collision.contacts[0];
         Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
         Vector3 pos = contact.point;
        
         
     }*/
    void OnTriggerEnter(Collider other)
    {   
        
        if (other.gameObject.tag == "Celestial") //if the meteor hits a celestial
        {   Invoke("DestroyMeteor", 3f);//destroy meteor after 3 seconds
        }
    }

    void DestroyMeteor() //in order to use invoke we need this method to destroy meteor
    {
        Destroy(this.gameObject);
    }

    
}
