using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour{
    private void Awake() {
        Application.targetFrameRate = 30; //30FPSÇ…ê›íË
    }

    // Start is called before the first frame update
    void Start()
    {
        MySceneManager.currentScene = MySceneManager.nextScene;


        for (int i = 0; i < SoundData.GameAudioList.Length; ++i) {
            SoundData.GameAudioList[i] = gameObject.AddComponent<AudioSource>();
        }
        SoundManager.Play(SoundData.eBGM.BGM_STAGE1, SoundData.GameAudioList);
    }

    // Update is called once per frame
    void Update()
    {
        //if(MySceneManager.currentScene != MySceneManager.nextScene) {
        //    MySceneManager.SceneChange();
        //}
    }
}
