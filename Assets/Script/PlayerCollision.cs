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
    public PlayerMovement movement;
    public Animator animator;

	public GameObject zombieFriend;
	private GameObject theZombie;
	public float PlaceX;
	public float PlaceZ;

	public float zombie = 1;

	public Text text;

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
			} else if (collision.collider.tag == "People" && !isPeople){
				isPeople = true;
				Destroy(collision.collider.gameObject);
			}
		} else {
			if (collision.collider.tag != "Ground") {
				Destroy(collision.collider.gameObject);
			}else if (collision.collider.tag == "People"){
				isPeople = true;
				Destroy(collision.collider.gameObject);
				score += 1;
				Debug.Log(score);
			}
		}

		if(isPeople){
			//nambah orang dibelakang
			SpawnZombieFriends();
		}
    }

	void OnCollisionExit(Collision collision)
    {
		if (collision.collider.tag == "People" && isPeople){
			isPeople = false;
			Destroy(collision.collider.gameObject);
		}
	}

	void OnTriggerEnter(Collider other){
		Debug.Log("HORE MENANG!!");
		Debug.Log("Score: "+score);
		// text.text = "HOREE MENANG!!";
		// text.text = "Score: "+ score;
		movement.enabled = false;
	}

    void startMove()
	{
		movement.enabled = true;
	}

	void SpawnZombieFriends(){
		// theZombie = GameObject.FindWithTag("Player");
		// zombie = GameObject.FindGameObjectsWithTag("Player").Length;
		// Debug.Log("zombie:"+ zombie);

		// PlaceX = Random.Range(theZombie.transform.position.x - 0.1f, theZombie.transform.position.x + 0.5f);
		// PlaceZ = Random.Range (theZombie.transform.position.z - 0.2f, theZombie.transform.position.z - 0.5f);
		// Instantiate(theZombie, new Vector3(PlaceX, 0.5f, PlaceZ), Quaternion.Euler(0f, 0f, 0f));
	}
}

