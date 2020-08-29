using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonAI : MonoBehaviour {
    public float attackDamage = 1;
    public float attackRange = 10;
    public Animator anim;
    public NavMeshAgent agent;
    public float attackPlayerRange=100;
    public  float health =1000;

    private GameObject closest;
    private GameObject target;
    public GameObject attackEffect;
    private GameObject player;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (!anim.GetBool("isDead"))
        {
            if (Vector3.Distance(transform.position, player.transform.position) < attackPlayerRange)
            {

                PlayerAttack();
            }
            else
            {

                HouseTarget();
            }
        }
        else {
            agent.isStopped = true;
            if (attackEffect != null)
            {
                attackEffect.SetActive(false);
            }
        }
        
        

	}
    private void PlayerAttack() {
        
        agent.SetDestination(player.transform.position);
        if (agent.remainingDistance > attackRange)
        {
            agent.isStopped = false;
            anim.SetBool("isWalking", true);
            anim.SetBool("Attack2", false);
            if (attackEffect != null && !anim.GetBool("Attack2"))
            {
                attackEffect.SetActive(false);
            }
        }
        else
        {
            agent.isStopped = true;
            transform.LookAt(player.transform.position);
            anim.SetBool("Attack2", true);
            anim.SetBool("isWalking", false);
            if (attackEffect != null && anim.GetBool("Attack2"))
            {
                attackEffect.SetActive(true);
                player.GetComponent<PlayerScript>().Damage(attackDamage);
            }
        }
    }
    private void HouseTarget() {
        closest = FindClosestHouse();
        agent.SetDestination(closest.transform.position);
        if (agent.remainingDistance != 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("Attack2", false);
            if (attackEffect != null && !anim.GetBool("Attack2"))
            {
                attackEffect.SetActive(false);
            }
        }

        if (agent.remainingDistance == 0)
        {
            transform.LookAt(closest.transform.position);
            anim.SetBool("Attack2", true);
            anim.SetBool("isWalking", false);
            if (attackEffect != null && anim.GetBool("Attack2"))
            {
                attackEffect.SetActive(true);
                closest.GetComponent<HouseScript>().Damage(attackDamage);
            }
        }
    }
    private GameObject FindClosestHouse()
    {
        GameObject[] houses;
        houses = GameObject.FindGameObjectsWithTag("Hause");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject house in houses)
        {
            Vector3 diff = house.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance )
            {
                closest = house;
                distance = curDistance;
            }
        }
        return closest;
    }
    public void Damage(float damage) {
        health -= damage;
        if (health <= 0)
        {
            anim.SetBool("isDead", true);
        }
    }
}
