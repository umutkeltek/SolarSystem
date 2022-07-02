using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTour : MonoBehaviour
{
    [SerializeField] private int Mercury = -1;
    [SerializeField] private int Venus= -1;
    [SerializeField] private int Earth= -1;
    [SerializeField] private int Mars= -1;
    [SerializeField] private int Jupiter = -1;
    [SerializeField] private int Saturn = -1;
    [SerializeField] private int Uranus = -1;
    [SerializeField] private int Neptune = -1;

    private void OnTriggerEnter(Collider other)
    {
        increaseTour(other.transform.name);
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     increaseTour(collision.transform.name);
    // }

    private void increaseTour(string celestialName)
    {
        switch (celestialName)
        {
            case "Mercury":
                Mercury += 1;
                break;
            case "Venus":
                Venus += 1;
                break;
            case "Earth":
                Earth += 1;
                break;
            case "Mars":
                Mars += 1;
                break;
            case "Jupiter":
                Jupiter += 1;
                break;
            case "Saturn":
                Saturn += 1;
                break;
            case "Uranus":
                Uranus += 1;
                break;
            case "Neptune":
                Neptune += 1;
                break;
        }
    }
}