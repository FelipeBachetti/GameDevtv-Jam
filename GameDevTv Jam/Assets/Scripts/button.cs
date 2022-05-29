using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject sprite01, sprite02;

        public void Press(){
        sprite01.SetActive(false);
        sprite02.SetActive(true);
        anim.SetBool("open", true);
    }
}
