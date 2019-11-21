using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killScript : MonoBehaviour {

    public int xpGained;
    public GameManager gameManager;

    private void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }


    public void kill() {
        Destroy(gameObject);

        gameManager.GainXP(xpGained);
    }
}
