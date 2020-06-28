using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBall : MonoBehaviour
{
    public GameObject ball;
    public float spawnInterval = 2f;
    public Transform spawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnInterval, spawnInterval);
    }

    void Spawn()
    {
        Instantiate(ball, spawnpoint.position, spawnpoint.rotation);
    }
}
