using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

    /* ------------ STATUS ------------ */

      private int maxHealth  = 100, currentHealth  = 100;
      private int maxMana    = 100, currentMana    = 100;
      private int maxStamina = 100, currentStamina = 100;

      private int strenght = 10;

     public enum eStatus { Health, Mana, Stamina };
     public enum eState { MaxHealth, MaxMana, MaxStamina, Strenght };

    //private bool isDead = false; is assigned but its value is never used

    /* ------------ STATUS ------------ */

    public Texture2D health;
     public Texture2D mana;
     public Texture2D stamina;

    private float barWidth, barHeight;



    public void modifyStatus(eStatus status, int value) {
        switch (status) {
            case eStatus.Health:
                currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);    break;
            case eStatus.Mana:
                currentMana = Mathf.Clamp(currentMana + value, 0, maxMana);          break;
            case eStatus.Stamina:
                currentStamina = Mathf.Clamp(currentStamina + value, 0, maxStamina); break;
        }

        Debug.Log("Success! Value changed by " + value);
    }

    public void modifyState(eState state, int value) {
        switch (state) {
            case eState.MaxHealth:
                maxHealth += value;  break;
            case eState.MaxMana:
                maxMana += value;    break;
            case eState.MaxStamina:
                maxStamina += value; break;

            case eState.Strenght:
                strenght -= value;   break;
        }

        Debug.Log("Success! Value changed by " + value);
    }

    private void Update() {
        if(currentHealth <= 0) {
            //...

            //isDead = true; is assigned but its value is never used
        }
    }



    private void Awake() {
        barHeight = Screen.height * 0.02f;
        barWidth = barHeight * 10.0f;
    }

    private void OnGUI() {
        //GUI.DrawTexture(new Rect((Screen.width - barWidth) - 20, (Screen.height - barHeight * 3) - 35, barWidth + 20, barHeight * 3 + 35), background);

        GUI.DrawTexture(new Rect((Screen.width - barWidth) - 10, (Screen.height - barHeight) - 50, currentHealth * barWidth / maxHealth, barHeight), health);
        GUI.DrawTexture(new Rect((Screen.width - barWidth) - 10, (Screen.height - barHeight) - 30, currentMana * barWidth / maxMana, barHeight), mana);
        GUI.DrawTexture(new Rect((Screen.width - barWidth) - 10, (Screen.height - barHeight) - 10, currentStamina * barWidth / maxStamina, barHeight), stamina);
    }
}
