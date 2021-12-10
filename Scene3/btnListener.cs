using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnListener : MonoBehaviour
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
    private GameObject mainCamera;

    private bool arrowflag=true;
    private bool numflag = true;
    private bool radioflag = true;
    private bool notebookflag = true;

    public static Vector3 originCameraPos;
    public static Quaternion originCameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(arrowLock.transform.GetComponent<arrowLock>().lookAtArrowLock)
        {
            if(arrowflag)
            {
                backToOriginBtn.onClick.AddListener(arrowBackToOriginBtnClick);
                arrowflag = false;
            }
        }

        else if (numberLock.transform.GetComponent<numberLock>().lookAtNumLock)
        {
            if (numflag)
            {
                backToOriginBtn.onClick.AddListener(numBackToOriginBtnClick);
                numflag = false;
            }
        }

        else if (radio.transform.GetComponent<radioManager>().lookAtRadio)
        {
            if (radioflag)
            {
                backToOriginBtn.onClick.AddListener(radioBackToOriginBtnClick);
                radioflag = false;
            }
        }

        else if (notebook.transform.GetComponent<radioManager>().lookAtRadio)
        {
            if (notebookflag)
            {
                backToOriginBtn.onClick.AddListener(radioBackToOriginBtnClick);
                notebookflag = false;
            }
        }
    }

    public void arrowBackToOriginBtnClick()
    {
        mainCamera.transform.position = originCameraPos;
        mainCamera.transform.rotation = originCameraRotation;
        mainCamera.transform.GetComponent<move>().enabled = true;
        arrowLock.transform.GetComponent<arrowLock>().userAns = "";
        backToOriginBtn.gameObject.SetActive(false);
        arrowLock.transform.GetComponent<arrowLock>().lookAtArrowLock = false;
    }

    public void numBackToOriginBtnClick()
    {
        mainCamera.transform.position = originCameraPos;
        mainCamera.transform.rotation = originCameraRotation;
        mainCamera.transform.GetComponent<move>().enabled = true;
        backToOriginBtn.gameObject.SetActive(false);
        numberLock.transform.GetComponent<numberLock>().lookAtNumLock = false;
    }

    public void radioBackToOriginBtnClick()
    {
        radio.transform.GetComponent<AudioSource>().Stop();
        mainCamera.transform.position = originCameraPos;
        mainCamera.transform.rotation = originCameraRotation;
        mainCamera.transform.GetComponent<move>().enabled = true;
        radio.transform.GetComponent<radioManager>().userAns = "";
        InputField.SetActive(false);
        backToOriginBtn.gameObject.SetActive(false);
        enterBtn.SetActive(false);
    }

    public void notebookBackToOriginBtnClick()
    {
        mainCamera.transform.position = originCameraPos;
        mainCamera.transform.rotation = originCameraRotation;
        mainCamera.transform.GetComponent<move>().enabled = true;
        backToOriginBtn.gameObject.SetActive(false);
        notebook.transform.GetComponent<noteBook>().lookAtNotebook = false;
    }
}
