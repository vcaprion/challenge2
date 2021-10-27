using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GirlController : MonoBehaviour
{
    public static ScoreManager instance;
    public float speed = 5;
    public float jumpSpeed = 7;
    public float direction = 0f;
    Animator anim;
    private Rigidbody2D player;
    public Text livesText;
    public Text winText;
    public Text loseText;
    private int lives;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        lives = 3;
        SetLivesText();
        winText.text = "";
        loseText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if(direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(0.2712f, 0.2712f);
        }
        else if (direction < 0f)
        {
          player.velocity = new Vector2(direction * speed, player.velocity.y);
          transform.localScale = new Vector2(-0.2712f, 0.2712f);

        }
        else
        {
          player.velocity = new Vector2(0* speed, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump"))
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetInteger("State", 2);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("State", 1);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetInteger("State", 2);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("State", 1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("State", 3);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetInteger("State", 1);
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    
    }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Portal"))
            {
                transform.position = new Vector3(-7.14f, -15.37f, 0f);
            }
            if(other.gameObject.CompareTag("Berry"))
            {
                Destroy(other.gameObject);
            }
            else if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                lives = lives -1;
                SetLivesText();
            }
            
        }
        void SetWinText()
        {
        if (score >=8)
        {
            winText.text = "You Win! Game created by vcaprion";
        }
            
        }
        void SetLivesText()
        {
            livesText.text = "Lives: " + lives.ToString();
            if (lives == 0)
            {
                loseText.text = "You died";
                Destroy(this);
            }
        }
}