using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float walkSpeed;
    public float sprintSpeed;
    public float sneakSpeed;

    private float speed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        speed = walkSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("Vertical") > 0.1) {
            Move(1f);
        } else if(Input.GetAxisRaw("Vertical") < -0.1) {
            Move(-0.25f);
        }

        if(Input.GetKey(KeyCode.LeftShift)) {
            speed = sneakSpeed;
        } else if(Input.GetKey(KeyCode.LeftControl)) {
            speed = sprintSpeed;
        } else {
            speed = walkSpeed;
        }
	}

    private void Move(float modifyer) {
        //rb.AddRelativeForce(new Vector3(0f, 0f, Input.GetAxis("Vertical") * (speed * modifyer) * Time.deltaTime));
        rb.velocity = transform.forward * speed * modifyer;
    }
}
