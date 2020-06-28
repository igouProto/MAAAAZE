using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fenceDeactivate : MonoBehaviour
{
    public GameObject fence;
    public float standDelay = 1.5f;
    public GameObject player;

    private bool audioPlayed = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            standDelay -= Time.deltaTime;
            if (standDelay <= 0)
            { 
                fence.SetActive(false);
                if (!audioPlayed)
                {
                    GetComponent<AudioSource>().Play();
                    audioPlayed = true;
                }

            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            standDelay = 1.5f;
    }
}
