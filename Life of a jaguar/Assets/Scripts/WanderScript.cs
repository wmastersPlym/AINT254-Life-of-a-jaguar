using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderScript : MonoBehaviour {

    public float speed;

    private bool doingSomething = false;
    private bool moveForwards = false;

    private Rigidbody rb;


	// Use this for initialization
	void Start () {
        doingSomething = false;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.K)) {
            print("DoingSomething: " + doingSomething + ", moveForwards: " + moveForwards);
        }

		if(!doingSomething) {
            decideWhatToDo();
        }

        if(moveForwards) {
            rb.velocity = transform.forward * speed;
        }
	}

    private void decideWhatToDo() {
        if (Mathf.Floor(Random.Range(0, 2)) == 0) {
            print("Wonder");
            wander();
        } else {
            print("IDLE");
            idle();
        }
    }


    private void wander() {
        doingSomething = true;
        StartCoroutine( startWander());
        
    }

    IEnumerator startWander() {
        moveForwards = true;
        yield return new WaitForSeconds(randomTime());
        moveForwards = false;
        doingSomething = false;
    }

    private void idle() {
        doingSomething = true;
        StartCoroutine( startIdle());
    }

    IEnumerator startIdle() {
        yield return new WaitForSeconds(randomTime());
        doingSomething = false;
    }


    private float randomTime() {
        return (Random.Range(2, 5));
    }
    
}
