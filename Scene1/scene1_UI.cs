using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene1_UI : MonoBehaviour
{
    [SerializeField]
    private GameObject breaker;

    [SerializeField]
    private GameObject mainCam;

    [SerializeField]
    private GameObject firstquizPanel;

    private GameObject clickedObj;

    //breaker 클릭 여부 
    public bool breakerClicked;
    private Vector3 previousCampos;
    // Start is called before the first frame update
    void Start()
    {
        breakerClicked = false;
        previousCampos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        clickedObj = ClickObject3D();
        if (clickedObj != null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                clickedObj = ClickObject3D();
                if (clickedObj.name == "breaker" && !breakerClicked)
                {
                    breakerClicked = true;
                    breaker.GetComponent<Outline>().enabled = false;
                    breaker.transform.localEulerAngles = new Vector3(0, 90, -62.72f);
                    previousCampos = mainCam.transform.position;
                    mainCam.GetComponent<move>().enabled = false;
                    mainCam.transform.position = new Vector3(11, 20.5f, -37.5f);
                    mainCam.transform.localEulerAngles = new Vector3(44.51f, 175.69f, -3.49f);
                }
            }
            else
            {
                if (!breakerClicked)
                {
                    if (clickedObj.name == "breaker")
                    {
                        breaker.GetComponent<Outline>().enabled = true;
                    }
                    else
                    {
                        breaker.GetComponent<Outline>().enabled = false;
                    }
                }
            }

            if (this.gameObject.GetComponent<clues>().firstclueClear)
            {
                StartCoroutine(remoteAnim());
            }
        }
    }

    IEnumerator remoteAnim()
    {
        breaker.GetComponent<Animator>().enabled = true;
        firstquizPanel.SetActive(false);
        yield return new WaitForSeconds(5.5f);
        mainCam.GetComponent<move>().enabled = true;
        mainCam.transform.position = previousCampos;
        mainCam.transform.localEulerAngles = new Vector3(0, 0, 0);
        this.GetComponent<objects>().enabled = true;
        Destroy(this);
    }

    private GameObject ClickObject3D()
    {
        RaycastHit hit;
        GameObject target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }
}
