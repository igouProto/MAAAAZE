using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleCamFollow : MonoBehaviour
{
    public Transform endpoint;
    public Transform muralViewPoint;
    public GameObject cam;
    public bool gravConActivated = ToggleBallSwitches.gravConActivated;
    public bool isInFrontofMural = Mural.playerInFront;
    public float time = .5f;
    private Controller playerController;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Controller>();
    }

    void Update()
    {
        gravConActivated = ToggleBallSwitches.gravConActivated;
        isInFrontofMural = Mural.playerInFront;

        if (playerController.dead)
        {
            Mural.playerInFront = false;
            ToggleBallSwitches.gravConActivated = false;
            cam.GetComponent<CameraMove>().enabled = true;
        }

        if (gravConActivated)
        {
            cam.GetComponent<CameraMove>().enabled = false;
            transform.position = Vector3.Lerp(transform.position, endpoint.position, time);
            transform.rotation = Quaternion.Lerp(transform.rotation, endpoint.rotation, time);
        }
        else if (isInFrontofMural)
        {
            cam.GetComponent<CameraMove>().enabled = false;
            transform.position = Vector3.Lerp(transform.position, muralViewPoint.position, time);
            transform.rotation = Quaternion.Lerp(transform.rotation, muralViewPoint.rotation, time);
        }
        else
            cam.GetComponent<CameraMove>().enabled = true;


    }
}
