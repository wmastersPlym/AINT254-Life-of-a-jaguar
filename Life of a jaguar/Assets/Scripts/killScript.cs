using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void kill() {
        Destroy(gameObject);

        GameObject.Find("RabbitsCaughtText").GetComponent<ScoreDisplayerScript>().UpScore(1);
    }
}
