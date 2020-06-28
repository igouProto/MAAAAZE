using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    private GameObject player;
    public float loadDelay = 1.5f;
    public bool playerInGoal = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
    }

    void Update()
    {
        if (playerInGoal)
            loadDelay -= Time.deltaTime;
        if (loadDelay <= 0)
            Application.LoadLevel(Application.loadedLevel + 1);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            playerInGoal = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInGoal = false;
            loadDelay = 1.5f;
        }

    }
}
