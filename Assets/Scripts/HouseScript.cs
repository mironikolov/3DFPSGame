using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour {
    public float hp = 5000;
    public bool destroyed;

    private GameObject flames;

	// Use this for initialization
	void Start () {
        destroyed = false;
        flames = transform.Find("Flames").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damage(float damage) {
        hp -= damage;
        if (hp<=0)
        {
            destroyed = true;
            gameObject.tag = "DestroyedHouse";
            if (flames)
            {
                flames.SetActive(true);
                flames.transform.localPosition=new Vector3(0,0,0);
            }
            
        }
    }
}
