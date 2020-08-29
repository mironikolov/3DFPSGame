using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunHolderAnim : MonoBehaviour {
    public Animator anim;

    private GameObject weapon;
	// Use this for initialization
	void Start () {
        weapon = GameObject.FindGameObjectWithTag("Weapon");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetButton("Fire1") && weapon.GetComponent<ShotgunScript>().bulletsLeftInMag>0)
        {
            anim.SetBool("isShooting", true);
        }
        else
        {
            anim.SetBool("isShooting", false);
        }
    }
}
