using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jump_power = 2.0f;
    private Vector3 jump;
    private bool isGrounded;
    public Vector3 randLocation;
    public GameObject ground;
    private int count;
    public Text countText;
    public Text winText;
    //private Collider ground_collider;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        SetCountText();
        winText.text = "";
        //mesh = GetComponent<MeshFilter>().mesh;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && Time.timeScale == 1)
        {

            rb.AddForce(jump * jump_power, ForceMode.Impulse);
            //isGrounded = false;
        }

    }

    //void OnCollisionStay()
    //{
    //    isGrounded = true;
    //}
    void FixedUpdate()
    {
        if (Time.timeScale == 1)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.5f, moveVertical); //Like the parent object which is set to y = 0.5
            rb.AddForce(movement * speed);
        }

        //if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        //{
        //    Debug.Log("Space clicked");
        //    rb.AddForce(jump * jump_power, ForceMode.Impulse);
        //    //isGrounded = false;
        //}
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        randLocation = new Vector3(Random.Range(-8.5f, 8.5f), 0.5f, Random.Range(-8.5f, 8.5f));
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.transform.position = randLocation;
            //other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Ground")
        {
            isGrounded = false;
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count==10)
        {
            winText.text = "You Win";
        }
    }

}
