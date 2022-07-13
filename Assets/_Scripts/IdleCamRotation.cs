using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleCamRotation : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeBeforeRotate = 3f;
    [SerializeField] private Transform rotateAround;
    private float lastTimeNotIdle;
    private bool playerIdling = true; 
    void Start()
    {
        lastTimeNotIdle = Time.realtimeSinceStartup; // initialize at "now"
    }
    
 
    void Update()
    {   
        
        if (!isIdle())
        {
            // When we are not idling, update the time of last non-idle action
            lastTimeNotIdle = Time.realtimeSinceStartup;
        }
 
        // Calculate how long we are idling
        float diff = Time.realtimeSinceStartup - lastTimeNotIdle;
 
        // Only rotate when we waited timeBeforeRotate seconds after the last user action
        if (diff > timeBeforeRotate)
        {
            transform.RotateAround(rotateAround.position, Vector3.up, speed);
        }
    }
 
    private bool isIdle() // returns true if we are idling
    {   
        if(Input.anyKey)
        {
            return playerIdling = false;
        }
        else
        {
            return playerIdling = true;
        }
        
        
    }
}

