using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour {
    public float walkingSpeed = 5;
    public float chaseRange = 50;
    public float attackRange = 1;
    public float attackDamage = 10;
    public Vector2 distenceBeforeIdleRange = new Vector2(2,5);
    public Vector2 idleTimeRange = new Vector2(2,5);
    public Animator anim;
    public float health=100;

    private GameObject player;
    private float timeBeforeRotationNext=0;
    private Vector3 startingPosition;
    private float distenceBeforeIdle;
    private float idleTime = 5;

    // Use this for initialization
    void Start () {
        startingPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        float randomRotation = Random.Range(0,360);
        transform.Rotate(0,randomRotation,0);
        distenceBeforeIdle = Random.Range(distenceBeforeIdleRange.x,distenceBeforeIdleRange.y);
        idleTime = Random.Range(idleTimeRange.x,idleTimeRange.y);
    }
	
	// Update is called once per frame
	void Update () {
        if (chaseRange<Vector3.Distance(transform.position,player.transform.position))
        {
            if (anim.GetBool("isWalking"))
            {
                StartCoroutine(Wandering());// ako ne e v if WaitForSeconds ne raboti
            }
        }
        else
        {
                Chase();
        }
        
        
	}

    IEnumerator Wandering() {
        if (distenceBeforeIdle>=Vector3.Distance(transform.position,startingPosition)) //ako e po-dalech ot kudeto moje da stigne wandering se vruchta v nachalna poziciq
        {
            transform.Translate(Vector3.forward * walkingSpeed * Time.deltaTime);
            if (Time.time >= timeBeforeRotationNext)//vreme mejdu spiraniqta
            {
                anim.SetBool("isWalking", false);
                transform.Rotate(0, 144, 0);
                yield return new WaitForSeconds(idleTime);//vreme prez koeto e sprqlo
                anim.SetBool("isWalking", true);
                timeBeforeRotationNext = Time.time + distenceBeforeIdle;
            }          
        }
        else
        {
            transform.LookAt(startingPosition);
            transform.Translate(Vector3.forward * walkingSpeed * Time.deltaTime);
        }
        
       
    }

    private void Chase() {
        

        if (attackRange < Vector3.Distance(transform.position, player.transform.position) && anim.GetBool("isDead")==false)
        {
            transform.LookAt(player.transform);
            anim.SetBool("Attack", false);
            anim.SetBool("isWalking", true);
            transform.Translate(Vector3.forward * walkingSpeed * Time.deltaTime);

        }
        else
        {
            anim.SetBool("Attack", true);
            anim.SetBool("isWalking", false);
            player.GetComponent<PlayerScript>().Damage(attackDamage);
        }
    }
    public void Damage(float damage) {
        health -= damage;
        if (health<=0)
        {
            anim.SetBool("isWalking",false);
            anim.SetBool("isDead",true);
            GetComponent<BoxCollider>().size =new Vector3(GetComponent<BoxCollider>().size.x, 0.1f, GetComponent<BoxCollider>().size.z);
            GetComponent<BoxCollider>().center =new Vector3(GetComponent<BoxCollider>().center.x, 0.1f, GetComponent<BoxCollider>().center.z);
        }
        
    }
}
