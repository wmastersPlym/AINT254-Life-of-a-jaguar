using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float walkSpeed;
    public float turnSpeed;
    //public float sprintSpeed;
    //public float sneakSpeed;

    public float speed;
    private float currentSpeed;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        speed = walkSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        
        // Moving forward and back
		if(Input.GetAxisRaw("Vertical") > 0.1) {
            Move(1f);
        } else if(Input.GetAxisRaw("Vertical") < -0.1) {
            Move(-0.25f);
        } else {
            currentSpeed = 0f;
        }

        // Turning
        if(Input.GetAxisRaw("Horizontal") > 0.1 || Input.GetAxisRaw("Horizontal") < -0.1) {
            Turn();
        }

        /*if(Input.GetKey(KeyCode.LeftShift)) {
            speed = sneakSpeed;
        } else if(Input.GetKey(KeyCode.LeftControl)) {
            speed = sprintSpeed;
        } else {
            speed = walkSpeed;
        }*/

        // Locks the x and z rotation to 0 ( stops jag from falling over )
        transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
    }

    private void Move(float modifyer) {
        currentSpeed = speed * modifyer;
        rb.velocity = transform.forward * speed * modifyer;
    }

    private void Turn() {
        if(currentSpeed != 0) {
            transform.Rotate(Vector3.up * (Input.GetAxis("Horizontal") * turnSpeed * (1/Mathf.Abs(currentSpeed))*2 *Time.deltaTime));
        } else {
            transform.Rotate(Vector3.up * (Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime));
        }
        
    }
}
