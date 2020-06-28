using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;
    public Animator anim;
    public HashIDs hash;
    public bool hurt;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
    }

    // Update is called once per frame
    void Update()
    {
        bool hurt = Input.GetButton("Hurt");
        anim.SetBool(hash.isHurt, hurt);
    }
}

