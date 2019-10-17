using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject ObjectToSpawn;
    public float timeDelay;

    private bool doingSomething = false;

    // Start is called before the first frame update
    void Start()
    {
        if(ObjectToSpawn == null)
        {
            print("Object not set on spawner");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!doingSomething)
        {
            startSpawning();
        }
    }


    private void startSpawning()
    {
        doingSomething = true;
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {

        yield return new WaitForSeconds(timeDelay);
        Instantiate(ObjectToSpawn, transform);
        doingSomething = false;
    }

}
