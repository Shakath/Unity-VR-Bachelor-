using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour {
	private Transform player;
	private Transform coords;
	public float speed = 1f;
	public float rotationSpeed = 0.3f;
	public int movementRange = 5;
    public float avoidanceRange = 2.5f;
	float distanceToPlayer;
	private Collider objectScan;
	private bool colliding = false;
    private bool returnToCenter = false;
    private Animator anim;
	public Vector3 moveDirection;


	void Start () {
		objectScan = GetComponent<BoxCollider> ();
		anim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
	}

	void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "Terrain")
        {
            moveDirection = Vector3.Lerp(moveDirection, transform.up, 0.5f);
        }
		if (other.gameObject.tag == "Rocks") {
			moveDirection = this.transform.position - other.gameObject.transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}



	void Movement(){
		player = player.GetComponent<Transform> ();
		Vector3 avoidPlayer = new Vector3(0,0,0);

        distanceToPlayer = Vector3.Distance (player.transform.position, transform.position);
		speed = 1;
		float rotationSpeedModifier = 1.0f;
		anim.speed = 1;

        if(distanceToPlayer > 20.0f)
        {
            returnToCenter = true;
        }
        if (returnToCenter)
        {
            moveDirection = player.transform.position- transform.position;
            if (distanceToPlayer < 10.0f)
            {
                returnToCenter = false;
            }
        } else if (distanceToPlayer < avoidanceRange)
        {
            Debug.DrawLine(transform.position, player.transform.position);
            avoidPlayer = (this.transform.position - player.transform.position);
			speed = 2;
			anim.speed = 2;
			rotationSpeedModifier = 4.0f;
            moveDirection = avoidPlayer;

		} else if (Random.Range(0, 100) < 1)
        {
            Debug.DrawLine(transform.position, player.transform.position);
            Vector3 desiredPoint = Vector3.Lerp(player.transform.position, transform.position, 0.8f);
            moveDirection = -transform.position
                + Vector3.MoveTowards(transform.position, player.transform.position, movementRange / 2)
                +new Vector3(
                Random.Range(-movementRange, movementRange),
                Random.Range(-movementRange, movementRange),
                 Random.Range(-movementRange, movementRange));
			
		}

			
		if (moveDirection != Vector3.zero) {
			transform.rotation = Quaternion.Slerp (transform.rotation, 
				Quaternion.LookRotation (moveDirection), 
													Time.deltaTime * rotationSpeed * rotationSpeedModifier);
			
		}


        transform.Translate(0, 0, Time.deltaTime * speed);
    }



}
