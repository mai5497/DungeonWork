using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPBar : MonoBehaviour {
    //最大HPと現在のHP。
    public static float maxEXP = 10;
    public static float currentEXP = 1;
    public static int currentLevel = 1;
    //Sliderを入れる
    public Slider slider;

    private HPBar _HPBar;   // レベルアップしたらHPを回復するためにHPを持っているHPBarを取得

    void Start() {

        _HPBar = this.GetComponent<HPBar>();    // 同じPlayerに入っている
    }

    void Update() {
        while (currentEXP > maxEXP) {
            currentLevel++;
            _HPBar.HealFill();  // レベルアップしたらHP満タンする
            maxEXP *= 1.1f;
            if(currentEXP < maxEXP) {
                currentEXP = 0;
            }
        }
        slider.value = (float)currentEXP / (float)maxEXP;
        //Debug.Log("slider.value : " + slider.value);
    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    private void OnCollisionEnter2D(Collision2D collision) {
        //Enemyタグのオブジェクトに触れると発動
        if (collision.gameObject.tag == "EXPOrb") {
            //ダメージは1～100の中でランダムに決める。
            int exp = 5;
            //Debug.Log("damage : " + exp);
            
            //現在の経験値に足す
            currentEXP = currentEXP + exp;
            //Debug.Log("After currentHp : " + currentEXP);

            SoundManager.Play(SoundData.eSE.SE_EXP_ORB,SoundData.GameAudioList);    // 音鳴らす

            Destroy(collision.gameObject);
        }
    }

    public int GetCurrentLevel() {
        return currentLevel;
    }
}