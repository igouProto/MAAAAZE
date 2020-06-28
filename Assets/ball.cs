using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    private Animator anim;
    private GameObject target;
    private Controller playerControll;
    private HashIDs hash;

    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag(Tags.player);
        anim = target.GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
        playerControll = target.GetComponent<Controller>();

    }

    private void Update()
    {
        if (transform.position.y < 0)
            Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other == target.GetComponent<CapsuleCollider>())
        {
            playerControll.dead = true;
            anim.SetBool(hash.isDead, playerControll.dead);
        }
    }

}
