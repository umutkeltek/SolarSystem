using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Planet", menuName = "ScriptableObjects/Planet Scriptable Object", order = 1)]
public class PlanetDataSO : CelestialDataSO
{
    public long Population;

    public override string ToString()
    {
        return "Name: " + this.CelestialName + "\n" + "Radius: " + CelestialRadius;
        //$"{CelestialName} - {CelestialRadius}";
        //return $"{CelestialName} - //{CelestialDescription} - {CelestialRadius} - {Population}";
    }
}
