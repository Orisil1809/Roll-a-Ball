using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pause_menu;
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
}
