using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitchDeactivation : MonoBehaviour
{
    public GameObject laser;
    public Material unlockedMat;
    public bool triggered = false;
    private GameObject player;

    private JoyButton joybutton;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
        joybutton = FindObjectOfType<JoyButton>();
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
            if (Input.GetButton("Switch") || joybutton.pressed)
            {
                LaserDeactivation();
                triggered = true;
            }
                
    }
    void LaserDeactivation()
    {
        laser.SetActive(false);
        Renderer screen = transform.Find("prop_switchUnit_screen").GetComponent<Renderer>();
        screen.material = unlockedMat;
        GetComponent<AudioSource>().Play();
    }
}
