using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShotgunScript : MonoBehaviour {
    public Vector2 ammo = new Vector2(7, 21);

    public float damage = 10;
    public float range = 100;
    public float fireRate = 2f;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject impactEffectEnemy;
    public Camera fpsCamera;
    public Text ammoText;
    public float bulletsLeftInMag;

    private GameObject enemy;
    private float nextTimeToFire = 0;
    private float bulletsLeftTotal;

    // Use this for initialization
    void Start() {
        bulletsLeftInMag = ammo.x;
        bulletsLeftTotal = ammo.y;
        AmmoText();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButton("Fire1") && nextTimeToFire <= Time.time && bulletsLeftInMag>0)
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
            AmmoText();
        }
    }

    private void Shoot() {
        muzzleFlash.Play();
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hitInfo, range))
        {
            GameObject impactGO;
            if (hitInfo.transform.tag == "Enemy")
            {
                impactGO = Instantiate(impactEffectEnemy, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                enemy = hitInfo.transform.gameObject;
                if (enemy.GetComponentInParent<DragonAI>())
                {
                    enemy.GetComponentInParent<DragonAI>().Damage(damage);
                }
            }
            else
            {
                impactGO = Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));//efekt vurhu celta
            }
            Destroy(impactGO, 1f);

            AmmoCount();
        }

    }
    private void AmmoCount() {
        if (bulletsLeftInMag!=0)
        {
            bulletsLeftInMag--;
            if (bulletsLeftInMag == 0 && bulletsLeftTotal > 0)
            {
                bulletsLeftTotal -= ammo.x;
                bulletsLeftInMag += ammo.x;
            }
            AmmoText();
        }
        
    }
    private void AmmoText(){
        ammoText.text = bulletsLeftInMag + " / " + bulletsLeftTotal;
    }
}
