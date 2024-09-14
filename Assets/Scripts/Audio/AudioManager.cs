using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource source, loopSource;
    public AudioClip playerSFX, loopSfx;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        loopSource.clip = loopSfx;
        source.clip = playerSFX;
        LoopSFX();
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    public void PlayerSFX()
    {
        source.Play();

        
    }
    public void LoopSFX()
    {
       
        loopSource.Play();

        
    }

   




}
