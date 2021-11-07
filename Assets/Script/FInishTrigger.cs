using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FInishTrigger : MonoBehaviour
{

	public PlayerMovement movement;
    public AudioSource finish;

	private void OnTriggerEnter(){
		Debug.Log("Finish!!");
		finish.Play();
        movement.enabled = false;

	}
}
