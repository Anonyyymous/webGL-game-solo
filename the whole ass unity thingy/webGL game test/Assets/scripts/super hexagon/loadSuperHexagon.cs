using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSuperHexagon : MonoBehaviour
{
    public void LoadHexagon(){
        SceneManager.LoadScene("superHexagon");
    }
    public void ExitHexagon(){
        SceneManager.LoadScene("mainMenu");
    }
    public void ExitGame(){
        Application.Quit();
    }
}
