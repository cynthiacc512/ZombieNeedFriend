using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static bool isGround;
    public PlayerMovement movement;
    public Animator animator;

	public static bool isRage;

    void OnCollisionEnter(Collision collision)
    {
		if(!isRage) {

			if (collision.collider.tag == "Obstacle")
			{
				Destroy(collision.collider.gameObject);
				movement.enabled = false;
				animator.SetTrigger("Hurt");
				for ( int x = 0; x <= 2 ; x++){
					transform.position -= new Vector3 (0, 0, 30 * Time.deltaTime);
				}
				Invoke("startMove", 3);
				isGround = true;
			}

			if (collision.collider.tag == "Ground")
			{
				isGround = true;
			}

			if (collision.collider.tag == "Rage")
			{
				isRage = true;
			}

		} else {

			if (collision.collider.tag != "Ground")
			{
				Destroy(collision.collider.gameObject);
			}
		}
        
    }

    void startMove()
	{
		movement.enabled = true;
	}
}
