using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static string[] sceneName = { "Title","Stage01","Stage02","Stage02" };

    public static int currentScene;
    public static int nextScene;

    public enum SCENESTATE {
        TITLE = 0,
        STAGE_01,
        STAGE_02,
        STAGE_03,

        MAX_SCENE
    };

    public static void SceneChange() {
        string nextSceneName = sceneName[nextScene];
        SceneManager.LoadScene(nextSceneName);
    }
}
