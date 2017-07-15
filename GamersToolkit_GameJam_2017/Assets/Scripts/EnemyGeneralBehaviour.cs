using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneralBehaviour : MonoBehaviour {

    public int hp = 1;

    public bool hit = false;
    public int damage_type = 0;

    private bool hit_by_red = false;
    private bool hit_by_green = false;


    private void Update()
    {
        if(hp == 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void GetHit(bool hook_type)
    {
        if (!hook_type && damage_type == 0)
        {
            hit = true;
            hp--;
        }
        else if (hook_type && damage_type == 1)
        {
            hit = true;
            hp--;
        }
        else if (damage_type == 2)
        {
            if (hit_by_green && hit_by_red)
            {
                hit = true;
                hp--;

                hit_by_green = false;
                hit_by_red = false;
            }
            else if (!hook_type)
                hit_by_red = true;  
            else if (hook_type)
                hit_by_green = true;
        }

    }
