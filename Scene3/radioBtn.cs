using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class radioBtn : MonoBehaviour
{
    [SerializeField]
    GameObject morseCode;

    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    GameObject radio;

    [SerializeField]
    GameObject InputField;

    //[SerializeField]
    //GameObject backBtn;

    [SerializeField]
    GameObject enterBtn;

    [SerializeField]
    GameObject notebook;

    [SerializeField]
    GameObject notebookBtn;

    [SerializeField]
    GameObject clue_0;

    private GameObject target;
    private Vector3 originCameraPosition;
    private Vector3 originCameraRotation;

    public string ans;

    // Start is called before the first frame update
    void Start()
    {
        InputField.SetActive(false);
        enterBtn.SetActive(false);
        clue_0.SetActive(false);
        //backBtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            target = getTarget3D();
        }

        if(target!=null)
        {
            
            if (Input.GetMouseButtonUp(0))
            {

                if(target.name=="drawer_1")
                {
                    Debug.Log(target.GetComponent<Animation>());
                    target.GetComponent<Animation>().Play();
                }
                

                else if (target.name=="morseCode")
                {
                    originCameraPosition = mainCamera.transform.position;
                    originCameraRotation.x = mainCamera.transform.rotation.eulerAngles.x;
                    originCameraRotation.y = mainCamera.transform.rotation.eulerAngles.y;
                    originCameraRotation.z = mainCamera.transform.rotation.eulerAngles.z;

                    mainCamera.transform.position = new Vector3(-41.77f, 21.33f, 3.74f);
                    mainCamera.transform.rotation = Quaternion.Euler(new Vector3(63.685f, -90f, 0));

                    radio.transform.GetComponent<AudioSource>().Play();
                    InputField.SetActive(true);
                    enterBtn.SetActive(true);
                    //backBtn.SetActive(true);
                    
                }
            }
        }
    }

    private GameObject getTarget3D()
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }

    public void backBtnClick()
    {
        radio.transform.GetComponent<AudioSource>().Stop();
        mainCamera.transform.position = originCameraPosition;
        mainCamera.transform.rotation = Quaternion.Euler(originCameraRotation);
        InputField.SetActive(false);
        //backBtn.SetActive(false);
        enterBtn.SetActive(false);
    }

    public void enterBtnClick()
    {
        string text = InputField.transform.GetChild(2).GetComponent<Text>().text;
        
        if (text==ans)
        {
            Debug.Log("success");
        }
    }

    public void notebookBtnClick()
    {
        AudioSource audio = notebook.GetComponent<AudioSource>();
        audio.Play();
        notebookBtn.SetActive(false);
        this.gameObject.SetActive(false);
        clue_0.SetActive(true);
        mainCamera.transform.position = new Vector3(32.01f, 10.52f, -21.6f);
        mainCamera.transform.rotation = Quaternion.Euler(new Vector3(0, 90f, 0));
    }

}
