using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class GameManager : Singleton<GameManager> {

    public Player playerStats;
    public Happening[] happening;

    // Use this for initialization
    void Start() {
        playerStats = new Player();
    }

    // Update is called once per frame
    void Update() {

    }

    public void ConversationEnded()
    {
        //Handles the End of NPC chats during Free Time.
    }

    public void ContinueSimulation()
    {
        //Put the script to continue moving the simulation here.
        Debug.Log("Unpause the Simulation Part");
    }

    public void MainDayConversationEnded()
    {
        //Events to call when the pre-Free Time conversation is over
        Debug.Log("Load the pre-conversation things.");

       
        
    }

    public void CopyPlayerStatsToLUA()
    {
        Debug.Log("Player Stats -> LUA");

        //Call when conversation starts!
        DialogueLua.SetVariable("InnLevel", GameManager.Instance.playerStats.levelInn);
        DialogueLua.SetVariable("ItemLevel", GameManager.Instance.playerStats.levelItem);
        DialogueLua.SetVariable("WeaponLevel", GameManager.Instance.playerStats.levelWeapon);
        DialogueLua.SetVariable("VillagersCount", GameManager.Instance.playerStats.villagersCount);
    }

    public void CopyLUAToPlayerStats()
    {
        Debug.Log("LUA -> Player Stats");

        //Call when conversation ENDS.
        GameManager.Instance.playerStats.levelInn = DialogueLua.GetVariable("InnLevel").AsInt;
        GameManager.Instance.playerStats.levelItem = DialogueLua.GetVariable("ItemLevel").AsInt;
        GameManager.Instance.playerStats.levelWeapon = DialogueLua.GetVariable("WeaponLevel").AsInt;
        GameManager.Instance.playerStats.villagersCount = DialogueLua.GetVariable("VillagersCount").AsInt;

        //TODO: Make sure this gets called first before anything else to properly sync the data.
        LoadNextGameEvent();
    }

    public void LoadNextGameEvent()
    {
        //Prototype ONLY! Progress Day, and go back to villagers allocation.
        //TODO: Fix this part, make sure that player is at end before progressing.
        GameManager.Instance.playerStats.dayCount += 1;
        EventScreenUIManager.Instance.ShowEventScreen(false, -1);
        ResourceAllocateUIManager.Instance.ShowResourceAllocateScreen(true);
    }
}
