using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsControl : MonoBehaviour
{
    [SerializeField] private AudioSource singSong,crySound;
    private bool sing, cry;

    public void PlayPauseSing()
    {
        sing = !sing;
        if (sing)
        {
            singSong.Play();
        }
        else
        {
            singSong.Pause();
        }
    }
    
    public void PlayPauseCry()
    {
        cry = !cry;
        if (cry)
        {
            crySound.Play();
        }
        else
        {
            crySound.Pause();
        }
    }
}
