using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.transform.position + offset;
    }

    void LateUpdate() //Runs every frame but after update is run. So when we got here we know for sure that the player moved to its new position.
    {
        if(GameObject.Find("Player") !=null)
            transform.position = player.transform.position + offset;
    }
}
