using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] float rotationSpeed = 10;

    void Update()
    {
        //rotate
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
