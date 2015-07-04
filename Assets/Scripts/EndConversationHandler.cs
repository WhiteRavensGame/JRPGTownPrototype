using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class EndConversationHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnConversationStart()
    {
        //Debug.Log("CONVERSATION START!");
        GameManager.Instance.CopyPlayerStatsToLUA();
    }
    public void OnConversationEnd()
    {
       // Debug.Log("CONVERSATION OVER. Do closing in this function");
        GameManager.Instance.CopyLUAToPlayerStats();
    }

}
