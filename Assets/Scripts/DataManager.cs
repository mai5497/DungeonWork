//=============================================================================
//
// �f�[�^�}�l�[�W���[
//
// �쐬��:2022/03/16
// �쐬��:�ɒn�c�^��
//
// <�J������>
// 2022/03/16 �쐬
//
//=============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DataManager : MonoBehaviour
{
    /*
     * �Z�[�u�f�[�^�̊Ǘ��E���̃f�[�^�̊Ǘ��ȂǑf�ނ̃f�[�^�̊Ǘ�������(�\��)
     * �^�C�g���ŌĂяo��������B���������B
     * 
     * 
     * 
     */

    static int TargetFrame = 60;

    //-----------------------------------------------------
    // BGM�ESE
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
        // BGM�ESE
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
