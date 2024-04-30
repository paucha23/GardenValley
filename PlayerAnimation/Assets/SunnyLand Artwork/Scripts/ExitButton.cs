using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public string menuToLoad;

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
