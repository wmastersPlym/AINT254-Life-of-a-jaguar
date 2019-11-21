using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject popup;
    public GameObject popupContainer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V)) {
            DisplayNotification("TEST", "TEST");
        }
    }


    //public 

    public void GainXP(int xp) {
        gameObject.GetComponent<XPSystem>().AddXP(xp);
    }

    public void DisplayNotification(string title, string msg) {

        GameObject popupInstace = Instantiate(popup, popup.transform.position, popup.transform.rotation) as GameObject;
        popupInstace.transform.SetParent( popupContainer.transform, false);

        popupInstace.GetComponent<PopupContructor>().SetUp(title, msg);
        popupInstace.SetActive(true);
        
    }
}
