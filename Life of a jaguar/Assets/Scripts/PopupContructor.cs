using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopupContructor : MonoBehaviour
{

    public Text title;
    public Text body;

    public int ttl = 5;

    public void SetUp(string title, string body) {
        this.title.text = title;
        this.body.text = body;
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startCountdown());
    }

    IEnumerator startCountdown() {
        yield return new WaitForSeconds(ttl);
        Destroy(gameObject);
    }
}
