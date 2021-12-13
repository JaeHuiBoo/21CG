using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class opening : MonoBehaviour
{
    [SerializeField]
    private GameObject GameManager;

    [SerializeField]
    private GameObject openingPanel;

    [SerializeField]
    private GameObject openingImg;

    [SerializeField]
    private Text openingText;

    public string[] texts;

    public void playButtonClick()
    {
        StartCoroutine(playAnim());
    }

    IEnumerator playAnim()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        button.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1.0f);
        openingPanel.GetComponent<Animator>().enabled = true;
        var child = openingPanel.GetComponentsInChildren<Transform>();
        foreach (var iter in child)
        {
            if (iter != this.transform)
            {
                Destroy(iter.gameObject);
            }
        }
        yield return new WaitForSeconds(10.0f);
        openingImg.SetActive(true);
        openingText.text = "여기가.. 어디지..?";
        yield return new WaitForSeconds(2.3f);
        foreach(string str in texts)
        {
            for (int i = 0; i < str.Length; i++)
            {
                openingText.text = str.Substring(0, i + 1);
                yield return new WaitForSeconds(0.08f);
                if (i == str.Length - 1)
                {
                    yield return new WaitForSeconds(0.13f);
                }
            }
        }
        openingImg.SetActive(false);
        GameManager.SetActive(true);
        Destroy(openingPanel);
    }
}
