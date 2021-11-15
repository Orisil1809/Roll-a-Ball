using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pauser : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pause_menu;
    public GameObject end_menu;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.IsInputEnabled && Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pause_menu.SetActive(true);
            }
            //else
            //{
            //    Time.timeScale = 1;
            //    pause_menu.SetActive(false);
            //}
        }
    }

    public void QuitGame()
    {
        Invoke("SetQuitScreen", 3f);
    }

    void SetQuitScreen()
    {
        end_menu.SetActive(true);

    }
    public void Resume()
    {
        pause_menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void EndGame()
    {
        //Debug.Log("PRESSED");

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}
