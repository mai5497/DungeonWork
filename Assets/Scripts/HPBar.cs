using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {
    //最大HPと現在のHP。
    public static int maxHp = 100;
    public static int currentHp = maxHp;
    //Sliderを入れる
    public Slider slider;

    private EXPBar _EXPBar;   // レベルアップしたらHPを回復するためにHPを持っているHPBarを取得

    void Start() {
        _EXPBar = GetComponent<EXPBar>();
    }


    void Update() {
        //最大HPにおける現在のHPをSliderに反映。
        //int同士の割り算は小数点以下は0になるので、
        //(float)をつけてfloatの変数として振舞わせる。
        slider.value = (float)currentHp / (float)maxHp;
    }
    //ColliderオブジェクトのIsTriggerにチェック入れること。
    private void OnCollisionEnter2D(Collision2D collision) {
        //Enemyタグのオブジェクトに触れると発動
        if (collision.gameObject.tag == "Enemy") {
            //ダメージは1～100の中でランダムに決める。
            int damage = Random.Range(1, 100);
            //Debug.Log("damage : " + damage);

            //現在のHPからダメージを引く
            currentHp = currentHp - damage;
            //Debug.Log("After currentHp : " + currentHp);

            //Debug.Log("slider.value : " + slider.value);

            SoundManager.Play(SoundData.eSE.SE_PLAYER_DAMAGE, SoundData.GameAudioList);
        }
    }

    public void HealFill() {
        maxHp = _EXPBar.GetCurrentLevel() * 100;    // この関数が呼ばれるときはレベルアップしたとき  
                                                    // HPのMAXも調整する

        currentHp = maxHp;
    }
}