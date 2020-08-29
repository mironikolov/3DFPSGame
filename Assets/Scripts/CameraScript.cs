using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    float mouseSens =0;
    float cameraRotation = 0;

    // Use this for initialization
    void Start () {
        if (GameObject.Find("ValueManager")!=null)
        {
            mouseSens = GameObject.Find("ValueManager").GetComponent<ValueManagerScript>().mouseSens;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        cameraRotation += -Input.GetAxisRaw("Mouse Y") * mouseSens * Time.deltaTime;
        cameraRotation = Mathf.Clamp(cameraRotation, -90, 90);
        transform.localRotation = Quaternion.AngleAxis(cameraRotation, Vector3.right);
    }
}
