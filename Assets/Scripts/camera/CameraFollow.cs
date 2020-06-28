using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;

    Vector3 camPos;
    float camPosMag;
    Vector3 newPos;

    void Start()
    {
        camPos = transform.position - target.position;
        camPosMag = camPos.magnitude - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 stdPos = target.position + camPos;
        Vector3 abovePos = target.position + Vector3.up * camPosMag;
        Vector3[] checkpoints = new Vector3[5];
        checkpoints[0] = stdPos;
        checkpoints[1] = Vector3.Lerp(stdPos, abovePos, 0.25f);
        checkpoints[2] = Vector3.Lerp(stdPos, abovePos, 0.5f);
        checkpoints[3] = Vector3.Lerp(stdPos, abovePos, 0.75f);
        checkpoints[4] = abovePos;

        for (int i = 0; i < checkpoints.Length; i++)
        {
            if (viewPosCheck(checkpoints[i]))
                break;
        }
        transform.position = Vector3.Lerp(transform.position, newPos, smoothing * Time.deltaTime);
        smoothLookAt();
    }

    bool viewPosCheck(Vector3 checkPos)
    {
        RaycastHit hit;
        if (Physics.Raycast(checkPos, target.position - checkPos, out hit, camPosMag))
        {
            if (hit.transform != target)
                return false;
        }
        newPos = checkPos;
        return true;
    }

    void smoothLookAt()
    {
        Vector3 targetPos = target.position - transform.position;
        Quaternion lookAtRotation = Quaternion.LookRotation(targetPos, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, smoothing * Time.deltaTime);
    }
}
