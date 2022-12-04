using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{

    public void quitGame()
    {
        Application.Quit();
    }

    public void load_scene_target(int target)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(target);
    }

}
