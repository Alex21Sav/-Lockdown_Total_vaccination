using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController
{
    private static int _mainScene = 0;

    public static void LoadMainScene()
    {
        SceneManager.LoadScene(_mainScene);
    }

    public static void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if(currentScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentScene + 1);
        }        
    }
    public static void LoadPreviousScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene > 0)
        {
            SceneManager.LoadScene(currentScene - 1);
        }
    }

    public static void LoadScene(int index)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (index >= 0 && index < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(index);
        }
    }


}
