using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

    public Player playerStats;
    public Happening[] happening;

	// Use this for initialization
	void Start () {
        playerStats = new Player();
	}  
	
	// Update is called once per frame
	void Update () {
	
	}

    
}
