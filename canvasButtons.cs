using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class canvasButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject cluePanel;

    [SerializeField]
    private GameObject lockPanel;

    [SerializeField]
    private GameObject clueButton;

    [SerializeField]
    private GameObject lockButton;

    [SerializeField]
    private GameObject clueBackButton;

    [SerializeField]
    private GameObject lockBackButton;

    private void Start()
    {
        cluePanel.SetActive(false);
        clueButton.SetActive(true);
        clueBackButton.SetActive(false);

        if (lockButton != null)
        {
            lockPanel.SetActive(false);
            lockBackButton.SetActive(false);
            lockButton.SetActive(true);
        }
    }

    public void clueButtonClick()
    {
        cluePanel.SetActive(true);
        clueBackButton.SetActive(true);
        clueButton.SetActive(false);

        if (lockButton != null)
        {
            lockPanel.SetActive(false);
            lockBackButton.SetActive(false);
            lockButton.SetActive(false);
        }
    }

    public void clueBackButtonClick()
    {
        cluePanel.SetActive(false);
        clueBackButton.SetActive(false);
        clueButton.SetActive(true);

        if (lockButton != null)
        {
            lockPanel.SetActive(false);
            lockBackButton.SetActive(false);
            lockButton.SetActive(true);
        }
    }

    public void lockButtonClick()
    {
        cluePanel.SetActive(false);
        lockPanel.SetActive(true);

        clueBackButton.SetActive(false);
        lockBackButton.SetActive(true);

        clueButton.SetActive(false);
        lockButton.SetActive(false);
    }

    public void lockBackButtonClick()
    {
        cluePanel.SetActive(false);
        lockPanel.SetActive(false);

        clueBackButton.SetActive(false);
        lockBackButton.SetActive(false);

        clueButton.SetActive(true);
        lockButton.SetActive(true);
    }
}
