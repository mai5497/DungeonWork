using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    private MyInput inputActions;
    private bool isDecision;

    // Start is called before the first frame update
    void Start()
    {
        MySceneManager.currentScene = MySceneManager.nextScene = (int)MySceneManager.SCENESTATE.TITLE;

        isDecision = false;

        inputActions = new MyInput();
        inputActions.UI.Decision.canceled += OnDecision;
        inputActions.Enable();

        for (int i = 0; i < SoundData.TitleAudioList.Length; ++i) {
            SoundData.TitleAudioList[i] = gameObject.AddComponent<AudioSource>();
        }
        SoundManager.Play(SoundData.eBGM.BGM_TITLE, SoundData.TitleAudioList);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDecision)
        {
            int randomScene = Random.Range(1, 3);
            MySceneManager.nextScene = randomScene;
            MySceneManager.SceneChange();
        }
    }

    private void OnDecision(InputAction.CallbackContext obj) {
        isDecision = true;
    }
}
