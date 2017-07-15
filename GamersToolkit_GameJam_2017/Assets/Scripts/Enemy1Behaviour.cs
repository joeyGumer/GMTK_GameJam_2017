using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Behaviour : MonoBehaviour {

    //Attributes
    public float speed = 10;
    public GameObject GOpositionA;
    public GameObject GOpositionB;
    public float target_offset = 0.2f;

    private Vector3 target;
    private Vector3 dir;
    private float distance;
    private Vector3 posA;
    private Vector3 posB;


	// Use this for initialization
	void Start ()
    {
        dir = (GOpositionA.transform.position - GOpositionB.transform.position).normalized;
        target = posA =  GOpositionA.transform.position;
        posB = GOpositionB.transform.position;
   
    }
	
	// Update is called once per frame
	void Update ()
    {
        Move();
	}

    void Move()
    {

        distance = (target - transform.position).magnitude;

        if(distance <= target_offset)
        {
            dir = -dir;
          if(target == posA)
            {
                target = posB;
            }
           else
            {
                target = posA;
            }
        }
 
        Vector3 movement = dir * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
