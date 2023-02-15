using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip jump;
    AudioSource source;
    public static AudioManager instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void playJumpSound()
    {
        source.PlayOneShot(jump);
    }
    
}
