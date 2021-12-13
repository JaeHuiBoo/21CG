using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    [SerializeField]
    private GameObject fadeinoutImg;

    [SerializeField]
    private GameObject cluebag;

    [SerializeField]
    private GameObject back;

    [SerializeField]
    private GameObject clearPanel;

    public void next()
    {
        if (SceneManager.GetActiveScene().name == "Scene2")
        {
            cluebag.SetActive(false);
            back.SetActive(false);
        }
        fadeinoutImg.GetComponent<Animator>().Play("fadein");
        Invoke("scenechg", 2.0f);  //delay
        
    }

    private void scenechg()
    {
        if (SceneManager.GetActiveScene().name == "Scene2")
            SceneManager.LoadScene("Scene3");
        else if (SceneManager.GetActiveScene().name == "Scene3")
            clearPanel.SetActive(true);
        Invoke("gameover", 2.0f);  //delay
    }
    private void gameover()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
