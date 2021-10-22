using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static bool isGround;
    public PlayerMovement movement;
    public Animator animator;
    public static bool isRage;
    public static bool isConfuse;

    void OnCollisionEnter(Collision collision)
    {
		//run
		transform.Translate(Vector3.forward * Time.deltaTime * speed , Space.World);
		
		//jump
		if(Input.GetKey(KeyCode.W) && PlayerCollision.isGround){
			rb.AddForce(jump * jumpForce, ForceMode.Impulse);
			PlayerCollision.isGround = false;
		}
		
		if (Input.GetKey(KeyCode.S))
		{
			animator.SetTrigger("Slide");
		}
		
		Debug.Log(PlayerCollision.isConfuse);
		//garbage
		if(PlayerCollision.isConfuse){
			//right
			if ( Input.GetKey(KeyCode.D)){
				if(this.gameObject.transform.position.x > LevelBoundary.leftSide)
				{
					transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
				}
			}
			
			//left
			if ( Input.GetKey(KeyCode.A)){
				if(this.gameObject.transform.position.x < LevelBoundary.rightSide)
				{
					transform.Translate(Vector3.left * Time.deltaTime * -leftRightSpeed);
				}
			}
		}else{
			//normal
		//left
		if ( Input.GetKey(KeyCode.A))
		{
			if(this.gameObject.transform.position.x > LevelBoundary.leftSide)
			{
				transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
			}
		} else {
			if (collision.collider.tag != "Ground") {
				Destroy(collision.collider.gameObject);
			}
		}
		}

		
		



		
    }
}
