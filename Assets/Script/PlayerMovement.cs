using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Rigidbody rb;
	public Animator animator;

	private Vector3 jump = new Vector3(0.0f, 2.5f, 0.0f);
<<<<<<< HEAD
    public float speed = 10;
    private float leftRightSpeed = 4;
    private float jumpForce = 2f;
=======
	public float speed = 10;
	private float leftRightSpeed = 4;
	private float jumpForce = 2f;
>>>>>>> 9303ad6f91870fb153ab2665d3d2d73793fac7b7
	
    void FixedUpdate()
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
}
