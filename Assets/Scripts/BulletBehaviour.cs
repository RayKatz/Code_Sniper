using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {


    int bounceCounter = 0;
    public int bounceThreshhold = 10;

	// Update is called once per frame
	void Update ()
    {
	    if(bounceCounter >= bounceThreshhold)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision c)
    {
        ++bounceCounter;
    }
}
