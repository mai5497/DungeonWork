using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {
    //�ő�HP�ƌ��݂�HP�B
    public static int maxHp = 100;
    public static int currentHp = maxHp;
    //Slider������
    public Slider slider;

    private EXPBar _EXPBar;   // ���x���A�b�v������HP���񕜂��邽�߂�HP�������Ă���HPBar���擾

    void Start() {
        _EXPBar = GetComponent<EXPBar>();
    }


    void Update() {
        //�ő�HP�ɂ����錻�݂�HP��Slider�ɔ��f�B
        //int���m�̊���Z�͏����_�ȉ���0�ɂȂ�̂ŁA
        //(float)������float�̕ϐ��Ƃ��ĐU���킹��B
        slider.value = (float)currentHp / (float)maxHp;
    }
    //Collider�I�u�W�F�N�g��IsTrigger�Ƀ`�F�b�N����邱�ƁB
    private void OnCollisionEnter2D(Collision2D collision) {
        //Enemy�^�O�̃I�u�W�F�N�g�ɐG���Ɣ���
        if (collision.gameObject.tag == "Enemy") {
            //�_���[�W��1�`100�̒��Ń����_���Ɍ��߂�B
            int damage = Random.Range(1, 100);
            //Debug.Log("damage : " + damage);

            //���݂�HP����_���[�W������
            currentHp = currentHp - damage;
            //Debug.Log("After currentHp : " + currentHp);

            //Debug.Log("slider.value : " + slider.value);

            SoundManager.Play(SoundData.eSE.SE_PLAYER_DAMAGE, SoundData.GameAudioList);
        }
    }

    public void HealFill() {
        maxHp = _EXPBar.GetCurrentLevel() * 100;    // ���̊֐����Ă΂��Ƃ��̓��x���A�b�v�����Ƃ�  
                                                    // HP��MAX����������

        currentHp = maxHp;
    }
}