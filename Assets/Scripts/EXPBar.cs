using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPBar : MonoBehaviour {
    //�ő�HP�ƌ��݂�HP�B
    public static float maxEXP = 10;
    public static float currentEXP = 1;
    public static int currentLevel = 1;
    //Slider������
    public Slider slider;

    private HPBar _HPBar;   // ���x���A�b�v������HP���񕜂��邽�߂�HP�������Ă���HPBar���擾

    void Start() {

        _HPBar = this.GetComponent<HPBar>();    // ����Player�ɓ����Ă���
    }

    void Update() {
        while (currentEXP > maxEXP) {
            currentLevel++;
            _HPBar.HealFill();  // ���x���A�b�v������HP���^������
            maxEXP *= 1.1f;
            if(currentEXP < maxEXP) {
                currentEXP = 0;
            }
        }
        slider.value = (float)currentEXP / (float)maxEXP;
        //Debug.Log("slider.value : " + slider.value);
    }

    //Collider�I�u�W�F�N�g��IsTrigger�Ƀ`�F�b�N����邱�ƁB
    private void OnCollisionEnter2D(Collision2D collision) {
        //Enemy�^�O�̃I�u�W�F�N�g�ɐG���Ɣ���
        if (collision.gameObject.tag == "EXPOrb") {
            //�_���[�W��1�`100�̒��Ń����_���Ɍ��߂�B
            int exp = 5;
            //Debug.Log("damage : " + exp);
            
            //���݂̌o���l�ɑ���
            currentEXP = currentEXP + exp;
            //Debug.Log("After currentHp : " + currentEXP);

            SoundManager.Play(SoundData.eSE.SE_EXP_ORB,SoundData.GameAudioList);    // ���炷

            Destroy(collision.gameObject);
        }
    }

    public int GetCurrentLevel() {
        return currentLevel;
    }
}