using System;
using UnityEngine;

public class Status : MonoBehaviour {
     public enum eStatus { Health, Mana, Stamina, Experience };
     public enum eStatistics { MaxHealth, MaxMana, MaxStamina, Strenght };

    [Header("UI Textures")]
     public Texture2D health;
     public Texture2D mana;
     public Texture2D stamina;


     private int maxHealth  = 100, currentHealth  = 100;
     private int maxMana    = 100, currentMana    = 100;
     private int maxStamina = 100, currentStamina = 100;

     private int maxExpToLevel = 100, currentExp = 0;
     private int currentLevel = 1;

     private int strenght = 10;
     private bool isDead = false;


    private float barWidth, barHeight;

    private void Awake() {
        barHeight = Screen.height * 0.02f;
        barWidth = barHeight * 10.0f;
    }

    private void Update() {
        if(!isDead){
            if(currentExp >= maxExpToLevel){
                this.levelUp(maxExpToLevel - currentExp);
            }

            if(currentHealth <= 0) {
                //...

                isDead = true;
            }
        }
    }

    ///TODO(by RhAnjiE) - "Create better UI"
    private void OnGUI() {
        GUI.DrawTexture(new Rect((Screen.width - barWidth) - 10, (Screen.height - barHeight) - 50, currentHealth * barWidth / maxHealth, barHeight), health);
        GUI.DrawTexture(new Rect((Screen.width - barWidth) - 10, (Screen.height - barHeight) - 30, currentMana * barWidth / maxMana, barHeight), mana);
        GUI.DrawTexture(new Rect((Screen.width - barWidth) - 10, (Screen.height - barHeight) - 10, currentStamina * barWidth / maxStamina, barHeight), stamina);
    }



    public void modifyStatus(eStatus status, int value) {
        switch (status) {
            case eStatus.Health:
                currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);    break;
            case eStatus.Mana:
                currentMana = Mathf.Clamp(currentMana + value, 0, maxMana);          break;
            case eStatus.Stamina:
                currentStamina = Mathf.Clamp(currentStamina + value, 0, maxStamina); break;
            case eStatus.Experience:
                currentExp += Math.Abs(value); break;
        }
    }

    public void modifyStatistics(eStatistics state, int value) {
        switch (state) {
            case eStatistics.MaxHealth:
                maxHealth += value;  break;
            case eStatistics.MaxMana:
                maxMana += value;    break;
            case eStatistics.MaxStamina:
                maxStamina += value; break;

            case eStatistics.Strenght:
                strenght += value;   break;
        }

        Debug.Log("Success! Value changed by " + value);
    }

    private void levelUp(int tempExp){
        currentLevel += 1;

        maxExpToLevel *= 2;
        currentExp = tempExp;


          maxHealth += 10;
          maxStamina += 20;


        //Information on screen.
    }
}
