using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPathWaypoint : MonoBehaviour {

    public GameObject cameraCollision;
    private CameraPath cameraPath;
    private bool active;

	// Use this for initialization
	void Start () {
        cameraPath = cameraCollision.GetComponent<CameraPath>();
        active = true;
    }

    void Update()
    {
        if (active)
        {
            if (Vector3.Distance(transform.position, cameraCollision.transform.position) < 0.1f)
            {
                cameraPath.Next();
                active = false;
            }
        }
    }
}
