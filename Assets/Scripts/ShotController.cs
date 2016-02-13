using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

    public GameObject bulletPrefab;
    public GameObject mouseCollider;
    public float shotSpeed = 100f;
    LayerMask hitLayer;
    public float distance = 1f;   //TODO: we have to bring the spawned close enough to look like it's shot from the player, but far enough to not hit himself

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

            if (Input.GetMouseButtonUp(0))
            {
                Vector3 dir = Vector3.Normalize(target - transform.position);
                Vector3 origin = transform.position + (dir*distance);
                GameObject bullet = (GameObject) Instantiate(bulletPrefab, origin, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().AddForce(dir * shotSpeed);
            }
        }

        
	}
}
