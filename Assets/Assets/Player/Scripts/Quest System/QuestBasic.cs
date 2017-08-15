using UnityEngine;

public class QuestBasic : MonoBehaviour {
    public enum Status : int { Inactive, Active, Success, Fail };

    [Header("Quest Details")]
     public int questID = -1;
     public string questTitle = "";
     public string questDescription = "";

    [Header("Quest Status")]
     public Status questStatus = Status.Inactive;

    [Header("Quest Prize")]
     public int gainedXP    = 0;
     public int gainedMoney = 0;
     public GameObject[] gainedItems;


	public void create(int QuestID, string QuestTitle, string QuestDescription) {
		this.questID = QuestID;
        this.questTitle = QuestTitle;
        this.questDescription = QuestDescription;

        //...
	}
}
