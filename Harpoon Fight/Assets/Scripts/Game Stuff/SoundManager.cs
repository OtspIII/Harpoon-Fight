using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{

    public AudioSource Music;
    public AudioSource P1;
    public AudioSource P2;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(HF.PlayerSlot who, AudioClip sound)
    {
        AudioSource s = P1;
        if (who == HF.PlayerSlot.PlayerTwo)
            s = P2;
        s.PlayOneShot(sound);
    }
}
