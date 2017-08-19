using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBasic : MonoBehaviour {
    public enum QuestStatus : int { Inactive, Active, Success, Fail };

    [Header("Quest Details")]
     public int questID = -1;
     public string questTitle = "";

    [Header("Quest Status")]
     public QuestStatus questStatus = QuestStatus.Inactive;
     //public string[] questTextProgress;
     public List<QuestStage> questStageList;

    [Header("Quest Prize")]
     public int gainedXP    = 0;
     public int gainedMoney = 0;
     public ItemClass[] gainedItems;
     //wykonaj inny skrypt albo event

    [HideInInspector]
     public List<string> questActuallyTextProgress;


    private Status playerStatus;
    private QuestDiary questDiary;

    private int questActuallyStage = 0;

    
    private void Start(){
        questActuallyTextProgress = new List<string>();

        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Status>();
        questDiary = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<QuestDiary>();

        
        questStageList[questActuallyStage].enabled = true;
        questActuallyTextProgress.Add(questStageList[questActuallyStage].stageDescription);

        questStatus = QuestStatus.Active;
        //Add log in screen.
    }

    private void FixedUpdate(){
        if(questStatus == QuestStatus.Active) {
            if(questStageList[questActuallyStage].isSuccess)
             this.nextStage();
        }
    }



    public void nextStage(){
        if(questStatus == QuestStatus.Active) {
            questStageList[questActuallyStage].enabled = false;

             questActuallyStage += 1;

            if(questActuallyStage == questStageList.Count){
                questStatus = QuestStatus.Success;


                playerStatus.modifyStatus(Status.eStatus.Health, -20);

                //Give rewards.
            }

            else {
                questStageList[questActuallyStage].enabled = true;

                questActuallyTextProgress.Add(questStageList[questActuallyStage].stageDescription);
            }
        }
    }

    public void setFail(){
        questStatus = QuestStatus.Fail;
    }
}
