using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSourceAtack;
    public AudioSource audioSourceStep;

    public void PlayAudioAtack()
    {
        audioSourceAtack.Play();
    }

    public void PlayAudioStep()
    {
        audioSourceStep.Play();
    }
}
