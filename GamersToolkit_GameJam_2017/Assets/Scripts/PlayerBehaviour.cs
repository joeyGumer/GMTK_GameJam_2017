using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    //Public attributes
    public float speed = 20.0f;
    public GameObject hookPrefab;

    //Private attributes
    private GameObject hook_number_1 = null;
    private GameObject hook_number_2 = null;
    bool on_feet = false;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame

    private void FixedUpdate()
    {

          

    }
    void Update () {

        if(on_feet)
            BasicMovement();

        if (Input.GetKeyDown("e"))
        {
            ThrowHook(false);
        }
        else if(Input.GetKeyDown("r"))
        {
            ThrowHook(true);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Hook")
            on_feet = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Hook")
            on_feet = false;
    }

    //Methods
    //Basic movement for testint
    void BasicMovement()
    {
            
        float movement = (Input.GetAxis("Horizontal") * speed) * Time.deltaTime;

        if (movement != 0.0f)
        {
            Vector2 move = new Vector2(movement, 0);
            transform.Translate(move);
        }
    }

    //Throws the Hook
    void ThrowHook(bool hook_type)
    {

        if (hook_type && hook_number_1 == null)
        {
            hook_number_1 = Instantiate(hookPrefab, transform);

            Vector3 tar = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tar.z = 0;

            
            hook_number_1.GetComponent<HookBehaviour>().target = tar;
            hook_number_1.GetComponent<HookBehaviour>().hook_type = hook_type;

        }
        else if(!hook_type && hook_number_2 == null)
        {
            hook_number_2 = Instantiate(hookPrefab, transform);

            Vector3 tar = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tar.z = 0;

            hook_number_2.GetComponent<HookBehaviour>().target = tar;
            hook_number_2.GetComponent<HookBehaviour>().hook_type = hook_type;
        }
    }

}
