using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class BulletBehaviour : NetworkBehaviour {


    int bounceCounter = 0;
    public int bounceThreshhold = 10;

    public GameObject explosion;

	// Update is called once per frame
	void Update ()
    {
	    if(bounceCounter >= bounceThreshhold)
        {
            Destroy(Instantiate(explosion,transform.position,Quaternion.identity),1f);
            NetworkServer.Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision c)
    {
        ++bounceCounter;
        if (c.gameObject.GetComponent<PlayerBehaviour>())
        {
            c.gameObject.GetComponent<PlayerBehaviour>().LoseHealth(bounceCounter);
            Destroy(Instantiate(explosion, transform.position, Quaternion.identity), 1f);
            NetworkServer.Destroy(gameObject);
        }
    }
}
