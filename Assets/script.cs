using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class script : MonoBehaviour {

    public static string scene;
    public static bool Pause = false;
    public GameObject pauseMenu;
    public GameObject Title;
    public GameObject cross;
    public GameObject ammo;
    public GameObject text;
    public GameObject pressanykey;
    public GameObject FirstCam;
    public GameObject SecondCam;
    public GameObject Gmeover;
    public GameObject Dedccn;
    public GameObject Map;
    public GameObject SuccessScreen;
    public GameObject Drake;
    public GameObject Drake1;
    public GameObject Drake2;
    public GameObject Drake3;
    public GameObject Drake4;

    private GameObject[] dragons;
    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(Openning());
        dragons = GameObject.FindGameObjectsWithTag("Enemy");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Pause == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        StrtGame();
        gmeover();
        LoadSuccessScene();
    }

    IEnumerator Openning()
    {
        FirstCam.SetActive(true);
        SecondCam.SetActive(false);
        text.SetActive(false);
        cross.SetActive(false);
        ammo.SetActive(false);
        Title.SetActive(true);
        yield return new WaitForSeconds(2);
        pressanykey.SetActive(true);
        yield return new WaitForSeconds(18);

        //{
        pressanykey.SetActive(false);
        Title.SetActive(false);

        Map.SetActive(true);
        cross.SetActive(true);
        text.SetActive(true);
        ammo.SetActive(true);
        FirstCam.SetActive(false);
        SecondCam.SetActive(true);
        //}
    }
    void StrtGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressanykey.SetActive(false);
            Title.SetActive(false);
            Map.SetActive(true);
            cross.SetActive(true);
            text.SetActive(true);
            ammo.SetActive(true);
            FirstCam.SetActive(false);
            SecondCam.SetActive(true);

        }

    }
    void gmeover()
    {
        if (PlayerScript.health==0)
        {
            SecondCam.SetActive(false);
            Dedccn.SetActive(true);
            Gmeover.SetActive(true);
            text.SetActive(false);
            cross.SetActive(false);
            ammo.SetActive(false);
            Map.SetActive(false);
            PlayerScript.health = 100;
           
        }
        if (Input.GetKeyDown(KeyCode.F))
        {

            LoadMenu();
        }

       
    }
    void LoadSuccessScene()
    {
        bool aliveDragons = false;
        foreach (var dragon in dragons)
        {
            if (dragon.GetComponent<DragonAI>()!=null)
            {
                if (!dragon.GetComponent<DragonAI>().anim.GetBool("isDead"))
                {
                    aliveDragons = true;
                }
            }
            
        }
        if (!aliveDragons)
        {
            SecondCam.SetActive(false);
            SuccessScreen.SetActive(true);
            Dedccn.SetActive(true);
            text.SetActive(false);
            cross.SetActive(false);
            ammo.SetActive(false);
            Map.SetActive(false);
        }

    }
    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Pause = true;

    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Pause = false;
    }
    public void LoadMenu()
    {

        scene = "Menu2";
        SceneManager.LoadScene(scene);

    }
    public void quit()
    {
        Application.Quit();
    }
}
