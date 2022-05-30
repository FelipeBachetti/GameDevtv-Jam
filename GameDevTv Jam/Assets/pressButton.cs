using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressButton : MonoBehaviour
{
    [SerializeField] private button but;

    private void OnTriggerEnter2D(Collider2D other) {
        but.Press();
    }
}
