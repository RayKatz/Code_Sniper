using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ShotController : NetworkBehaviour {

    public GameObject bulletPrefab;
    public GameObject mouseCollider;
    public float shotSpeed = 100f;
    LayerMask hitLayer;
    LayerMask boundLayer;
    public float distance = 1f;
    Vector3 target;
    Ray lastRay;
    
    public bool lockedIn = false;

    public GameObject shotParticles;

	// Use this for initialization
	void Start ()
    {
        hitLayer = 1 << mouseCollider.layer;
        boundLayer = 1 << 9;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray;

        if (!lockedIn)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            lastRay = ray;
        }
        else
        {
            ray = lastRay;
        }

        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,100,hitLayer))
        {
            target = hit.point;
            target.y = 0.1f;

            Ray targetRay = new Ray();
            targetRay.origin = transform.position;
            targetRay.direction = Vector3.Normalize(target - transform.position);

            Physics.Raycast(targetRay, out hit, 100, boundLayer);

            Debug.DrawLine(transform.position, hit.point);

            if (Input.GetMouseButtonUp(0))
            {
                if (lockedIn)
                {
                    Vector3 dir = Vector3.Normalize(target - transform.position);
                    Vector3 origin = transform.position + (dir * distance);
                    GameObject bullet = (GameObject)Instantiate(bulletPrefab, origin, Quaternion.identity);
                    GameObject effect = (GameObject)Instantiate(shotParticles, transform.position, Quaternion.LookRotation(dir));

                    NetworkServer.Spawn(bullet);
                    NetworkServer.Spawn(effect);

                    Destroy(effect, 1f);

                    bullet.GetComponent<Rigidbody>().AddForce(dir * shotSpeed);

                    lockedIn = false;
                }
                else
                {
                    lockedIn = true;
                }
            }

            if (Input.GetMouseButtonUp(1) && lockedIn)
                lockedIn = false;
        }
	}
}
