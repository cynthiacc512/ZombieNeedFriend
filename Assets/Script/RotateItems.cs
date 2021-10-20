using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItems : MonoBehaviour
{
	public GameObject theBrain;
	
	public float PlaceX;
	public float PlaceZ;
	public int itemCount = 0;
	
	void Start()
    {
        StartCoroutine(ItemDrop());
    }
	
	// Update is called once per frame
    void Update()
    {
        theBrain.transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
    }
	
    IEnumerator ItemDrop()
	{
		while(itemCount < 4){
			PlaceX = Random.Range(2.2f, 10);
			PlaceZ = Random.Range (48, 783);
			Instantiate(theBrain, new Vector3(PlaceX, 1, PlaceZ), Quaternion.Euler(0f, 0f, 0f));
			yield return new WaitForSeconds(4f);
			itemCount += 1;
		}
	}

}
