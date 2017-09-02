using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStarter : MonoBehaviour {
    private QuestDiary questDiary;

    [Header("Need Values")]
     public string questID = "";

    void Start(){
        questDiary = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<QuestDiary>();
    }

    private void OnTriggerEnter(Collider other){
        if(questDiary.getQuest(questID) != null)
         (questDiary.getQuest(questID).gameObject).SetActive(true);
    }
}
