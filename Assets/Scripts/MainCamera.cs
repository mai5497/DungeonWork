using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private const float cameraWidth = 7.7f, cameraHeight = 5;

    private Vector2 stageSizes;
    private float edgeRight, edgeLeft, edgeUp, edgeDown;    // ステージの端をとる
    private float cameraRight, cameraLeft,cameraUp,cameraDown;  // カメラの端をとる
    private int tmp;

    private GameObject rawStage, stage;
    private GameObject player;

    void Start() {
        stage = GameObject.FindWithTag("Stage");
        player = GameObject.Find("Player");

        stageSizes = Vector2.zero;

        stageSizes = stage.GetComponent<BoxCollider2D>().bounds.size;
    }

    void Update() {
        edgeLeft = stage.transform.position.x - (stageSizes.x / 2) + cameraWidth;
        edgeRight = stage.transform.position.x + (stageSizes.x / 2) - cameraWidth;
        edgeDown = stage.transform.position.y - (stageSizes.y / 2) + cameraHeight;
        edgeUp = stage.transform.position.y + (stageSizes.y / 2) - cameraHeight;

        Debug.Log("edgeleft:" + edgeLeft);
        Debug.Log("edgeright:" + edgeRight);


        // カメラの横方向ワープ移動
        //if (edgeLeft >= transform.position.x) {
        //    transform.position += (edgeLeft - transform.position.x) * Vector3.right;
        //} else if (edgeRight <= transform.position.x) {
        //    transform.position += (edgeRight - transform.position.x) * Vector3.right;
        //}

        //// カメラの縦方向ワープ移動
        //if (edgeDown >= transform.position.y) {
        //    transform.position += (edgeDown - transform.position.y) * Vector3.up;
        //} else if (edgeUp <= transform.position.y) {
        //    transform.position += (edgeUp - transform.position.y) * Vector3.up;
        //}

        // カメラのキャラ追従移動
        if (player.transform.position.x > edgeLeft && player.transform.position.x < edgeRight) {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
        if (player.transform.position.y > edgeDown && player.transform.position.y < edgeUp) {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
    }
}
