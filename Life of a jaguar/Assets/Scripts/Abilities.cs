using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public CapsuleCollider scareCollider;


    public float sprintSpeed;
    private bool sprintEnabled = false;

    public float sneakSpeed;
    private bool sneakEnabled = false;

    public float defaultScareRadius;
    public float sprintScareRadius;
    public float sneakScareRadius;
    


    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {

        //askForNotification("TestPost", "This is a test pop up to make sure the auto sizing of the pop ups are working. Please remember to delete");

        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && sneakEnabled) { // Sneak Ability
            playerMovement.speed = sneakSpeed;
            scareCollider.radius = sneakScareRadius;
        } else if(Input.GetKey(KeyCode.LeftControl) && sprintEnabled) { // Sprint Ability
            playerMovement.speed = sprintSpeed;
            scareCollider.radius = sprintScareRadius;
        } else {
            playerMovement.speed = playerMovement.walkSpeed;
            scareCollider.radius = defaultScareRadius;
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
            askForNotification("Ability Unlocked!", "Sprint ability enabled (LCTRL). Beware, prey will run away from you earlier if you are sprinting");
        } else if (!sneakEnabled){
            SetSneakEnabled(true);
            askForNotification("Ability Unlocked!", "Sneak ability enabled (LSHIFT)");
        }
    }

    private void askForNotification(string title, string message) {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().DisplayNotification(title, message);
    }
}
