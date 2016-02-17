using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

    public GameObject bulletPrefab;
    public GameObject mouseCollider;
    public float shotSpeed = 100f;
    LayerMask hitLayer;
    LayerMask boundLayer;
    public float distance = 1f;   //TODO: we have to bring the spawned close enough to look like it's shot from the player, but far enough to not hit himself
    Vector3 target;
    Ray lastRay;

    public bool lockedIn = false;

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
                    bullet.GetComponent<Rigidbody>().AddForce(dir * shotSpeed);
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


    /*
    //incoming magic...

    //Reference to the LineRenderer we will use to display the simulated path
    public LineRenderer sightLine;

    //number of segments to calculate - more give a smoother line
    public int segmentCount = 20;

    //length for each segment
    public float segmentScale = 1f;

    //gameobeject we're actually pointing at
    private Collider _hitObject;
    public Collider hitObject { get { return _hitObject; } }

    void FixedUpdate()
    {
        simulatePath();
    }

    //Simulate the path of a launched ball
    //Slight errors are inherent in the numerical method used

    void simulatePath()
    {
        Vector3[] segments = new Vector3[segmentCount];

        //the first line point is where the player is
        segments[0] = transform.position;

        //the initial velocity
        Vector3 segVelocity = Vector3.Normalize(target - transform.position);

        //reset out hit object
        _hitObject = null;

        for (int i = 1; i < segmentCount; ++i)
        {
            //time it takes to traverse one segment of length segScale
            float segTime = (segVelocity.sqrMagnitude != 0) ? segmentScale / segVelocity.magnitude : 0;

            //check to see if we're going to hit a physics object
            RaycastHit hit;
            if(Physics.Raycast(segments[i-1], segVelocity, out hit, segmentScale))
            {
                //remember who we hit
                _hitObject = hit.collider;

                //set next position to the position where we hit the physics object
                segments[i] = segments[i - 1] + segVelocity.normalized * hit.distance;
                //flip the velocity to simulate a bounce
                segVelocity = Vector3.Reflect(segVelocity, hit.normal);


                if (_hitObject.gameObject.layer == 10 || _hitObject.gameObject.layer == 11)
                {
                    ++i;
                    for (; i < segmentCount; ++i)
                        segments[i] = segments[i - 1];
                    break;
                }
                    
            }
            //if our raycast hit no objects, then set the next position to the last one plus v*t
            else
            {
                segments[i] = segments[i - 1] + segVelocity * segTime;
            }

        }

        //at the end, apply our simulations to the line renderer

        //some colors!

        Color startColor = Color.red;
        Color endColor = Color.black;
        startColor.a = 1;
        endColor.a = 0;
        sightLine.SetColors(startColor, endColor);

        sightLine.SetVertexCount(segmentCount);
        for (int i = 0; i < segmentCount; ++i)
            sightLine.SetPosition(i, segments[i]);

    }*/
}
