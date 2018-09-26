using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.EventSystems;

public class CapsuleController : MonoBehaviour {

    private Rigidbody rb;
    private Animation anim;

    public static bool ispressed = false;

    void Start () {

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {

        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, y);

        rb.velocity = movement * 2f;

        if(x != 0 && y != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x,y) * Mathf.Rad2Deg,transform.eulerAngles.z);
        }
        if (x != 0 || y != 0)
        {
            if (ispressed == true)
            {
                anim.Play("RunFire");
            }
            else
            {
                anim.Play("Run");
            }
        }
        else
        {
            
            if (ispressed == true)
            {
                anim.Play("Fire");
            }
            else
            {
                anim.Play("Idle");
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameManagerSurvival.Instance.Loser();
            Time.timeScale = 0;
        }
    }
    public void Fire()
    {
        ispressed = true;
    }

    public void noFire()
    {
        ispressed = false;
    }
}
