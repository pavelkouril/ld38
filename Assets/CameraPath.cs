using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPath : MonoBehaviour {

    public GameObject waypoint0;
    public GameObject waypoint1;
    public GameObject waypoint2;
    public GameObject waypoint3;
    public GameObject waypoint4;
    public float speed = 1.0f;
    private Transform[] waypoint;
    private int current;
    private int next;

    // Use this for initialization
    void Start () {
        waypoint = new Transform[5];
        waypoint[0] = waypoint0.transform;
        waypoint[1] = waypoint1.transform;
        waypoint[2] = waypoint2.transform;
        waypoint[3] = waypoint3.transform;
        waypoint[4] = waypoint4.transform;
        current = 0;
        next = 1;

    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 a = transform.position;
        Vector3 b = waypoint[current].position;

        if (Vector3.Distance(a, b) > 0.05f)
        {
            Vector3 dir = b - a;
            dir.Normalize();
            transform.position = transform.position + dir * Time.deltaTime * speed;
        }

        Quaternion qa = transform.rotation;
        Quaternion qb = Quaternion.LookRotation(waypoint[next].position - transform.position);
        transform.rotation = Quaternion.Slerp(qa, qb, Time.deltaTime);
    }

    public void Next()
    {
        if (next != 4)
        {
            current++;
            next++;
        }
    }
}
