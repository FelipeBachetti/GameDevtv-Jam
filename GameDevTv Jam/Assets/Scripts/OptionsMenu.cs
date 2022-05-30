using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public void Back()
    {
        FindObjectOfType<AudioManager>().Play("clickButton");
    }
}
