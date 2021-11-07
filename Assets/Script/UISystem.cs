using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
	public Text scoreText;
	public Text lifeText;


	void Update()
	{
		scoreText.text =  "Score :" + PlayerCollision.score.ToString("0");
		lifeText.text =  PlayerCollision.life.ToString("0") + "x";
	}
}
