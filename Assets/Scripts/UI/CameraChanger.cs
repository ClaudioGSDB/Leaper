using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChanger : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject MainMenu;
    public GameObject Credits;
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
