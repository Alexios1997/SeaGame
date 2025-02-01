using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UiManagSc : MonoBehaviour
{

    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitG()
    {
        Application.Quit();
    }
}
