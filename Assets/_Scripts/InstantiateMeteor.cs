using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class InstantiateMeteor : MonoBehaviour
{   [SerializeField] private GameObject meteor;
    
    [Header("Meteor Spawning Speed")]
    [SerializeField] private float minTimeBetweenMeteors = 1f;
    [SerializeField] private float maxTimeBetweenMeteors = 5f;

    
    
    private void Start() 
    {   //call spawn function in desired rate
        InvokeRepeating("Spawn", 1f, Random.Range(minTimeBetweenMeteors, maxTimeBetweenMeteors));
    }

    void Spawn() //spawn meteors in specified area
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-3000f, 3000f), Random.Range(-1000f, 1000f), Random.Range(-1000f, 1000f));
        
        Instantiate(meteor, spawnPosition, Quaternion.identity);
        
    }
}
