using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backBtn3 : MonoBehaviour
{
    public Button backToOriginBtn;

    [SerializeField]
    private GameObject arrowLock;

    [SerializeField]
    private GameObject numberLock;

    [SerializeField]
    private GameObject radio;

    [SerializeField]
    GameObject InputField;

    [SerializeField]
    GameObject enterBtn;

    [SerializeField]
    private GameObject notebook;

    [SerializeField]
    private GameObject gameManager;

    [SerializeField]
    private GameObject mainCamera;

    public static Vector3 originCameraPos;
    public static Quaternion originCameraRotation;

    // Start is called before the first frame update
    public void backBtnClick()
    {
        if (arrowLock.transform.GetComponent<arrowLock>().lookAtArrowLock)
        {
            mainCamera.transform.position = originCameraPos;
            mainCamera.transform.rotation = originCameraRotation;
            mainCamera.transform.GetComponent<move>().enabled = true;
            arrowLock.transform.GetComponent<arrowLock>().userAns = "";
            backToOriginBtn.gameObject.SetActive(false);
            arrowLock.GetComponent<arrowLock>().lookAtArrowLock = false;
            Debug.Log("in arrow");
        }

        else if (numberLock.transform.GetComponent<numberLock>().lookAtNumLock)
        {
            mainCamera.transform.position = originCameraPos;
            mainCamera.transform.rotation = originCameraRotation;
            mainCamera.transform.GetComponent<move>().enabled = true;
            backToOriginBtn.gameObject.SetActive(false);
            numberLock.transform.GetComponent<numberLock>().lookAtNumLock = false;
            Debug.Log("in num");
        }

        else if (radio.transform.GetComponent<radioManager>().lookAtRadio)
        {
            radio.transform.GetComponent<AudioSource>().Stop();
            mainCamera.transform.position = originCameraPos;
            mainCamera.transform.rotation = originCameraRotation;
            mainCamera.transform.GetComponent<move>().enabled = true;
            radio.transform.GetComponent<radioManager>().userAns = "";
            InputField.SetActive(false);
            backToOriginBtn.gameObject.SetActive(false);
            radio.transform.GetComponent<radioManager>().lookAtRadio = false;
            enterBtn.SetActive(false);
            radio.transform.GetComponent<AudioSource>().Stop();
        }

        else if (notebook.transform.GetComponent<noteBook>().lookAtNotebook)
        {
            mainCamera.transform.position = originCameraPos;
            mainCamera.transform.rotation = originCameraRotation;
            mainCamera.transform.GetComponent<move>().enabled = true;
            backToOriginBtn.gameObject.SetActive(false);
            notebook.transform.GetComponent<noteBook>().lookAtNotebook = false;
            notebook.transform.GetComponent<AudioSource>().Stop();
        }

        else if (gameManager.transform.GetComponent<clickScene3>().lookAtPushLock)
        {
            mainCamera.transform.position = originCameraPos;
            mainCamera.transform.rotation = originCameraRotation;
            mainCamera.transform.GetComponent<move>().enabled = true;
            backToOriginBtn.gameObject.SetActive(false);
            gameManager.transform.GetComponent<clickScene3>().lookAtPushLock = false;
        }
    }

}
