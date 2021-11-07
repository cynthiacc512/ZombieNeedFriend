using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTime : MonoBehaviour
{

    public int countTime;
    public Text countdownDisplay;
    public PlayerMovement movement;

    public AudioSource fight;

    private void Start()
    {
        StartCoroutine(CountdownStart());
    }

    IEnumerator CountdownStart()
    {
        while (countTime > 0)
        {
            countdownDisplay.text = countTime.ToString();

            yield return new WaitForSeconds(1f);

            countTime--;
        }
        fight.Play();
        countdownDisplay.text = "GET PREN!";

        yield return new WaitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);

        movement.enabled = true;
    }
}
