﻿using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static bool isGround;
	public static bool isRage;
	public static bool isConfuse;
    public PlayerMovement movement;
    public Animator animator;

    void OnCollisionEnter(Collision collision)
    {
		if(!isRage) {
			if (collision.collider.tag == "Obstacle") {
				Destroy(collision.collider.gameObject);
				movement.enabled = false;
				animator.SetTrigger("Hurt");
				for ( int x = 0; x <= 2 ; x++){
					transform.position -= new Vector3 (0, 0, 30 * Time.deltaTime);
				}
				Invoke("startMove", 3);
				isGround = true;
			} else if (collision.collider.tag == "Ground"){
				isGround = true;
			} else if (collision.collider.tag == "Rage"){
				isRage = true;
			} else if (collision.collider.tag == "confuse"){
				isConfuse = true;
				Destroy(collision.collider.gameObject);
			}
		} else {
			if (collision.collider.tag != "Ground") {
				Destroy(collision.collider.gameObject);
			}
		}
        
    }

    void startMove()
	{
		movement.enabled = true;
	}
}
