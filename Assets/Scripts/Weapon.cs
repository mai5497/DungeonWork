using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Vector3 weaponPos;  // ������W
    private GameObject player;  // �v���C���[�I�u�W�F�N�g
    private SpriteRenderer sprite;  // ����̃A���t�@�l�ς���̂Ɏg��

    private BoxCollider2D collider; // �R���C�_�[�I���I�t�Ɏg�p

    private Vector3 weaponscale;  // ���E���]�̂��߂Ɏg�p

    private bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        weaponPos = GetComponent<Transform>().position;
        player = GameObject.Find("Player");
        sprite = GetComponent<SpriteRenderer>();

        weaponscale = this.GetComponent<Transform>().localScale;// �X�P�[���l���o��

        collider = GetComponent<BoxCollider2D>();

        sprite.color = Color.clear;
        collider.enabled = false;

        isMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        weaponscale = this.GetComponent<Transform>().localScale;// �X�P�[���l�Ď擾

        if (Player.isAttack) {
            if (!isMove) {
                WeaponAppear();
            } else {
                WeaponMove();
            }

            this.transform.position = weaponPos;    // ����̍��W�X�V
        } else {
            sprite.color = Color.clear; // ��\��
            collider.enabled = false;   // �����蔻�蒆�f
            isMove = false;
                
        }

        transform.localScale = weaponscale; // �X�P�[���l�X�V
    }

    void WeaponMove() {
        if(weaponscale.x < 0) {   // �O�ȉ��͍�����
            weaponPos.x += 0.005f;
        } else {
            weaponPos.x -= 0.005f;
        }
    }

    private void WeaponAppear() {
        Vector3 playerPos = player.GetComponent<Transform>().position;
        collider.enabled = true;    // �����蔻��ĊJ
        sprite.color = Color.white; // �A���t�@�l���グ��
        
        if(player.transform.localScale.x < 0) {
            weaponscale.x = -2.5f;
        } else {
            weaponscale.x = 2.5f;
        }

        if (weaponscale.x < 0) {   // �O�ȉ��͍�����
            weaponPos = new Vector3(playerPos.x + 0.7f, playerPos.y - 0.15f, playerPos.z); // ���W�����߂�
        } else {
            weaponPos = new Vector3(playerPos.x - 0.7f, playerPos.y - 0.15f, playerPos.z); // ���W�����߂�
        }

        isMove = true;
    }
}
