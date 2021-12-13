using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class clues : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> clueObj;

    [SerializeField]
    private List<GameObject> cluesInPanel;

    [SerializeField]
    private GameObject remoteController;

    [SerializeField]
    private GameObject boxDoor;

    [SerializeField]
    private GameObject doorlock;

    [SerializeField]
    private GameObject boxlock;

    [SerializeField]
    private GameObject mainCam;

    [SerializeField]
    private GameObject fadeinoutImg;

    [SerializeField]
    private GameObject clueImg;

    [SerializeField]
    private GameObject guidePanel;

    private GameObject clickedObj;  //클릭한 3D object 
    private int indexofclue;  //찾은 퍼즐들의 index  
    public bool firstclueClear; //첫 퍼즐 완료 여부 
    private GameObject tmp; 
    private string tag; //clicked object의 tag
    private string name; //clicked object의 name 
    private int num; //사용자가 입력한 값들의 개수 
    private int numofClue;
    private bool lastStep;

    // Start is called before the first frame update
    void Start()
    {
        firstclueClear = false;
        indexofclue = 5;
        foreach (GameObject clue in cluesInPanel)
            clue.SetActive(false);
        foreach (GameObject clue in clueObj)
            clue.SetActive(false);
        remoteController.SetActive(false);
        doorlock.SetActive(false);
        tmp = null;
        num = 0;
        numofClue = 0;
        lastStep = false;
    }

    // Update is called once per frame
    void Update()
    {
        clickedObj = ClickObject3D();
        if (clickedObj != null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (!firstclueClear)
                {
                    if (this.gameObject.GetComponent<scene1_UI>().breakerClicked)
                    {
                        tag = clickedObj.tag;
                        if (tag == "number")
                        {
                            name = clickedObj.name;
                            tmp = boxlock.transform.GetChild(0).gameObject;
                            if (num < 6)
                            {
                                if (num == 0)
                                    tmp.GetComponent<TextMesh>().text = "";
                                tmp.GetComponent<TextMesh>().text += name.Substring(name.IndexOf("_") + 1);
                                num += 1;
                            }
                        }
                        else if (tag == "eraser" && num != 0)
                        {
                            tmp = boxlock.transform.GetChild(0).gameObject;
                            string str = tmp.GetComponent<TextMesh>().text;
                            str = str.Substring(0, str.Length - 1);
                            tmp.GetComponent<TextMesh>().text = str;
                            num -= 1;
                        }
                        else if (tag == "enter")
                        {
                            tmp = boxlock.transform.GetChild(0).gameObject;
                            if (tmp.GetComponent<TextMesh>().text == "410")
                            {
                                firstclueClear = true;
                                foreach (GameObject clue in clueObj)
                                    clue.SetActive(true);
                                tmp = null;
                                num = 0;
                            }
                            else
                            {
                                tmp.GetComponent<TextMesh>().text = "틀렸습니다";
                                num = 0;
                            }
                        }
                    }
                }
                else if (numofClue == 6)
                {
                    if (clickedObj == doorlock)
                    {
                        lastStep = true;
                        mainCam.GetComponent<move>().enabled = false;
                        mainCam.transform.position = new Vector3(-14.4f, 15.5f, 52.6f);
                        mainCam.transform.localEulerAngles = new Vector3(0, -5.47f, 0);
                        doorlock.GetComponent<BoxCollider>().enabled = false;
                    }
                    else
                    {
                        tag = clickedObj.tag;
                        if (tag == "number")
                        {
                            name = clickedObj.name;
                            tmp = doorlock.transform.GetChild(0).gameObject;
                            if (num < 6)
                            {
                                if (num == 0)
                                    tmp.GetComponent<TextMesh>().text = "";
                                tmp.GetComponent<TextMesh>().text += name.Substring(name.IndexOf("_") + 1);
                                num += 1;
                            }
                        }
                        else if (tag == "eraser" && num != 0)
                        {
                            tmp = doorlock.transform.GetChild(0).gameObject;
                            string str = tmp.GetComponent<TextMesh>().text;
                            str = str.Substring(0, str.Length - 1);
                            tmp.GetComponent<TextMesh>().text = str;
                            num -= 1;
                        }
                        else if (tag == "enter")
                        {
                            tmp = doorlock.transform.GetChild(0).gameObject;
                            if (tmp.GetComponent<TextMesh>().text == "365483")
                            {
                                StartCoroutine(scenechg());
                            }
                            else
                            {
                                tmp.GetComponent<TextMesh>().text = "틀렸습니다";
                                num = 0;
                            }
                        }
                    }
                }
                else
                {
                    if (clueObj.Contains(clickedObj))
                    {
                        indexofclue = clueObj.IndexOf(clickedObj);
                        StartCoroutine(collect(indexofclue));
                    }
                }
                }
                else
                {
                    if (numofClue < 6)
                    {
                        if (clueObj.Contains(clickedObj))
                        {
                            indexofclue = clueObj.IndexOf(clickedObj);
                            clickedObj.GetComponent<Outline>().enabled = true;
                        }
                        else
                        {
                            clueObj[indexofclue].GetComponent<Outline>().enabled = false;
                        }
                    }
                    else
                    {
                        if (!lastStep)
                        {
                            if (clickedObj == doorlock)
                            {
                                doorlock.GetComponent<Outline>().enabled = true;
                            }
                            else
                            {
                                doorlock.GetComponent<Outline>().enabled = false;
                            }
                        }
                    }
                }
            clickedObj = null;
        }
    }
    IEnumerator collect(int index)
    {
        clueImg.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/clue_" + index) as Sprite;
        clueImg.GetComponent<Animator>().enabled = true;
        clueImg.GetComponent<Animator>().Play("clueImg"); clickedObj.SetActive(false);
        yield return new WaitForSeconds(4.5f);
        cluesInPanel[index].SetActive(true);
        clueImg.SetActive(false);
        cluesInPanel[index].GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/clue_" + index) as Sprite;
        numofClue += 1;
        if (numofClue == 6)
            doorlock.SetActive(true);
    }

    IEnumerator scenechg()
    {
        doorlock.GetComponent<Outline>().enabled = false;
        mainCam.transform.position = new Vector3(-1.0f, 19.4f, 35.2f);
        mainCam.transform.rotation = Quaternion.Euler(0, -46.922f, 0);
        doorlock.GetComponentInParent<Animator>().enabled = true;
        yield return new WaitForSeconds(1.2f);
        fadeinoutImg.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Scene2");
    }

    public void questionButton()
    {
        if (guidePanel.activeSelf)
            guidePanel.SetActive(false);
        else
            guidePanel.SetActive(true);
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
