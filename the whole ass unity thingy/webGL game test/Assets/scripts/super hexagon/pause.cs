using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = true;
        pauseMenu.SetActive(false);
    }

    public void paused(){
        if(isPaused){
            Time.timeScale = 0;
            isPaused = false;
            pauseMenu.SetActive(true);
        } else{
            Time.timeScale = 1;
            isPaused = true;
            pauseMenu.SetActive(false);
        }
    }
}
