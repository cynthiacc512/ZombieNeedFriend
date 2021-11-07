using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageTimer : MonoBehaviour
{

    public GameObject theZombie;
	public GameObject zombieRage;
    public static float timeRemaining;
    public PlayerCollision pc;


    // Update is called once per frame
    void Update()
    {
        if(zombieRage.activeSelf){

            timeRemaining -= Time.deltaTime;

            if (timeRemaining < 0)
            {
                theZombie.SetActive(true);
                theZombie.transform.position = new Vector3(zombieRage.transform.position.x, zombieRage.transform.position.y +  2, zombieRage.transform.position.z);
                zombieRage.SetActive(false);

                PlayerCollision.isRage = false;

                for (int i=0 ; i< PlayerCollision.zombie ; i++){
                    pc.SpawnZombieFriends();
                }
            }

        }
        
    }
}