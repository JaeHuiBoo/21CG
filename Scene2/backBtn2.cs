using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backBtn2 : MonoBehaviour
{
    public Button backToOriginBtn;

    [SerializeField]
    private GameObject gameManager;

    [SerializeField]
    private GameObject mainCamera;

    public static Vector3 originCameraPos;
    public static Quaternion originCameraRotation;


    public void backBtnClick()
    {
        if (gameManager.transform.GetComponent<click>().lookAtContainer)
        {
            mainCamera.transform.position = originCameraPos;
            mainCamera.transform.rotation = originCameraRotation;
            mainCamera.transform.GetComponent<move>().enabled = true;
            gameManager.transform.GetComponent<click>().containerUserAns = "";
            backToOriginBtn.gameObject.SetActive(false);
            gameManager.transform.GetComponent<click>().lookAtContainer = false;
        }
        
    }
}
