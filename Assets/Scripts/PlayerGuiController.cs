using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerGuiController : MonoBehaviour {

    public Text shotText;
    public Text healthText;
    public Text enemyText;

    public ShotController sCon;
    public PlayerBehaviour ownPlayer;
    public PlayerBehaviour enemyPlayer;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(sCon.lockedIn)
        {
            shotText.text = "Leftclick - Confirm\nRightclick - Abort";
        }
        else
        {
            shotText.text = "Leftclick - Set target";
        }

        healthText.text = "Bunker HP:\n" + ownPlayer.health + "/10 HP";
        enemyText.text = "Enemy HP:\n" + enemyPlayer.health + "/10 HP";
    }
}
