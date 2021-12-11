using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class radioManager: MonoBehaviour
{
    [SerializeField]
    GameObject morseCode;

    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    GameObject radio;

    [SerializeField]
    GameObject InputField;

    [SerializeField]
    GameObject backToOriginBtn;

    [SerializeField]
    GameObject enterBtn;

    public string userAns;

    private GameObject target;

    public string ans;
    public bool lookAtRadio=false;

    // Start is called before the first frame update
    void Start()
    {
        InputField.SetActive(false);
        enterBtn.SetActive(false);
        backToOriginBtn.SetActive(false);
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
                    lookAtRadio = true;
                    backBtn3.originCameraPos = mainCamera.transform.position;
                    backBtn3.originCameraRotation = mainCamera.transform.rotation;

                    mainCamera.transform.position = new Vector3(-41.77f, 21.33f, 3.74f);
                    mainCamera.transform.rotation = Quaternion.Euler(new Vector3(63.685f, -90f, 0));

                    mainCamera.transform.GetComponent<move>().enabled = false;
                    radio.transform.GetComponent<AudioSource>().Play();
                    InputField.SetActive(true);
                    enterBtn.SetActive(true);
                    backToOriginBtn.SetActive(true);
                    
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

    public void enterBtnClick()
    {
        userAns = InputField.transform.GetChild(2).GetComponent<Text>().text;
        
        if (userAns == ans)
        {
            Debug.Log("success");
        }
    }
    

}
