using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

    public GameObject slashHitBox;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
            if(slashHitBox != null) {
                slashHitBox.GetComponent<SlashScript>().slash();
                //print("Slash!");
            } else {
                print("ERROR! no slash hit box detected");
            }
        }
	}
}
