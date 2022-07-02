using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SolarSystemManager : MonoBehaviour
{   //F = G * ((m1 * m2) / r2)
    //G = gravitational contant
    //m = mass of objects
    //r = distance between the centers of the masses
    
    private readonly float G = 100f; //this is a constant
    private GameObject[] celestials;
    void Start()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestial");
        InitialVelocity();
        

    }

    
    void FixedUpdate()
    {
        UniversalGravitation();
        
    }

    void UniversalGravitation() //this function is responsible for application of gravity
    {
        foreach (GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    
                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * (G * (m1 *m2)/(r * r))); //(b.transform.position - a.transform.position).normalized = shows the direction of the force
                }
            }
        }
    }

    void InitialVelocity() //this function is calculating the desired speed in order to stay in orbit.
    {foreach (GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                    float m2 = b.GetComponent<Rigidbody>().mass; 
                    float r = Vector3.Distance(a.transform.position, b.transform.position); // calculate the distance between sun and planets//
                    a.transform.LookAt(b.transform); //we make planets look to sun for initialize velocity in correct direction
                    //Circular Orbital speed: v = ((G * m2) / r)^0.5
                    a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((G * m2) / r); 
                }
            }
        }
        
    }
    
}
