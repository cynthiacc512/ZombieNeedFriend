using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static bool isGround;
    public PlayerMovement movement;
    public Animator animator;
    public static bool isRage;

    void OnCollisionEnter(Collision collision)
    {
<<<<<<< HEAD
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
=======
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
>>>>>>> bda7b2c420aafe99bd3a30b603b8249529b02d28
			}
		} else {
			if (collision.collider.tag != "Ground") {
				Destroy(collision.collider.gameObject);
			}
		}
<<<<<<< HEAD
		}

		
		



		
=======
        
    }

    void startMove() 
    {
		movement.enabled = true;
>>>>>>> bda7b2c420aafe99bd3a30b603b8249529b02d28
    }
}
