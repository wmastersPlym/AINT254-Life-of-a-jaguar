using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPSystem : MonoBehaviour
{
    // Algorithm for xp:
    // xp = 50*lvl^2

    public int totalXP;
    public int level;
    public Slider slider;
    public Text lowerLvl;
    public Text upperLvl;

    private GameManager gameManager;

    void Start() {

        gameManager = gameObject.GetComponent<GameManager>();

        totalXP = 0;
        level = 0;
        UpdateGUI();
    }

    private void Update() {
        // USED FOR TESTING XP SYSTEM
        //if(Input.GetKeyDown(KeyCode.V)) {
        //    AddXP(15);
        //   print("XP: " + totalXP + ", level: " + level + ", calculated level: " + CalculateLevel());
        //}
        //if (Input.GetKeyDown(KeyCode.C)) {
        //    print("level: " + level + ", calculated level: " + CalculateLevel());
        //}
    }

    public void AddXP(int xp) {
        totalXP += xp;
        CheckLevelUp();
        UpdateGUI();
    }

    public void CheckLevelUp() {
        int lvlA = level;
        level = CalculateLevel();
        if(lvlA < level) {
            print("LEVEL UP!!!");
            gameManager.Player.GetComponent<Abilities>().UnlockAbility();
            CheckLevelUp();
        }
    }

    public void UpdateGUI() {
        lowerLvl.text = "lvl " + level;
        upperLvl.text = "lvl " + (level+1);
        slider.minValue = GetXPForLevel(level);
        slider.maxValue = GetXPForLevel(level+1);
        slider.value = totalXP;
    }

    private int CalculateLevel() {
        return Mathf.FloorToInt(Mathf.Pow((totalXP / 50), (1f / 2f)));
    }

    private int GetXPForLevel(int lvl) {
        return Mathf.CeilToInt(50 * (Mathf.Pow(lvl, 2f)));
    }

    private int GetXPForNextLevel() {
        return GetXPForLevel(level + 1);
    }
}
