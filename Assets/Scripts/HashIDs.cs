using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashIDs : MonoBehaviour
{
    public int speed;
    public int isCounch;
    public int isHurt;
    public int isJump;
    public int jumpState;
    public int jumping;
    public int isDead;
    // Start is called before the first frame update
    void Start()
    {
        speed = Animator.StringToHash("Speed");
        isCounch = Animator.StringToHash("isCounch");
        isHurt = Animator.StringToHash("isHurt");
        isJump = Animator.StringToHash("isJump");
        jumpState = Animator.StringToHash("Base Layer.jump");
        jumping = Animator.StringToHash("Jumping");
        isDead = Animator.StringToHash("isDead");
    }
}
