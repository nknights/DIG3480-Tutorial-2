using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rd2d;

    public float speed;

    public Text score;

    private int scoreValue = 0;

    public Text WinText;

    public Text LivesText;

    private int Lives;

    public AudioSource musicSource;

    public AudioClip musicClipOne;

    public AudioClip musicClipTwo;

    Animator anim;

    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();

        score.text = scoreValue.ToString();

        WinText.text = "";

        Lives = 3;

        anim = GetComponent<Animator>();

        
}

   
    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");

        float verMovement = Input.GetAxis("Vertical");

        rd2d.AddForce(new Vector2(hozMovement, verMovement));

        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));

        if (facingRight == false && hozMovement > 0)
        {
            Flip();
        }
        else if (facingRight == true && hozMovement < 0)
        {
            Flip();
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

      
        if (scoreValue >= 8)
        {
            WinText.text = "You Win! Game created by Nicolas Lotruglio";
            musicSource.clip = musicClipTwo;
            musicSource.Play();
        }


        LivesText.text = "Lives: " + Lives.ToString();
        if (Lives <= 0)
        {
            WinText.text = "Game Over";
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetInteger("State", 3);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetInteger("State", 1);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetInteger("State", 1);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("State", 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Coin")
        {
            scoreValue += 1;

            score.text = scoreValue.ToString();

            Destroy(collision.collider.gameObject);

            playermovement();
        }

     

        if (collision.collider.tag == "Enemy")
        {
            Lives -= 1;

            score.text = scoreValue.ToString();

            Destroy(collision.collider.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);

                
              
            }

          


        }


    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }


    void playermovement()
    {
        if (scoreValue == 4)
        {
            transform.position = new Vector2(25f, 40f);

            Lives = 3;
        }
    }
      
}
