using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerVariables : MonoBehaviour
{
    public GameObject questDialog;
    private Quest pendingQuest;

    public TextMeshProUGUI trackerText;

    public TextMeshProUGUI qTitleText;
    public TextMeshProUGUI qDescText;
    public TextMeshProUGUI qBottomText;

    public GameObject itemDialog;
    public TextMeshProUGUI iTitleText;
    public TextMeshProUGUI iDescText;

    public QuestLine[] questLines;
    private int questLinesAmount = 0;

    public List<Quest> activeQuests;
    private int itemsRead = 0;
    public int itemsAmount = 10;

    public JournalController jc;

    private void Start()
    {
        trackerText.text = "Lär dig om artefakter från vikingatiden: " + itemsRead + "/" + itemsAmount;
    }

    private void Update()
    {
        // Debugging
        if (Input.GetKeyDown(KeyCode.P))
        {
            foreach (QuestLine ql in questLines)
            {
                ql.DubugActiveQuest();
            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            // Accept the quest
            ActivateQuest();
            questDialog.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            // Deny the quest
            questDialog.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("QuestGiver"))
        {
            OpenQuestDialog(other.GetComponent<QuestGiver>().GetQuest());
        }

        if (other.gameObject.CompareTag("InfoItem"))
        {
            OpenItemDialog(other.GetComponent<Item>());
            other.GetComponent<Item>().StartTimer();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("QuestGiver"))
        {
            CloseQuestDialog();
        }

        if (other.gameObject.CompareTag("InfoItem"))
        {
            CloseItemDialog();
            if (other.GetComponent<Item>().itemRead && !other.GetComponent<Item>().itemCounted)
            {
                itemsRead++;
                other.GetComponent<Item>().itemCounted = true;

                jc.itemFound[other.GetComponent<Item>().journalIndex] = true;
                jc.ChangeIconColor(other.GetComponent<Item>().journalIndex);

                trackerText.text = "Lär dig om artefakter från vikingatiden: " + itemsRead + "/" + itemsAmount;

                if (itemsRead >= itemsAmount)
                {
                    // Quest to find all items is complete
                    trackerText.text = "Du har hittat alla artefakter!";
                    Debug.Log("All items found");
                }
            }
            other.GetComponent<Item>().EndTimer();
        }
    }

    private void OpenQuestDialog(Quest q)
    {
        pendingQuest = q;
        questDialog.SetActive(true);
        SetDialogText(q);

        if (q.isActive)
        {
            qBottomText.text = "Kom tillbaka när du har hittat alla föremål";
        }
        if (q.isComplete)
        {
            qTitleText.text = "Grattis!";
            qDescText.text = "Du har hittat alla föremål, ta nu tiden att lära dig om artefakterna.";
            qBottomText.text = "Tryck på 'Mellanslag' för att läsa om kända artefakter";
        }
    }

    private void SetDialogText(Quest q)
    {
        qTitleText.text = q.title;
        qDescText.text = q.description;
    }

    private void CloseQuestDialog()
    {
        questDialog.SetActive(false);
    }

    private void ActivateQuest()
    {
        pendingQuest.isActive = true;

        int i = 0;
        foreach (Quest q in activeQuests)
        {
            if (q.Equals(pendingQuest))
            {
                i++;
            }
        }
        if (i < 1)
        {
            activeQuests.Add(pendingQuest);
        }
    }

    private void OpenItemDialog(Item i)
    {
        itemDialog.SetActive(true);
        iTitleText.text = i.title;
        iDescText.text = i.description;
    }

    private void CloseItemDialog()
    {
        itemDialog.SetActive(false);
    }
}
