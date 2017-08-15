using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDiary : MonoBehaviour {
    private List <QuestBasic> questsList;

    public bool displayDiary = false;


	void Start (){
		loadQuests();
	}
	

    //TODO (by RhAnjiE) - "Apply unity hotkeys"
	void Update (){
		if(Input.GetKeyDown(KeyCode.J))
         displayDiary = !displayDiary;

        if(Input.GetKeyDown(KeyCode.Escape))
         displayDiary = false;
	}

    //TODO (by RhAnjiE) - "Create better UI"
    private void OnGUI(){
        int i = 1;

        if(displayDiary){
            foreach(QuestBasic quest in questsList){
                GUI.Label(new Rect(20, 20 * i, 500, 50), "[" + quest.questTitle + "] " + quest.questDescription);

                i+=1;
            }
        }
    }

    private void loadQuests(){
        //TODO (by RhAnjiE) - "Add loading from the yaml file"


       questsList = new List<QuestBasic>();

        QuestBasic helloQuest = gameObject.AddComponent<QuestBasic>();
         helloQuest.create(1, "Hello Quest", "This is first quest! (not question)");

         helloQuest.gainedXP = 100;
         helloQuest.gainedMoney = 50;

        questsList.Add(helloQuest);


        /*QuestBasic helloQuest = new QuestBasic(1, "Hello Quest", "This is first quest! (not question)");
         helloQuest.gainedXP = 100;
         helloQuest.gainedMoney = 50;
         questsList.Add(helloQuest);*/
    }
}
