using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody rb;
    public int switchCount;
    public float speed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ToggleBallSwitches.gravConActivated)
        {

            float h = 0;
            float v = 0;
            switchCount = SwitchManagement.numOfSwitches;
            if (Input.GetKey(KeyCode.J))
                h = -1;
            if (Input.GetKey(KeyCode.L))
                h = 1;
            if (Input.GetKey(KeyCode.I))
                v = 1;
            if (Input.GetKey(KeyCode.K))
                v = -1;

            if (Input.acceleration.x < 0.15)
                h = -1;
            if (Input.acceleration.x > 0.15)
                h = 1;
            if (Input.acceleration.y > 0.15)
                v = 1;
            if (Input.acceleration.y < 0.15)
                v = -1;

            //Vector3 movementaccel = new Vector3(Input.acceleration.x, 0.0f, Input.acceleration.y);

            Vector3 movement = new Vector3(h, 0.0f, v);
            rb.AddForce(movement * 10);

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("BallSwitch"))
        {
            SwitchManagement.numOfSwitches--;
            other.gameObject.SetActive(false);
        }
    }
}
