using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public static bool isGround;
	public static bool isRage;
	public static bool isConfuse;
	public static bool isPeople ;
	public static int score = 0;
	public static int zombie = 0;
    public PlayerMovement movement;
    public Animator animator;

	public GameObject theZombie;
	public GameObject zombieFriend;
	public float PlaceX;
	public float PlaceZ;

	public GameObject rageBar;
	public static int life = 3;

    void OnCollisionEnter(Collision collision)
    {
		if(!isRage) {
			
			if (collision.collider.tag == "Obstacle") {
				Destroy(collision.collider.gameObject);
				// Destroy(this.gameObject);
				movement.enabled = false;
				animator.SetTrigger("Hurt");
				for ( int x = 0; x <= 2 ; x++){
					transform.position -= new Vector3 (0, 0, 30 * Time.deltaTime);
				}
				Invoke("startMove", 3);
				isGround = true;
				score -= 5;
				life -= 1;
				
			} else if (collision.collider.tag == "Ground"){
				isGround = true;
			} else if (collision.collider.tag == "Rage"){
				isRage = true;
			} else if (collision.collider.tag == "confuse"){
				isConfuse = true;
				score -= 3;
				Destroy(collision.collider.gameObject);
			} else if (collision.collider.tag == "People" && !isPeople){
				isPeople = true;
				zombie += 1;
				score += 10;
				Destroy(collision.collider.gameObject);
				SpawnZombieFriends();
			}
		} else {
			rageBar.SetActive(true);
			DestroyAllZombieFriends();

			if (collision.collider.tag != "Ground") {
				Destroy(collision.collider.gameObject);
			}
			
			if (collision.collider.tag == "People"){
				isPeople = true;
				zombie += 1;
				score += 10;
				Debug.Log("Harusnya nambah 1 " + zombie);
				Destroy(collision.collider.gameObject);
			}
		}

		// Debug.Log(zombie);
    }

	void OnCollisionExit(Collision collision)
    {
		if (collision.collider.tag == "People" && isPeople){
			isPeople = false;
			Destroy(collision.collider.gameObject);
		}
	}

	// void OnTriggerEnter(Collider other){
	// 	Debug.Log("HORE MENANG!!");
	// 	Debug.Log("Score: "+score);
	// 	// text.text = "HOREE MENANG!!";
	// 	// text.text = "Score: "+ score;
	// 	movement.enabled = false;
	// }

    void startMove()
	{
		movement.enabled = true;
	}

	public void SpawnZombieFriends()
	{
		theZombie = GameObject.FindWithTag("Player");

		PlaceX = Random.Range(theZombie.transform.position.x - 0.5f, theZombie.transform.position.x + 0.5f);
		PlaceZ = Random.Range (theZombie.transform.position.z - 0.5f, theZombie.transform.position.z - 2.0f);
		Instantiate(zombieFriend, new Vector3(PlaceX, 0.5f, PlaceZ), Quaternion.Euler(0f, 0f, 0f));
	}

	void DestroyAllZombieFriends(){
		GameObject[] friends = GameObject.FindGameObjectsWithTag("Friend");
		for(int i = 0 ; i< friends.Length ; i++)
		{
			Destroy(friends[i]);
		}
	}

	void Update()
	{
		if ( RageTimer.timeRemaining <= 0 ){
			rageBar.SetActive(false);
		}
		
	}

}

