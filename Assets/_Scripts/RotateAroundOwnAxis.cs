using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundOwnAxis : MonoBehaviour
{
    [SerializeField] private float rotateRate = 20;
    void Update()
    {
        transform.Rotate (Vector3.up * rotateRate * Time.deltaTime, Space.Self);

    }
}
