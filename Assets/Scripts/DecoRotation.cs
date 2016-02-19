using UnityEngine;
using System.Collections;

public class DecoRotation : MonoBehaviour {

    public float intervall = 3;
    Vector3 startRot;
    Vector3 targetRot;
    Hashtable hash;


	void Start ()
    {
        InvokeRepeating("TurnIt", 0f, intervall);
	}
	
	// Update is called once per frame
	void TurnIt ()
    {
        hash = new Hashtable();
        hash.Add("x", Random.Range(-1f, 1f));
        hash.Add("y", Random.Range(-1f, 1f));
        hash.Add("z", Random.Range(-1f, 1f));
        hash.Add("time", intervall);
        hash.Add("easetype", iTween.EaseType.easeInOutCubic);

        iTween.RotateBy(gameObject, hash);
    }
}
