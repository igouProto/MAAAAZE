using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManagement : MonoBehaviour
{
    public GameObject ball;
    public static int numOfSwitches = 9;
    private void Update()
    {
        if (numOfSwitches <= 0)
        {
            gameObject.active = false;
            ball.SetActive(false);
            ToggleBallSwitches.gravConActivated = false;
        }

    }
}
