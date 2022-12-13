//=============================================================================
//
// データマネージャー
//
// 作成日:2022/03/16
// 作成者:伊地田真衣
//
// <開発履歴>
// 2022/03/16 作成
//
//=============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DataManager : MonoBehaviour
{
    /*
     * セーブデータの管理・音のデータの管理など素材のデータの管理をする(予定)
     * タイトルで呼び出しをする。ぜったい。
     * 
     * 
     * 
     */

    static int TargetFrame = 60;

    //-----------------------------------------------------
    // BGM・SE
    //-----------------------------------------------------
    [SerializeField]
    private AudioClip bgm_title;
    [SerializeField]
    private AudioClip bgm_stage1;


    [SerializeField]
    private AudioClip se_jump;
    [SerializeField]
    private AudioClip se_goal;
    [SerializeField]
    private AudioClip se_bone;

    [SerializeField]
    private List<AudioClip> SEdat = new List<AudioClip>((int)SoundData.eSE.MAX_SE);
    [SerializeField]
    private List<AudioClip> BGMdat = new List<AudioClip>((int)SoundData.eBGM.MAX_BGM);

    void Awake() {
        Application.targetFrameRate = TargetFrame;
        //-----------------------------------------------------
        // BGM・SE
        //-----------------------------------------------------
        //SoundData.BGMDataSet(bgm_title, (int)SoundData.eBGM.BGM_TITLE);
        //SoundData.BGMDataSet(bgm_stage1, (int)SoundData.eBGM.BGM_STAGE1);

        //SoundData.SEDataSet(se_jump, (int)SoundData.eSE.SE_JUMP);
        //SoundData.SEDataSet(se_goal, (int)SoundData.eSE.SE_GOAL);
        //SoundData.SEDataSet(se_bone, (int)SoundData.eSE.SE_BONE);

        //Debug.Log(SEdat[0]);
        SoundData.SEDataSet(SEdat);
        SoundData.BGMDataSet(BGMdat);

        for (int i = 0; i < SoundData.SEVolume.Length; i++) {
            SoundData.SEVolume[i] = 1.0f;
        }
    }
}
