using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainCollide : MonoBehaviour
{
    public GameObject theZombie;
	public GameObject zombieRage;
    float x, z;

	
	// Update is called once per frame
    void Update()
    {
        // Rage selama 10 detik
        // float timeRemaining = 10f;

        if(PlayerCollision.isRage && !zombieRage.activeSelf){
			zombieRage.SetActive(true);
            zombieRage.transform.position = theZombie.transform.position;
            theZombie.SetActive(false);

            // Masih error
            // while (timeRemaining > 0){
            //     timeRemaining -= Time.deltaTime;
            //     Debug.Log("timeRemaining: " + timeRemaining);
            // }

            // if (timeRemaining <= 0){
            //     Debug.Log("ganti zombie");
            //     theZombie.SetActive(true);
            //     theZombie.transform.position = zombieRage.transform.position;
            //     zombieRage.SetActive(false);
            // }
            
        }
    }
}
