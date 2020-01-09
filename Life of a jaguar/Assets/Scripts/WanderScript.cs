using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderScript : MonoBehaviour {

    public float speed;
    public float scaredSpeed;
    public float turnSpeed = 100f;
    public bool isScared;

    private bool doingSomething = false;
    private bool moveForwards = false;
    private float turnDirection = 0f;
    private GameObject player;

    private Rigidbody rb;


	// Use this for initialization
	void Start () {
        isScared = false;
        doingSomething = false;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        if (isScared) {
            moveForwards = true;
            runAwayFromPlayer();
        } 

        if (Input.GetKeyDown(KeyCode.K)) {
            print("DoingSomething: " + doingSomething + ", moveForwards: " + moveForwards);
        }

		if(!doingSomething) {
            decideWhatToDo();
        }

        if(moveForwards && !isScared) {
            transform.Rotate(Vector3.up * (turnDirection * turnSpeed * Time.deltaTime));
            rb.velocity = transform.forward * speed;
        } else if(moveForwards && isScared) {
            //transform.Rotate(Vector3.up * (turnDirection * turnSpeed * Time.deltaTime));
            rb.velocity = transform.forward * scaredSpeed;
        }

        
	}

    private void decideWhatToDo() {
        if (Mathf.Floor(Random.Range(0, 2)) == 0) {
            //print("Wonder");
            wander();
        } else {
            //print("IDLE");
            idle();
        }
    }


    private void wander() {
        doingSomething = true;
        StartCoroutine( startWander());
        
    }

    IEnumerator startWander() {
        moveForwards = true;
        turnDirection = Random.Range(-1f, 2f);
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

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            isScared = true;

            doingSomething = true;
            runAwayFromPlayer();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            StartCoroutine( stopScareAfterSeconds(3f));
        }
    }

    public void runAwayFromPlayer() {

        Vector3 direction = transform.position - player.transform.position;
        transform.rotation = Quaternion.LookRotation(direction);

        /*doingSomething = true;
        isScared = true;
        moveForwards = true;
        while(isScared) {
            Vector3 direction = transform.position - player.transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
        }
        moveForwards = false;*/
    }

    IEnumerator stopScareAfterSeconds(float timeToWait) {
        yield return new WaitForSeconds(timeToWait);
        isScared = false;
        doingSomething = false;
        moveForwards = false;
    }
}
