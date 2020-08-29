using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour {

	public void Play()
    {
        SceneManager.LoadScene("Village");
        Time.timeScale = 1f;
      
    }
    public void Quit()
    {

        Application.Quit();
    }

}
