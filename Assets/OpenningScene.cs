//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class PauseMenu : MonoBehaviour
//{
//    public static string scene;
//    public static bool Pause = false;
//    public GameObject pauseMenu;
//    public GameObject Title;
//    public GameObject cross;
//    public GameObject ammo;
//    public GameObject text;
//    public GameObject pressanykey;
//    public GameObject FirstCam;
//    public GameObject SecondCam;
//    public GameObject Gmeover;
//    public GameObject Dedccn;
//    // Update is called once per frame
//    private void Start()
//    {
//        StartCoroutine(Openning());
//    }
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.P))
//        {
//            if (Pause == true)
//            {
//                ResumeGame();
//            }
//            else
//            {
//                PauseGame();
//            }
//        }
//        StrtGame();
//        gmeover();
//    }
//    IEnumerator Openning()
//    {
//        FirstCam.SetActive(true);
//        SecondCam.SetActive(false);
//        text.SetActive(false);
//        cross.SetActive(false);
//        ammo.SetActive(false);
//        Title.SetActive(true);
//        yield return new WaitForSeconds(2);
//        pressanykey.SetActive(true);
//        yield return new WaitForSeconds(18);

//        //{
//        pressanykey.SetActive(false);
//        Title.SetActive(false);


//        cross.SetActive(true);
//        text.SetActive(true);
//        ammo.SetActive(true);
//        FirstCam.SetActive(false);
//        SecondCam.SetActive(true);
//        //}
//    }
//    void StrtGame()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            pressanykey.SetActive(false);
//            Title.SetActive(false);

//            cross.SetActive(true);
//            text.SetActive(true);
//            ammo.SetActive(true);
//            FirstCam.SetActive(false);
//            SecondCam.SetActive(true);

//        }

//    }
//    void gmeover()
//    {
//        if (Input.GetKeyDown(KeyCode.X))
//        {
//            SecondCam.SetActive(false);
//            Dedccn.SetActive(true);
//            Gmeover.SetActive(true);
//            text.SetActive(false);
//            cross.SetActive(false);
//            ammo.SetActive(false);


//        }

//        if (Input.GetKeyDown(KeyCode.F))
//        {

//            LoadMenu();
//        }
//    }
//    void PauseGame()
//    {
//        pauseMenu.SetActive(true);
//        Time.timeScale = 0f;
//        Pause = true;

//    }
//    public void ResumeGame()
//    {
//        pauseMenu.SetActive(false);
//        Time.timeScale = 1f;
//        Pause = false;
//    }
//    public void LoadMenu()
//    {

//        scene = "Menu2";
//        SceneManager.LoadScene(scene);

//    }
//    public void quit()
//    {
//        Application.Quit();
//    }
//}
