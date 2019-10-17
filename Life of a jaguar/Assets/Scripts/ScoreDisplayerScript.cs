using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayerScript : MonoBehaviour
{

    private int score;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpScore(int MorePoints)
    {
        score += MorePoints;
        updateText();
    }

    public void updateText()
    {
        GetComponent<Text>().text = ("Rabbits caught: " + score);
    }
}
