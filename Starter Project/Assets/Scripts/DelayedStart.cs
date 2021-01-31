using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedStart : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        AudioSource loseMusic = gameObject.GetComponent<AudioSource>();
        loseMusic.PlayDelayed(13);
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey("escape"))
        {
            Application.Quit();
        } 
        
    }
}
