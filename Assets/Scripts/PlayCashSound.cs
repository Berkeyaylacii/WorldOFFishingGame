using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCashSound : MonoBehaviour
{
    public GameObject cash;
    public AudioSource cashSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, cash.transform.position);
        /*if(distance < 0.5f)
        {
            cashSound.Play();
        }*/
    }
}
