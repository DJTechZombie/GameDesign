using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void selectedReplay()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByName("Main").buildIndex);
    }

    public void selectedQuit()
    {
        Application.Quit();
    }
}
