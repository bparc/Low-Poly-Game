using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour {
    public enum NPCGender : int { Male, Female };

    [Header("NPC Details")]
     public string npcName;
     public NPCGender npcGender;


    public string questPath = ""; //debug
	

	void Update () {
		//Here AI
	}


    public void startTalking(){
        ///TODO (by RhAnjiE) - "Add Dialogue System"


        //* DEBUG *//
        QuestDiary questDiary = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<QuestDiary>(); //debug

        if(questDiary != null && questDiary.getQuest(questPath) != null)
         (questDiary.getQuest(questPath).gameObject).SetActive(true);
    }
}
