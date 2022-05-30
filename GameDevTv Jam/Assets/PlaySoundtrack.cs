using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundtrack : MonoBehaviour
{
    void Start()
    {
            FindObjectOfType<AudioManager>().Play("Soundtrack");

    }
}
