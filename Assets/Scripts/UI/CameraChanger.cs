using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChanger : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private GameObject camera1;
    private GameObject camera2;
    private GameObject MainMenu;
    private GameObject Credits;

    private void Start()
    {
        // Find objects by name in the hierarchy
        camera1 = GameObject.Find("Camera Location 1");
        camera2 = GameObject.Find("Camera Location 2");
        MainMenu = GameObject.Find("Main Menu");
        Credits = GameObject.Find("Credits");
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Change camera
            ChangeCameraTarget(camera2);

            //switch canvas from Main Menu to Credits
            MainMenu.SetActive(false);
            Credits.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ChangeCameraTarget(camera1);
            Credits.SetActive(false);
            MainMenu.SetActive(true);
        }
    }
    public void ChangeCameraTarget(GameObject newTarget)
    {
        virtualCamera.Follow = newTarget.transform;
    }
}
