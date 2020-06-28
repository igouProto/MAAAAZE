using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserCollider : MonoBehaviour
{
    public GameObject laser0;
    public GameObject laser1;
    public GameObject laser2;
    public GameObject laser3;
    public GameObject laser4;
    public bool isActive = true;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (!laser0.active && !laser1.active && !laser2.active && !laser3.active && !laser4.active)
        {
            gameObject.active = false;
            isActive = false;
        }
           
    }
}
