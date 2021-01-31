using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rd2d;

     public float speed;

     public int winCondition = 0;
     public Text win;

     public AudioClip jumpSound;
     public AudioClip collectSound;

     public AudioClip winSound;

     public AudioSource musicSource;

     public bool flipX;
     private SpriteRenderer flippy;

     float timer = 12f;
     public Text timerText;
    
    // Start is called before the first frame update
    void Start()
    {
         rd2d = GetComponent<Rigidbody2D>();
         flippy = GetComponent<SpriteRenderer>();
         win.text = "";
         timerText.text = "";
    }

    // Update is called once per frame
  void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));

      if (Input.GetKeyDown(KeyCode.D))
            {
                flippy.flipX = false;
            }

      if (Input.GetKeyDown(KeyCode.A))
        {
            if (flippy != null)
            {
                 flippy.flipX = true;
            }
        }

         timer -= Time.deltaTime;

            if (timer <= 10)
                 {
                    timerText.text = "Timer: " + Mathf.Round(timer); 
                 }
            if (timer <= 0)
                {
            
                 gameObject.SetActive(false);
                 timerText.text = "Game Over!"; 
                 }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Berry")
        {
            winCondition += 1;
            musicSource.clip = collectSound;
            musicSource.Play();
            Destroy(collision.collider.gameObject);

             if (winCondition >= 1)
                {
                     win.text = "You win!";
                     musicSource.clip = winSound;
                     musicSource.Play();
                     gameObject.SetActive(false);
                }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {


            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
                musicSource.clip = jumpSound;
                 musicSource.Play();
            }
            
        }
        
         if (collision.collider.tag == "Walls")
        {


            if (Input.GetKeyDown(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
                musicSource.clip = jumpSound;
                 musicSource.Play();
            }
        }
    }
}