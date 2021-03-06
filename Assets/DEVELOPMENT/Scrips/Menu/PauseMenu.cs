using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Transform cameraT;

    public GameObject exitMessage;
    public void resumeBtn()
    {
        Vector3 camPos = cameraT.position;
        camPos.x += 3.5f;
        cameraT.position = camPos;
        Time.timeScale = 1;
        FindObjectOfType<AimController>().gunActive.AudioSource.UnPause();
    }
    public void pauseBtn()
    {
        Vector3 camPos = cameraT.position;
        camPos.x -= 3.5f;
        cameraT.position = camPos;
        Time.timeScale = 0;
        FindObjectOfType<AimController>().gunActive.AudioSource.Pause();
    }
    public void exit()
    {
        Instantiate(exitMessage);
    }
}
