//=============================================================================
//
// �T�E���h�f�[�^
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
using UnityEditor;

//public class SoundData : ScriptableObject {
public class SoundData : MonoBehaviour {
    public enum eBGM {      // BGM�ԍ�
        BGM_TITLE = 0,
        BGM_STAGE1,

        MAX_BGM
    }

    public enum eSE {       // SE�ԍ�
        SE_JUMP = 0,
        SE_ATTACK,
        SE_ENEMY_DOWN,
        SE_PLAYER_DAMAGE,
        SE_EXP_ORB,

        MAX_SE
    }

    //[SerializeField]
    //AudioClip[] SE = new AudioClip[(int)eSE.MAX_SE];

    //public static AudioClip[] SEClip = new AudioClip[(int)eSE.MAX_SE];

    //public static AudioClip[] BGMClip = new AudioClip[(int)eBGM.MAX_BGM];   // �f�[�^���܂Ƃ߂ē����
    //public static float[] SEVolume = new float[(int)eSE.MAX_SE];

    //public static AudioSource[] TitleAudioList = new AudioSource[20];    // ���ɓ����ɂȂ点�鐔
    //public static AudioSource[] IndelibleAudioList = new AudioSource[10];    // ���ɓ����ɂȂ点�鐔
    //public static AudioSource[] GameAudioList = new AudioSource[30];    // ���ɓ����ɂȂ点�鐔

    //[SerializeField]
    //public List<AudioClip> SE = new List<AudioClip>((int)eSE.MAX_SE);

    [SerializeField]
    public static List<AudioClip> SEClip = new List<AudioClip>((int)eSE.MAX_SE);

    public static List<AudioClip> BGMClip = new List<AudioClip>((int)eBGM.MAX_BGM);   // �f�[�^���܂Ƃ߂ē����
   public static float[] SEVolume = new float[(int)eSE.MAX_SE];

    public static AudioSource[] TitleAudioList = new AudioSource[20];    // ���ɓ����ɂȂ点�鐔
    public static List<AudioSource> IndelibleAudioList = new List<AudioSource>(10);    // ���ɓ����ɂȂ点�鐔
    public static AudioSource[] GameAudioList = new AudioSource[30];    // ���ɓ����ɂȂ点�鐔
    public static bool isSetSound = false;


    public static void SEDataSet(List<AudioClip> _SE)    // SE�̃f�[�^��ǂݍ���
    {
        SEClip = _SE;
    }
    public static void BGMDataSet(List<AudioClip> _BGM)    // SE�̃f�[�^��ǂݍ���
    {
        BGMClip = _BGM;
    }

}