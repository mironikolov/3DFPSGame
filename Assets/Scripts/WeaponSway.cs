using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour {
    public float swayAmount;
    public float swaySmoothness;

    private Vector3 startingPosition;

    // Use this for initialization
    void Start () {
        startingPosition = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        Sway();
    }

    private void Sway()
    {
        float mouseX = -Input.GetAxisRaw("Mouse X") * swayAmount;
        float mouseY = -Input.GetAxisRaw("Mouse Y") * swayAmount;
        mouseX = Mathf.Clamp(mouseX, -swayAmount, swayAmount);
        mouseY = Mathf.Clamp(mouseY, -swayAmount, swayAmount);

        Vector3 offset = new Vector3(mouseX, mouseY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, startingPosition + offset, swaySmoothness * Time.deltaTime);

    }
}
