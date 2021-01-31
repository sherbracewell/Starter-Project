using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedStartTwo : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        AudioSource backgroundMusic = gameObject.GetComponent<AudioSource>();
        backgroundMusic.PlayDelayed(2);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
