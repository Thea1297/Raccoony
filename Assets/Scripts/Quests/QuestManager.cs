using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestManager : MonoBehaviour
{
    public QuestObject[] quests;
    public bool[] questCompleted;
    public DialogManager dialogManager;

    public string itemCollected;

    // Start is called before the first frame update
    void Start()
    {
        questCompleted = new bool[quests.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowQuestText(string questText)
    {
        dialogManager.dialogLines = new string[1];
        dialogManager.dialogLines[0] = questText;
        dialogManager.currentLine = 0;
        dialogManager.ShowDialog(dialogManager.dialogLines);
    }
}
