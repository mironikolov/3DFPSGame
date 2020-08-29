using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    public float speed = 10;
    public float jumpHight = 10;
    public static float health = 100;
    public float fallMultiplier=1.5f;
    public Text healthText;
    public Camera mapCamera;

    private GameObject ui;
    float mouseSens =0;
    float playerRotation = 0;
    Rigidbody rb;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        if (GameObject.Find("ValueManager") != null)
        {
            mouseSens = GameObject.Find("ValueManager").GetComponent<ValueManagerScript>().mouseSens;
            ui = GameObject.FindGameObjectWithTag("UI");
        }

    }
	
	// Update is called once per frame
	void Update () {
        PlayerMovement();
        healthText.text = health.ToString();
        if (Input.GetKeyDown(KeyCode.M))
        {
            mapCamera.enabled = !mapCamera.enabled;
            if (ui)
            {
                ui.SetActive(!ui.activeSelf);
            }
        }
	}

    void PlayerMovement() {
        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 playerInputNormalizet = playerInput.normalized;
        rb.transform.Translate(playerInputNormalizet * speed * Time.deltaTime);


        playerRotation += -Input.GetAxisRaw("Mouse X") * mouseSens * Time.deltaTime;
        rb.transform.localRotation = Quaternion.AngleAxis(playerRotation, Vector3.down);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = Vector3.up * jumpHight;
        }
        if (rb.velocity.y<0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.deltaTime;
        }
    }
    public void Damage(float damage) {
        health -= damage;
        if (health<=0)
        {
            print("Player is dead");
        }
    }
    private bool IsGrounded()
    {
        float distToGround = GetComponent<Collider>().bounds.extents.y;
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);//ray kum zemqta s duljina 0.1
    }
}
