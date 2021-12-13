using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class guide : MonoBehaviour
{
    [SerializeField]
    private GameObject fadeinoutImg;

    [SerializeField]
    private GameObject GameManager;

    [SerializeField]
    private GameObject openingImg;

    [SerializeField]
    private Text openingText;

    public string[] texts;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playAnim(SceneManager.GetActiveScene().name));
    }
    IEnumerator playAnim(string name)
    {
        int sceneNum;
        if (name == "Scene2")
            sceneNum = 2;
        else if (name == "Scene3")
            sceneNum = 3;
        yield return new WaitForSeconds(2.5f);
        openingImg.SetActive(true);
        foreach (string str in texts)
        {
            for (int i = 0; i < str.Length; i++)
            {
                openingText.text = str.Substring(0, i + 1);
                yield return new WaitForSeconds(0.07f);
                if (i == str.Length - 1)
                {
                    yield return new WaitForSeconds(0.13f);
                }
            }
        }
        openingImg.SetActive(false);
        GameManager.SetActive(true);
    }
}
