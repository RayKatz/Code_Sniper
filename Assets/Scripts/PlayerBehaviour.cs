using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerBehaviour : NetworkBehaviour {

    [SyncVar]
    public int health = 10;

    public void LoseHealth(int damage)
    {
        if (isServer)
        {
            health -= damage;
            if (health <= 0)
            {
                health = 0;
                Die();
            }
        }
    }

    void Die()
    {
        Debug.Log("Player died.");
        //Dying and stuff
    }
}
