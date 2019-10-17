using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {
    
    public float turnSpeed = 1f;

	// Use this for initialization
	void Start () {
        


    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("l")) {
            print("Jag pos: " + transform.position.ToString() + ", Mouse pos: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }



        /*Vector3 posVec = Input.mousePosition;
        posVec.z = transform.position.z - Camera.main.transform.position.z;
        posVec = Camera.main.ScreenToWorldPoint(posVec);
        posVec.y = 0;
        transform.LookAt(posVec);*/

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)) {

            Vector3 targetLocation = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            
            transform.LookAt(targetLocation);
        }

    }

    
}
