//=============================================================================
//
// サウンドデータ
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
using UnityEditor;

//public class SoundData : ScriptableObject {
public class SoundData : MonoBehaviour {
    public enum eBGM {      // BGM番号
        BGM_TITLE = 0,
        BGM_STAGE1,

        MAX_BGM
    }

    public enum eSE {       // SE番号
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

    //public static AudioClip[] BGMClip = new AudioClip[(int)eBGM.MAX_BGM];   // データをまとめて入れる
    //public static float[] SEVolume = new float[(int)eSE.MAX_SE];

    //public static AudioSource[] TitleAudioList = new AudioSource[20];    // 一回に同時にならせる数
    //public static AudioSource[] IndelibleAudioList = new AudioSource[10];    // 一回に同時にならせる数
    //public static AudioSource[] GameAudioList = new AudioSource[30];    // 一回に同時にならせる数

    //[SerializeField]
    //public List<AudioClip> SE = new List<AudioClip>((int)eSE.MAX_SE);

    [SerializeField]
    public static List<AudioClip> SEClip = new List<AudioClip>((int)eSE.MAX_SE);

    public static List<AudioClip> BGMClip = new List<AudioClip>((int)eBGM.MAX_BGM);   // データをまとめて入れる
   public static float[] SEVolume = new float[(int)eSE.MAX_SE];

    public static AudioSource[] TitleAudioList = new AudioSource[20];    // 一回に同時にならせる数
    public static List<AudioSource> IndelibleAudioList = new List<AudioSource>(10);    // 一回に同時にならせる数
    public static AudioSource[] GameAudioList = new AudioSource[30];    // 一回に同時にならせる数
    public static bool isSetSound = false;


    public static void SEDataSet(List<AudioClip> _SE)    // SEのデータを読み込む
    {
        SEClip = _SE;
    }
    public static void BGMDataSet(List<AudioClip> _BGM)    // SEのデータを読み込む
    {
        BGMClip = _BGM;
    }

}