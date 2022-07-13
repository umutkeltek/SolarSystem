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

    [Header("Meteor Size")]
    [Range(0.05f, 0.2f)]
    [SerializeField] private float minMeteorSize;
    [Range(0.2f, 0.8f)]
    [SerializeField] private float maxMeteorSize;
    
    private void Start()
    {
        InvokeRepeating("Spawn", 1f, Random.Range(minTimeBetweenMeteors, maxTimeBetweenMeteors));
    }

    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-3000f, 3000f), Random.Range(-1000f, 1000f), Random.Range(-1000f, 1000f));
        meteor.transform.localScale *= Random.Range(minMeteorSize, maxMeteorSize);
        Instantiate(meteor, spawnPosition, Quaternion.identity);
        
    }
}
