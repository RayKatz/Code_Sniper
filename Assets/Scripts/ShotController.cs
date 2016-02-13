using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

    public GameObject bulletPrefab;
    public GameObject mouseCollider;
    LayerMask hitLayer;

	// Use this for initialization
	void Start ()
    {
        hitLayer = 1 << mouseCollider.layer;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,100,hitLayer))
        {
            Vector3 target = hit.point;
            target.y = 0.1f;
            Debug.DrawLine(transform.position, target);
        }
	}
}
