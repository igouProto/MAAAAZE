using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBallSwitches : MonoBehaviour
{
    public GameObject BallSwitches;
    public GameObject player;
    public float triggerDelay = .5f;
    public bool isOnGravitySwitch = false;
    public static bool gravConActivated = false;
    public bool isGravActivated = false;

    private void Awake()
    {
        isOnGravitySwitch = false;
        gravConActivated = false;
        isGravActivated = false;
        BallSwitches.SetActive(gravConActivated);
    }

    private void Update()
    {
        isGravActivated = gravConActivated;
        BallSwitches.SetActive(gravConActivated);
        if (isOnGravitySwitch)
        {
            triggerDelay -= Time.deltaTime;
            if (triggerDelay <= 0)
            {
                gravConActivated = true;
            }
               
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            isOnGravitySwitch = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            gravConActivated = false;
            isOnGravitySwitch = false;
            triggerDelay = .5f;
        }
    }
}
