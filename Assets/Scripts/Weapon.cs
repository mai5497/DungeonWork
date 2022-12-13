using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Vector3 weaponPos;  // 武器座標
    private GameObject player;  // プレイヤーオブジェクト
    private SpriteRenderer sprite;  // 武器のアルファ値変えるのに使う

    private BoxCollider2D collider; // コライダーオンオフに使用

    private Vector3 weaponscale;  // 左右反転のために使用

    private bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        weaponPos = GetComponent<Transform>().position;
        player = GameObject.Find("Player");
        sprite = GetComponent<SpriteRenderer>();

        weaponscale = this.GetComponent<Transform>().localScale;// スケール値取り出し

        collider = GetComponent<BoxCollider2D>();

        sprite.color = Color.clear;
        collider.enabled = false;

        isMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        weaponscale = this.GetComponent<Transform>().localScale;// スケール値再取得

        if (Player.isAttack) {
            if (!isMove) {
                WeaponAppear();
            } else {
                WeaponMove();
            }

            this.transform.position = weaponPos;    // 武器の座標更新
        } else {
            sprite.color = Color.clear; // 非表示
            collider.enabled = false;   // 当たり判定中断
            isMove = false;
                
        }

        transform.localScale = weaponscale; // スケール値更新
    }

    void WeaponMove() {
        if(weaponscale.x < 0) {   // ０以下は左向き
            weaponPos.x += 0.005f;
        } else {
            weaponPos.x -= 0.005f;
        }
    }

    private void WeaponAppear() {
        Vector3 playerPos = player.GetComponent<Transform>().position;
        collider.enabled = true;    // 当たり判定再開
        sprite.color = Color.white; // アルファ値を上げる
        
        if(player.transform.localScale.x < 0) {
            weaponscale.x = -2.5f;
        } else {
            weaponscale.x = 2.5f;
        }

        if (weaponscale.x < 0) {   // ０以下は左向き
            weaponPos = new Vector3(playerPos.x + 0.7f, playerPos.y - 0.15f, playerPos.z); // 座標を決める
        } else {
            weaponPos = new Vector3(playerPos.x - 0.7f, playerPos.y - 0.15f, playerPos.z); // 座標を決める
        }

        isMove = true;
    }
}
