using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDiary : MonoBehaviour {
    [Header("Ready Quests in Game")]
     public List<QuestBasic> questsList;

    [HideInInspector]
     public bool displayDiary = false;


    private int index = 0;



    //TODO (by RhAnjiE) - "Apply unity hotkeys"
    void FixedUpdate (){
        if(Input.GetKeyDown(KeyCode.J))
         displayDiary = !displayDiary;

        if(Input.GetKeyDown(KeyCode.Escape))
         displayDiary = false;
        

        if(displayDiary){
            if(Input.GetKeyDown(KeyCode.RightArrow) && index < questsList.Count-1)
             index++;

            if(Input.GetKeyDown(KeyCode.LeftArrow) && index > 0)
             index--;
        }
	}

    //TODO (by RhAnjiE) - "Create better UI"
    private void OnGUI(){
        if(displayDiary && questsList[index].questStatus == QuestBasic.QuestStatus.Active){
            GUI.Label(new Rect(20, 30, 500, 50),  questsList[index].questTitle);

            for(int i = 0; i < questsList[index].questActuallyTextProgress.Count; ++i){
                GUI.Label(new Rect(30, 50 + 15 * i, 500, 50), questsList[index].questActuallyTextProgress[i]);
            }
        }
    }

    public QuestBasic getQuest(string id){
        QuestBasic script = (GameObject.FindGameObjectWithTag("Player").transform).Find("Quest System/"+id).GetComponent<QuestBasic>();

        if(script == null)
         Debug.LogError("External script tried to refer to a non-exist quest!");

        return script;
    }
}
