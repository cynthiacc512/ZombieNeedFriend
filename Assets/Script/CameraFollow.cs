using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
         transform.position =  GameObject.FindWithTag("Player").transform.position + offset;
    }
}
