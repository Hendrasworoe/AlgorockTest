using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeSceneTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeSceneTo(int buildedSceneIndex)
    {
        SceneManager.LoadScene(buildedSceneIndex);
    }
}
