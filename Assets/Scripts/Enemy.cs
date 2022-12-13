using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject exp;

    private float moveDir;
    private const float moveSpeed = 0.002f;
    private float moveVal;

    private int moveTimer;
    // Start is called before the first frame update
    void Start()
    {
        moveTimer = 0;
        moveDir = randomDir();
        moveVal = moveSpeed * moveDir;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + moveVal, transform.position.y, transform.position.z);

        moveTimer++;
        if(moveTimer > 480) {
            moveDir = randomDir();
            moveVal = moveSpeed * moveDir;
            
            moveTimer = 0;
        }
    }

    //private void OnTriggerStay2D(Collider2D collision) {
    //    if (collision.tag == "Weapon") {
    //        Destroy(this.gameObject);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Weapon") {
            int expnum = Random.Range(1, 5+1);
            for (int i = 0; i < expnum; i++) {
                Vector3 expPos = this.gameObject.GetComponent<Transform>().position;
                expPos.x += Random.Range(-0.5f, 0.5f);
                expPos.y += Random.Range(-0.5f, 0.5f);

                Instantiate(exp, expPos, Quaternion.identity);
            }
            Destroy(this.gameObject);
            SoundManager.Play(SoundData.eSE.SE_ENEMY_DOWN, SoundData.GameAudioList);
            //SoundManager.Play(SoundData.eSE.SE_PLAYER_DAMAGE, SoundData.GameAudioList);
        }
    }

    private float randomDir() {
        Vector3 enemyScale = this.transform.localScale;
        if (Random.Range(0, 1 + 1) == 0) {
            enemyScale.x = 4;
            this.transform.localScale = enemyScale;
            return -1;
        } else {
            enemyScale.x = -4;
            this.transform.localScale = enemyScale;
            return 1;
        }
    }
    //private void OnTriggerExit2D(Collider2D collision) {
    //    if (collision.tag == "Weapon") {
    //        Destroy(this.gameObject);
    //    }
    //}
}
