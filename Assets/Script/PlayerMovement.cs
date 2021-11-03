using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Rigidbody rb;
	public Animator animator;

	private Vector3 jump = new Vector3(0.0f, 2.5f, 0.0f);
    public float speed = 12;
    private float leftRightSpeed = 4;
    private float jumpForce = 2.1f;
	private BoxCollider collider;
	
	private void Start(){
		collider = GetComponent<BoxCollider>();
	}

    void FixedUpdate()
    {
		//run
		transform.Translate(Vector3.forward * Time.deltaTime * speed , Space.World);
		
		if(PlayerCollision.isPeople){
			animator.SetTrigger("Eat");
			PlayerCollision.isPeople = false;
		}

		//jump
		if(Input.GetKey(KeyCode.W) && PlayerCollision.isGround){
			rb.AddForce(jump * jumpForce, ForceMode.Impulse);
			PlayerCollision.isGround = false;
		}
		
		if (Input.GetKey(KeyCode.S))
		{
			startSliding();
			Invoke("stopSliding", 0.5f);
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

	private void startSliding(){
		animator.SetBool("Slide", true);
		collider.size = new Vector3(collider.size.x, collider.size.y / 2, collider.size.z);
		collider.center = new Vector3(collider.center.x, collider.center.y / 2, collider.center.z);
	}

	private void stopSliding(){
		animator.SetBool("Slide", false);
		collider.size = new Vector3(collider.size.x, collider.size.y * 2, collider.size.z);
		collider.center = new Vector3(collider.center.x, collider.center.y * 2, collider.center.z);
	}



}
