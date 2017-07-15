using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookBehaviour : MonoBehaviour {

    public Vector3 target;
    public float max_distance = 10;
    public float speed;
   // public bool to_destroy = false;

    private Vector3 direction;
    private Vector3 player_position;
    private float distance;

    //[---read only----!]
    public bool grabed;

    delegate void HookState();
    HookState hookState;


    // Use this for initialization
    void Start () {

        grabed = false;
        player_position = transform.position;
        direction = (target - transform.position).normalized;
        hookState = Throw;


    }
	
	// Update is called once per frame
	void Update () {
        hookState();
	}

    //Utils


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "grab")
            grabed = true;
            
    }

    void Move()
    {
        Vector3 mov = direction * speed * Time.deltaTime;
        transform.Translate(mov.x, mov.y, 0);

        distance = (transform.position - player_position).magnitude;
    }

    //Hook behaviour states
    void Throw()
    {
        Move();

        if (distance >= max_distance)
        {
            hookState = Return;
            direction = -direction;
        }
        else if(grabed)
        {

            hookState = Go;
        }

        
    }
    
    void Go()
    {

    }

    void Return()
    {
        Move();

        if(distance <= 0.2)
        {
            Destroy(this);
        }
    }

}
