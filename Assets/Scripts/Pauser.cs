using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pause_menu;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pause_menu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pause_menu.SetActive(false);
            }
        }
    }

    public void EndGame()
    {
        //Instead of immediately destroying, pause game, set bool gameOver, make it jump sky high and when it lands it shattered and destroyed
        //And then presents gameOver screen, with an option to replay
        //Also add high score
        Destroy(player);
        Time.timeScale = 0;
    }
}
