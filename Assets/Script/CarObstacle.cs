using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObstacle : MonoBehaviour
{
    int MinDist = 25;
	public bool isLeft ;
	
    // Start is called before the first frame update
	void Start()
    {
        if(transform.position.x < 0){
			isLeft = true;
		}else{
			isLeft = false;
		}
    }


	void Update()
    {
        if(isLeft && Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) <= MinDist && transform.position.x <= 4)
		{
			transform.position += new Vector3 (40 * Time.deltaTime, 0, 0);
		} else if (!isLeft && Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) <= MinDist && transform.position.x > 8)
		{
			transform.position += new Vector3 (-40 * Time.deltaTime, 0, 0);
			
		}
		
    }
}
