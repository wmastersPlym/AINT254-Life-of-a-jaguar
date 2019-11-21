using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{

    public float sprintSpeed;
    private bool sprintEnabled = false;

    public float sneakSpeed;
    private bool sneakEnabled = false;


    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && sneakEnabled) { // Sneak Ability
            playerMovement.speed = sneakSpeed;
        } else if(Input.GetKey(KeyCode.LeftControl) && sprintEnabled) { // Sprint Ability
            playerMovement.speed = sprintSpeed;
        } else {
            playerMovement.speed = playerMovement.walkSpeed;
        }
    }

    public void SetSprintEnabled(bool b) {
        sprintEnabled = b;
    }

    public void SetSneakEnabled(bool b) {
        sneakEnabled = b;
    }

    public void UnlockAbility() {
        if(!sprintEnabled) {
            SetSprintEnabled(true);
            askForNotification("Ability Unlocked!", "Sprint ability enabled (LCTRL)");
        } else if (!sneakEnabled){
            SetSneakEnabled(true);
            askForNotification("Ability Unlocked!", "Sneak ability enabled (LSHIFT)");
        }
    }

    private void askForNotification(string title, string message) {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().DisplayNotification(title, message);
    }
}
