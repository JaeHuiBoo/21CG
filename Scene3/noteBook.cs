using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteBook : MonoBehaviour
{
    [SerializeField]
    GameObject mainCamera;

    [SerializeField]
    GameObject notebookBtn;

    [SerializeField]
    GameObject clue_0;

    [SerializeField]
    private GameObject backToOriginButton;

    public bool lookAtNotebook = false;

    public void notebookBtnClick()
    {
        AudioSource audio = this.GetComponent<AudioSource>();
        audio.Play();
        notebookBtn.SetActive(false);
        clue_0.SetActive(true);
        backToOriginButton.SetActive(true);
        lookAtNotebook = true;
        mainCamera.transform.position = new Vector3(32.01f, 10.52f, -21.6f);
        mainCamera.transform.rotation = Quaternion.Euler(new Vector3(0, 90f, 0));
    }
}
