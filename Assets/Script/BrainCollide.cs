using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainCollide : MonoBehaviour
{
    public GameObject theZombie;
	public GameObject zombieRage;
    float x, z;

   void Start()
    {

    }
	
	// Update is called once per frame
    void Update()
    {
        if(PlayerCollision.isRage && !zombieRage.activeSelf){
			zombieRage.SetActive(true);
			zombieRage.transform.position = theZombie.transform.position;
            theZombie.SetActive(false);
        }
    }
}
