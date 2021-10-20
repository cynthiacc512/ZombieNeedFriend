using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Rigidbody rb;
	public Animator animator;

	private Vector3 jump = new Vector3(0.0f, 2.5f, 0.0f);
    public float speed = 10;
    private float leftRightSpeed = 4;
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
		
		Debug.Log(PlayerCollision.isGround);
		//jump
		if(Input.GetKey(KeyCode.W) && PlayerCollision.isGround){
			rb.AddForce(jump * jumpForce, ForceMode.Impulse);
			PlayerCollision.isGround = false;
		}
		
		if (Input.GetKey(KeyCode.S))
		{
			animator.SetTrigger("Slide");
		}
    }
}
