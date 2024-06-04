using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public int questNum;
    private QuestManager questManager;
    public string itemName;


    // Start is called before the first frame update
    void Start()
    {
        questManager=FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!questManager.questCompleted[questNum] && questManager.quests[questNum].gameObject.activeSelf)
            {
                questManager.itemCollected = itemName;
                gameObject.SetActive(false);
            }
            
        }
    }
}
