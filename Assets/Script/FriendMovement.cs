using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendMovement : MonoBehaviour
{
    public Vector3 offset;

    void Start() {
        offset = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-4f, -3f)); 
    }
    void Update()
    {
        transform.position =  GameObject.FindWithTag("Player").transform.position + offset;
    }
}
