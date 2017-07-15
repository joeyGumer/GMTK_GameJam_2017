using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    //Public attributes
    public float speed = 10.0f;
    public GameObject hookPrefab;

    //Private attributes
    private bool throwingHook = false;
    private GameObject hook = null;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!throwingHook)
            BasicMovement();

        if(Input.GetKeyDown("space"))
            ThrowHook();
    }


    //Methods
    //Basic movement for testint
    void BasicMovement()
    {
            
        float movement = (Input.GetAxis("Horizontal") * speed) * Time.deltaTime;

        transform.Translate(movement,0, 0);
    }

    //Throws the Hook
    void ThrowHook()
    {
        throwingHook = true;

       hook = Instantiate(hookPrefab, transform);

        Vector3 tar = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tar.z = 0;

        hook.GetComponent<HookBehaviour>().target = tar;
    }

}
