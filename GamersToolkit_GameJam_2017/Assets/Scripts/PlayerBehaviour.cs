using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    //Public attributes
    public float speed = 10.0f;
    public GameObject hookPrefab;

    //Private attributes
    private GameObject hook_number_1 = null;
    private GameObject hook_number_2 = null;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


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

        if (hook_number_1 == null)
        {
            hook_number_1 = Instantiate(hookPrefab, transform);

            Vector3 tar = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tar.z = 0;

            hook_number_1.GetComponent<HookBehaviour>().target = tar;
        }
        else if(hook_number_2 == null)
        {
            hook_number_2 = Instantiate(hookPrefab, transform);

            Vector3 tar = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tar.z = 0;

            hook_number_2.GetComponent<HookBehaviour>().target = tar;           
        }
    }

}
