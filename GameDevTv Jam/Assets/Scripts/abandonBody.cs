using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class abandonBody : MonoBehaviour
{
    public GameObject ghost, cam;
    public Vector3 originalPos;
    [HideInInspector] public CinemachineVirtualCamera vcam;
    [HideInInspector] public GameObject SFX;
    
    private void OnEnable() {
        vcam = cam.GetComponent<CinemachineVirtualCamera>();
        vcam.Follow = gameObject.transform;
        vcam.LookAt = gameObject.transform;
    }
    void Update()
    {
        if(Input.GetButtonDown("Possess")){
            ghost.transform.position = transform.position;
            ghost.SetActive(true);
            vcam.Follow = ghost.transform;
            vcam.LookAt = ghost.transform;
            transform.position = originalPos;
            SFX.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
