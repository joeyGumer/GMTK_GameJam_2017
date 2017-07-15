﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookBehaviour : MonoBehaviour {

    public Vector3 target;
    public float target_offset = 0.5f;
    public float max_distance = 10;
    public float hook_speed = 50;
    public float player_speed = 50;

   // public bool to_destroy = false;

    Vector3 direction;
    Vector3 player_position;
    Vector3 attach_position;
    float distance;
    DistanceJoint2D joint;

    //[---read only----!]
    public bool grabed;
    public bool returning;

    delegate void HookState();
    HookState hookState;


    // Use this for initialization
    void Start () {

        grabed = returning = false;
        player_position = transform.position;
        joint = GetComponent<DistanceJoint2D>();
        CalculateDirection();
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

        if (other.gameObject.tag == "Player" && returning)
            Destroy(this.gameObject);

    }

    void CalculateDirection()
    {
        direction = (target - transform.position).normalized;
    }
    void Move()
    {
        Vector3 mov = direction * hook_speed * Time.deltaTime;
        transform.Translate(mov.x, mov.y, 0);

        distance = (transform.position - player_position).magnitude;
    }

    //Hook behaviour states-------

    //The hook is thrown
    void Throw()
    {
        Move();

        if (distance >= max_distance)
        {
            returning = true;
            hookState = Return;
        }
        else if(grabed)
        {
            joint.connectedBody = transform.parent.gameObject.GetComponent<Rigidbody2D>();
            joint.distance = 5;
            attach_position = transform.position;
            hookState = Go;
        }

        
    }
    

    //Player goes to the direction of the hook
    void Go()
    {
        transform.position = attach_position;

        if(joint.distance > 0.0f)
            joint.distance -= player_speed * Time.deltaTime;
        
        if(Input.GetKeyDown(KeyCode.G))
        {
            joint.connectedBody = null;
            returning = true;
            hookState = Return;
        }
        
    }

    //The hook returns to the player
    void Return()
    {
        target = transform.parent.position;
        target.z = 0;
        CalculateDirection();
        Move();

        

        /*if(distance <= target_offset)
        {
            Destroy(this.gameObject);
        }*/
       
    }

    private void OnDrawGizmos()
    {
        
    }
}
