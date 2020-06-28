using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attached : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
