using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CollisionManager : MonoBehaviour
{
    [SerializeField] private UnityEvent my_Trigger;
    public GameObject my_player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            my_Trigger.Invoke();
        }
    }


}
