using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour {
    public Animator anim;
    public GameObject player;
    public float distance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position,player.transform.position)<distance)
        {
            anim.SetBool("ifClose",true);
        }
        else
        {
            anim.SetBool("ifClose", false);
        }
	}
}
