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
        lastTimeNotIdle = Time.realtimeSinceStartup; // initialize lastTimeNotIdle to current time
    }
    
 
    void Update()
    {   
        
        if (!isIdle())
        {
            
            lastTimeNotIdle = Time.realtimeSinceStartup; // update lastTimeNotIdle to current time while player is not idling
        }

        float diff = Time.realtimeSinceStartup - lastTimeNotIdle;// Calculate how long we are idling
 
        
        if (diff > timeBeforeRotate) //rotate the camera if player is idling for more than timeBeforeRotate seconds
        {
            transform.RotateAround(rotateAround.position, Vector3.up, speed);
        }
    }
 
    private bool isIdle() // returns true if we are idling
    {   
        if(Input.anyKey) // if any key is pressed, we are not idling
        {
            return playerIdling = false;
        }
        else //otherwise we are idling
        {
            return playerIdling = true;
        }
        
        
    }
}

