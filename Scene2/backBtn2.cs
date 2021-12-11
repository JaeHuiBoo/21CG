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

    [SerializeField]
    private TextMesh containerNumText;

    [SerializeField]
    private TextMesh elecNumText;

    public static Vector3 originCameraPos;
    public static Quaternion originCameraRotation;


    public void backBtnClick()
    {
        if (gameManager.transform.GetComponent<click>().lookAtContainer)
        {
            mainCamera.transform.position = originCameraPos;
            mainCamera.transform.rotation = originCameraRotation;
            mainCamera.transform.GetComponent<move>().enabled = true;
            containerNumText.text = "";
            backToOriginBtn.gameObject.SetActive(false);
            gameManager.transform.GetComponent<click>().lookAtContainer = false;
        }

        else if (gameManager.transform.GetComponent<click>().lookAtBreaker)
        {
            mainCamera.transform.position = originCameraPos;
            mainCamera.transform.rotation = originCameraRotation;
            mainCamera.transform.GetComponent<move>().enabled = true;
            elecNumText.text = "";
            backToOriginBtn.gameObject.SetActive(false);
            gameManager.transform.GetComponent<click>().lookAtBreaker = false;
        }

    }
}
