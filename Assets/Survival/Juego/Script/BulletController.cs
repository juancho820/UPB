using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    [SerializeField]
    private int force;

	void Update () {

        GetComponent<Rigidbody>().AddForce(transform.forward * force);

    }
}
