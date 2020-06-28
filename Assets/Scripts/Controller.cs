using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Vector3 movement;
    private Animator anim;
    private float speed;
    private HashIDs hash;
    public bool dead = false;
    private float speedDampTime = 0.1f;
    private bool jump;
    private bool counch;
    private const float c_speed = 0.4f;
    private const float r_speed = 1f;
    private const float j_speed = 1.4f;
    private Rigidbody rb;
    private float jumpforce = 10.0f;
    private float verticalVelocity;
    public float beforeJumpTime = 0.5f;
    public bool jumping = false;
    private bool jumpPressed;
    public bool textjump = false;
    public GameObject ball;

    private Joystick joystick;
    private JoyButton2 button;
    public string name;
    public float reloadDelay = 3f;
    public AnimatorClipInfo[] m_CurrentClipInfo;

    //public Camera cam;
    //public float camspeed = 3f;



    // Start is called before the first frame update
    void Awake()
    {
        speed = 0f;
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
        rb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
        button = FindObjectOfType<JoyButton2>();
        dead = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") + joystick.Horizontal * 1f;
        float v = Input.GetAxis("Vertical") + joystick.Vertical * 1f;

        if (!dead)
        {
            Movement(h, v);
        }

        if (dead)
        {
            reloadDelay -= Time.deltaTime;
            if (reloadDelay <= 0)
                Application.LoadLevel(Application.loadedLevel);
        }
    }

    void Update()
    {
        m_CurrentClipInfo = anim.GetCurrentAnimatorClipInfo(0);
        name = m_CurrentClipInfo[0].clip.name;

        if (transform.position.y < -4)
        {
            anim.SetBool(hash.isHurt, true);
            dead = true;
            anim.SetBool(hash.isDead, dead);
        }
        else
        {
            anim.SetBool(hash.isHurt, false);
        }

        counch = Input.GetButton("Counch");
        if (button != null)
            jump = Input.GetButton("Jump") || button.pressed;

        anim.SetBool(hash.isJump, jump);
        anim.SetBool(hash.isCounch, counch);

        if (jump & !jumping)
            jumpPressed = true;

        if (jumpPressed & !jumping)
        {
            beforeJumpTime -= Time.deltaTime;
            if (beforeJumpTime < 0)
            {
                jumpPressed = false;
                beforeJumpTime = 0.5f;
                m_CurrentClipInfo = anim.GetCurrentAnimatorClipInfo(0);
                jumping = (m_CurrentClipInfo[0].clip.name == "jump");
                anim.SetBool(hash.jumping, jumping);
            }
        }
        else
        {
            m_CurrentClipInfo = anim.GetCurrentAnimatorClipInfo(0);
            jumping = (m_CurrentClipInfo[0].clip.name == "jump");
            anim.SetBool(hash.jumping, jumping);
        }


    }

    void Movement(float horizontal, float vertical)
    {
        if (!jumpPressed)
        {
            if (horizontal != 0f || vertical != 0f)
            {
                if (vertical == 0f)
                {
                    anim.SetFloat(hash.speed, 3f, speedDampTime, Time.deltaTime);
                }
                else
                {
                    movement.Set(horizontal, 0, vertical);
                    if (counch)
                        movement = movement.normalized * c_speed * Time.deltaTime * 10;
                    else
                        if (jumping)
                        movement = movement.normalized * j_speed * Time.deltaTime * 10;
                    else
                        movement = movement.normalized * r_speed * Time.deltaTime * 10;

                    anim.SetFloat(hash.speed, 5.5f, speedDampTime, Time.deltaTime);
                    transform.Translate(movement);
                }

                //Rotating(horizontal);

            }
            else
                // Otherwise set the speed parameter to 0.
                anim.SetFloat(hash.speed, 0);

        }
    }

   


}
