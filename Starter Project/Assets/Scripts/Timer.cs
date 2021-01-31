using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timer = 13f;
    Text timerText;
    public AudioClip PickUp;

    // Start is called before the first frame update
    void Start()
    {
        timerText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

            if (timer <= 10)
                 {
                    timerText.text = "Timer: " + Mathf.Round(timer); 
                 }

    }
            void OnTriggerEnter2D(Collider2D other)
            {

            if (timer <= 0)
                {
                PlayerController controller = other.GetComponent<PlayerController>();

                 if (controller != null)
                    {
                        Destroy(gameObject);
                        timerText.text = "Game Over!"; 
                     }
                }
            }
}