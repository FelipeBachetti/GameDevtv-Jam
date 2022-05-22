using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abandonBody : MonoBehaviour
{
    [HideInInspector] public GameObject ghost;
    [HideInInspector] public Vector3 originalPos;

    void Update()
    {
        if(Input.GetButtonDown("Possess")){
            ghost.transform.position = transform.position;
            ghost.SetActive(true);
            transform.position = originalPos;
            gameObject.SetActive(false);
        }
    }
}
