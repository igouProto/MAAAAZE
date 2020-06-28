using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Transform head;
    private Transform rotOffset;
    private Transform player;
    private Controller playerControll;
    [SerializeField]
    private Vector3 offsetPosition;
    private Vector3 origRot;

    private float rotX;
    private float rotY;

    public float ud;
    public float lf;
    private Touch initTouch = new Touch();
    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag(Tags.player).transform;
        head = GameObject.FindGameObjectWithTag("Head").transform;
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        ud = 0f;
        playerControll = player.GetComponent<Controller>();
    }

    private void FixedUpdate()
    {
        foreach (Touch touch in Input.touches)
        {
            float previousX = 0, previousY = 0;

            if (touch.position.x > 450)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    initTouch = touch;
                    previousX = 0;
                    previousY = 0;
                }
                else if (touch.phase == TouchPhase.Moved)
                {

                    float deltaY = initTouch.position.y - touch.position.y;
                    float deltaX = initTouch.position.x - touch.position.x;

                    if (Mathf.Abs(deltaX) < Mathf.Abs(previousX))
                    {
                        if (Mathf.Abs(deltaX) + 20 < Mathf.Abs(previousX))
                        {
                            initTouch.position.Set(touch.position.x, initTouch.position.y);
                            previousX = 0;
                        }
                    }
                    else
                    {
                        previousX = deltaX;
                    }

                    if (Mathf.Abs(deltaY) < Mathf.Abs(previousY))
                    {
                        if (Mathf.Abs(deltaY) + 20 < Mathf.Abs(previousY))
                        {
                            initTouch.position.Set(initTouch.position.x, touch.position.y);
                            previousY = 0;
                        }
                    }
                    else
                    {
                        previousY = deltaY;
                    }


                    if (Mathf.Abs(deltaY) > Mathf.Abs(deltaX))
                    {
                        if (deltaY < -50 && ud < 45)
                            ud += Time.deltaTime * 100f;
                        else if (deltaY > 50 && ud > -45)
                            ud -= Time.deltaTime * 100f;
                    }


                    if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
                    {
                        if (deltaX < -0)
                        {
                                target.Rotate(0, +Time.deltaTime * 100f, 0);
                        }

                        else if (deltaX > 0)
                        {
                                target.Rotate(0, -Time.deltaTime * 100f, 0);
                        }
                    }           
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    initTouch = new Touch();
                    previousX = 0;
                    previousY = 0;
                }
            }
        }


       
    }

    private void Update()
    {
        Refresh();
    }

    public void Refresh()
    {

        if (playerControll.dead)
        {
            offsetPositionSpace = Space.Self;
            offsetPosition += new Vector3(0f,2f*Time.deltaTime,0f);
        }
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            lookAt = true;
            transform.position = target.TransformPoint(offsetPosition);
            
        }
        else
        {
            lookAt = false;
            transform.position = head.GetComponent<SphereCollider>().transform.position + offsetPosition;
           
        }

        // compute rotation
        if (lookAt)
        {
            transform.LookAt(head);
        }
        else
        {
            transform.rotation = target.rotation * Quaternion.Euler(ud, 0, 0);
        }
    }
}

