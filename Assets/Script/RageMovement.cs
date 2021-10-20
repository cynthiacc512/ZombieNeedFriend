using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageMovement : MonoBehaviour
{
    public Rigidbody rb;
	public Animator animator;

    public float speed = 6;
    private float leftRightSpeed = 3;
    private float jumpForce = 2f;
	
    void FixedUpdate()
    {
		//run
		transform.Translate(Vector3.forward * Time.deltaTime * speed , Space.World);
		
		//left
		if ( Input.GetKey(KeyCode.A))
		{
			if(this.gameObject.transform.position.x > LevelBoundary.leftSide)
			{
				transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
			}
		}
		
		//right
		if ( Input.GetKey(KeyCode.D))
		{
			if(this.gameObject.transform.position.x < LevelBoundary.rightSide)
			{
				transform.Translate(Vector3.left * Time.deltaTime * -leftRightSpeed);
			}
		}
    }

}
