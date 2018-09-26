using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Rigidbody rigid;
    private bool start;
    private float startTime;
	// Use this for initialization
	void Start () {
        rigid = gameObject.GetComponent<Rigidbody>();
        start = false;
        startTime = 2f;
	}
	
	// Update is called once per frame
	void Update () {
        if (!start)
        {
            startTime -= Time.deltaTime;
            if (startTime<=0)
            {
                rigid.AddForce(new Vector3(-0.05f, 0, -1f), ForceMode.Impulse);
                start = true;
            }
        }
        if (start)
        {
            if (rigid.velocity.z < 1 )
            {
                rigid.AddForce(new Vector3(0, 0, -0.7f));
            }
            if (rigid.velocity.x < 1)
            {
                rigid.AddForce(new Vector3(-0.7f, 0, 0));
            }
        }
    }

    public void RestartBall()
    {
        startTime = 2f;
        start = false;
        transform.localPosition = new Vector3(0, 0.02f, 0);
        rigid.velocity = new Vector3(0, 0, 0);
    }
}
