using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerDos : MonoBehaviour {

    private GameObject wayPoint;
    private Vector3 wayPointPos;
    private float speed = 1.0f;


    void Start()
    {
        wayPoint = GameObject.FindGameObjectWithTag("Player2");
    }

    void Update()
    {
        wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
        transform.LookAt(wayPointPos);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            GameManagerSurvival.Instance.GetCoin();
        }
    }
}
