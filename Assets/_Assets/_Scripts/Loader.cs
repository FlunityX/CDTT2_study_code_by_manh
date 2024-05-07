using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{
     
    public enum Scene
    {
        MenuScene,
        GameScene,
        LoadingScene,
    }
    // Start is called before the first frame update
    private static Scene targetScene;

    public static void ReloadScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
      
    }
    public static string GetCurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    public static void Load(Scene _targetScene)
    {
        
        Loader.targetScene = _targetScene;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());


    }
    public static void LoadByName(string _targetScene)
    {
 
        SceneManager.LoadScene(_targetScene);

    }
    public static void LoaderCallBack()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }
}
