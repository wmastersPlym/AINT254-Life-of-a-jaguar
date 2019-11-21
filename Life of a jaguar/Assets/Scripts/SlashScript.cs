using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashScript : MonoBehaviour {

    //private bool showSlashBox = false;

    private bool preyInTrigger;
    private Collider preyInTriggerCollider;
    

	// Use this for initialization
	void Start () {
        preyInTrigger = false;
        //showSlashBox = false;
        GetComponent<MeshRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void slash() {
        
        if(preyInTrigger) {
            print("Slashed!");
            preyInTriggerCollider.GetComponent<killScript>().kill();
            preyInTrigger = false;
        }

    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Prey") {
            preyInTrigger = true;
            preyInTriggerCollider = other;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Prey") {
            preyInTrigger = false;
        }
    }
}
