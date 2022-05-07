using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0.0f, 0.0f, 0.0f);
    public float multiplier = 1.0f;
    public Transform spinner;
    void Update()
    {
        spinner.transform.Rotate(rotationSpeed.x * Time.deltaTime * multiplier, rotationSpeed.y * Time.deltaTime * multiplier, rotationSpeed.z * Time.deltaTime * multiplier, Space.Self);
    }
}
