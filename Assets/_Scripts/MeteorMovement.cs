using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    private GameObject[] celestials;
    Transform[] celestialTransforms;
    private Transform _targetCelestial;
    [SerializeField] private float minSpeed = 10f;
    [SerializeField] private float maxSpeed = 20f;
    void Start()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestial");
    }

     void Update()
    {   
        celestialTransforms = new Transform[celestials.Length];
        for (int i = 0; i < celestials.Length; i++)
        {
            celestialTransforms[i] = celestials[i].transform;
        }
        
        DecideWhichCelestialToFollow();
        float speed = Random.Range(minSpeed, maxSpeed);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _targetCelestial.position, Time.deltaTime * speed);
    }

     void DecideWhichCelestialToFollow()
     {   var distanceToCelestialList = new List<float>();
         for (int i = 0; i < celestialTransforms.Length; i++)
         {   
             distanceToCelestialList.Add(Vector3.Distance(transform.position, celestialTransforms[i].position));
         }
         float minDistance = distanceToCelestialList.Min();
         int indexMinDistance = distanceToCelestialList.IndexOf(minDistance);
         _targetCelestial = celestials[indexMinDistance].transform;
         
         

     }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Celestial")
        {
            Destroy(gameObject);
        }
    }
}
