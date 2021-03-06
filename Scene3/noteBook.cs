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
    GameObject noteBookHintText;

    [SerializeField]
    private GameObject backToOriginButton;

    public bool lookAtNotebook = false;

    public void notebookBtnClick()
    {
        backBtn3.originCameraPos = mainCamera.transform.position;
        backBtn3.originCameraRotation = mainCamera.transform.rotation;
        AudioSource audio = this.GetComponent<AudioSource>();
        audio.Play();
        notebookBtn.SetActive(false);
        noteBookHintText.SetActive(true);
        backToOriginButton.SetActive(true);
        lookAtNotebook = true;
        mainCamera.transform.position = new Vector3(32.01f, 10.52f, -21.6f);
        mainCamera.transform.rotation = Quaternion.Euler(new Vector3(0, 90f, 0));
    }
}
