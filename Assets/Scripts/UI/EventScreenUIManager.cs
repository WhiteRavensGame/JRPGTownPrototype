using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class EventScreenUIManager : Singleton<EventScreenUIManager> {

    public GameObject eventScreenLayer;

    /*
    [Header("Event Objects")]
    public Text textEvent;
    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3; 
    */

    public void ShowEventScreen(bool show, int day)
    {
        eventScreenLayer.SetActive(show);
        if (show)
        {
            if (day == 1)
            {
                DialogueManager.StartConversation("TestDay1");
            }
            else if (day == 2)
            {
                DialogueManager.StartConversation("TestDay2");
            }
            else if (day == 3)
            {
                DialogueManager.StartConversation("TestDay3");
            }
            else if (day == 4)
            {
                DialogueManager.StartConversation("TestDay4");
            }
            else if (day == 5)
            {
                DialogueManager.StartConversation("TestDay5");
            }
            else if (day == 6)
            {
                DialogueManager.StartConversation("TestDay6");
            }
            else if (day == 7)
            {
                DialogueManager.StartConversation("TestDay7");
            }
            else if (day == 8)
            {
                DialogueManager.StartConversation("TestDay8");
            }
            else if (day == 9)
            {
                DialogueManager.StartConversation("TestDay9");
            }
            else if (day == 10)
            {
                DialogueManager.StartConversation("TestDay10");
            }
            else
            {
                //Continue if no events (should NOT happen. Just for safety).
                EventScreenUIManager.Instance.ShowEventScreen(false, -1);
                LevelBuildingUIManager.Instance.ShowLevelBuildingUIManager(true);
            }

            //int indexHappening = day - 1;
            //UpdateEventScreen(GameManager.Instance.happening[indexHappening]);
        }

    }

    /*
    public void UpdateEventScreen(Happening whatHappened)
    {
        textEvent.text = whatHappened.description;
        if (whatHappened.choice1 != "")
        {
            choice1.GetComponentInChildren<Text>().text = whatHappened.choice1;
            choice1.SetActive(true);
        }
        else
        {
            choice1.SetActive(false);
        }

        if (whatHappened.choice2 != "")
        {
            choice2.GetComponentInChildren<Text>().text = whatHappened.choice2;
            choice2.SetActive(true);
        }
        else
        {
            choice2.SetActive(false);
        }

        if (whatHappened.choice3 != "")
        { 
            choice3.GetComponentInChildren<Text>().text = whatHappened.choice3;
            choice3.SetActive(true);
        }
        else
        {
            choice3.SetActive(false);
        }

    }

    public void ChoiceSelected(int index)
    {
        //Guess we hardcode it for now...
        Debug.Log("You chose " + index);
    }
    */


}
