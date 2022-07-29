using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CelestialDataSO : ScriptableObject
{
    public string CelestialName;
    public string CelestialDescription;
    public float  CelestialRadius;
    
    public override string ToString()
    {
        return $"{CelestialName} - {CelestialRadius}";
    }
    //return $"{CelestialName} - {CelestialDescription} - {CelestialRadius}";
}
