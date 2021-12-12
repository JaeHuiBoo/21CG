using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class radioManager: MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    GameObject radio;

    [SerializeField]
    GameObject InputField;

    [SerializeField]
    GameObject backToOriginBtn;

    [SerializeField]
    GameObject radioHintText;

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
        radioHintText.SetActive(false);
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
                
                if (target== radio)
                {
                    lookAtRadio = true;
                    backBtn3.originCameraPos = mainCamera.transform.position;
                    backBtn3.originCameraRotation = mainCamera.transform.rotation;

                    mainCamera.transform.position = new Vector3(-41.1f, 13.5f, -39.3f);
                    mainCamera.transform.rotation = Quaternion.Euler(new Vector3(43.495f, 270f, 0));

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
            radioHintText.SetActive(true);
            InputField.SetActive(false);
            radio.transform.GetComponent<AudioSource>().Stop();
        }
    }
    

}
