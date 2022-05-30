using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Audio;

public class abandonBody : MonoBehaviour
{
    public GameObject ghost, cam;
    public Vector3 originalPos;
    [HideInInspector] public CinemachineVirtualCamera vcam;
    public GameObject SFX;
    public bool canAbandon;
    
    private void OnEnable() {
        vcam = cam.GetComponent<CinemachineVirtualCamera>();
        vcam.Follow = gameObject.transform;
        vcam.LookAt = gameObject.transform;
    }
    void Update()
    {
        if(Input.GetButtonDown("Possess") && canAbandon){
            ghost.transform.position = transform.position;
            ghost.SetActive(true);
            vcam.Follow = ghost.transform;
            vcam.LookAt = ghost.transform;
            transform.position = originalPos;
            FindObjectOfType<AudioManager>().Play("Ghost");
            if (SFX != null)
                SFX.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
