using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mural : MonoBehaviour
{
    public Material cleanedMat;
    public static bool playerInFront = false;
    public GameObject player;
    private JoyButton joyButton;
    public bool breathDetected;
    public float totalBreath = 1f;
    // Start is called before the first frame update
    void Start()
    {
        joyButton = FindObjectOfType<JoyButton>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("leftfoot"))
        {
            playerInFront = true;
            breathDetected = micInput.isBreathingIntoMic;
            if (breathDetected)
            {
                totalBreath -= Time.deltaTime;
                if (totalBreath <= 0)
                {
                    Renderer muralface = transform.Find("MuralImage").GetComponent<Renderer>();
                    muralface.material = cleanedMat;
                }

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerInFront = false;
        totalBreath = 0.5f;
    }
}
