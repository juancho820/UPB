using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAi : MonoBehaviour {
    private bool side;
    private float speed = 4;

    [SerializeField]
    private GameObject bola;

	void Start () {
        side = true;
	}
	
	void Update () {
        transform.position = Vector3.Lerp( transform.position, new Vector3 (bola.transform.position.x, transform.position.y, transform.position.z), Time.deltaTime * speed);
    }
}
