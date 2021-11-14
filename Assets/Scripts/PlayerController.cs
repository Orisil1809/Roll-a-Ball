using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events; 
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
    //public GameObject ground;
    private int score;
    public Text scoreText;
    public Text highScoreText;
    public Text FinalScoreText;
    public GameObject winText;
    private int highscore;
    [SerializeField] private UnityEvent my_Trigger;
    public bool blink = false;
    private float timer;
    private float WaitTime = 0.2f;
    private Renderer my_renderer;
    //private Collider ground_collider;
    // Start is called before the first frame update
    void Start()
    {
        blink = false;
        score = 0;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        //SetCountText();
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        highScoreText.text = "Highscore: " + highscore;
        my_renderer = this.gameObject.GetComponent<Renderer>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && Time.timeScale == 1 && GameManager.IsInputEnabled)
        {

            rb.AddForce(jump * jump_power, ForceMode.Impulse);
            //isGrounded = false;
        }
        #region try_blink
        //if (blink)
        //{
        //    timer += Time.deltaTime;

        //    if (timer < WaitTime)
        //    {
        //        my_renderer.material.color = Color.white;
        //    }

        //    if (timer > WaitTime)
        //    {
        //        my_renderer.material.color = Color.red;
        //    }

        //}
        #endregion
    }

    //void OnCollisionStay()
    //{
    //    isGrounded = true;
    //}
    void FixedUpdate()
    {
        if (Time.timeScale == 1 && GameManager.IsInputEnabled)
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
        if (other.gameObject.CompareTag("Obstacle"))
        {
            FinalScoreText.text = "SCORE: " + score;
            GameManager.IsInputEnabled = false;
            AnimateCollision();
            my_Trigger.Invoke();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        randLocation = new Vector3(Random.Range(-8.5f, 8.5f), 0.5f, Random.Range(-8.5f, 8.5f));
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.transform.position = randLocation;
            //other.gameObject.SetActive(false);
            score++;
            SetScoreText();
            if(score > highscore)
            {
                highscore = score;
                highScoreText.text = "Highscore: " + highscore;

                PlayerPrefs.SetInt("highscore", highscore);
            }
            
        }

    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Ground")
        {
            isGrounded = false;
        }
        
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if(score==10)
        {
            winText.SetActive(true);
        }
    }
    public void AnimateCollision()
    {
        rb.AddForce(jump * 5f, ForceMode.Impulse);
        //my_renderer.material.color = Color.red;

        //Invoke("Blink", 0.5f);
        Blink();
    }
    public void Blink()
    {
        //blink = true;
        InvokeRepeating("HelpBlink", 0.2f, 0.5f);
    }

    public void HelpBlink()
    {
        if(my_renderer.material.color == Color.red)
        {
            my_renderer.material.color = Color.white;
        }
        else
        {
            my_renderer.material.color = Color.red;
        }
    }
}
