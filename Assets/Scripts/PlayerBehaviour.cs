using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    public int health = 10;

    // Use this for initialization

    public void LoseHealth(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died.");
        //Dying and stuff
    }
}
