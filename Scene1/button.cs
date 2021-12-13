using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class button : MonoBehaviour
{
    [SerializeField]
    private GameObject cluePanel;

    [SerializeField]
    private GameObject clueButton;

    [SerializeField]
    private GameObject backButton;

    void Start()
    {
        clueButton.SetActive(true);
    }

    //private GameObject clickObj;
    public void clueButtonClick()
    {
        cluePanel.SetActive(true);
        clueButton.SetActive(false);
        backButton.SetActive(true);
    }

    public void backButtonClick()
    {
        cluePanel.SetActive(false);
        clueButton.SetActive(true);
        backButton.SetActive(false);
    }
}
