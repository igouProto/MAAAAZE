using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dummy_movement : MonoBehaviour
{
    public Camera cam;
    public float speed = 3f;

    //public bool pressed = false;

    private Joystick joystick;

    private void Awake()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal") + joystick.Horizontal * 1f; 
        float v = Input.GetAxisRaw("Vertical") + joystick.Vertical * 1f; 

        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        var direction = forward * v + right * h;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}