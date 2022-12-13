using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

    [SerializeField]
    RectTransform buttonRt_L;
    [SerializeField]
    RectTransform buttonRt_R;
    [SerializeField]
    RectTransform buttonRt_J;
    [SerializeField]
    RectTransform buttonRt_A;

    [SerializeField]
    Canvas buttonCanvas;

    private enum PLAYERSTATE {
        IDLE = 0,
        WALK = 2,
        JUMP = 4,
        ATTACK = 6
    };
    private enum PLAYERDIR {
        RIGHT = 0,
        LEFT = 1
    }

    private Rigidbody2D rb2D;   // rigidbody
    private Transform transform;
    //private Vector2 _moveVal;    // 移動量
    private Vector2 moveVal;    // 移動量
    private const float moveSpeed = 0.1f;
    private const float gravity = 0.5f;
    private int playerState;    // プレイヤーの状態取得

    private Animator anim;  // アニメーション

    private bool isJump;    // ジャンプ中かどうか
    public static bool isAttack;  // 攻撃中かどうか

    private Vector3 scale;  // プレイヤー画像反転の為スケールをとる

    private GameObject weapon;


    // Start is called before the first frame update
    void Start() {
        rb2D = this.GetComponent<Rigidbody2D>();    // rigidbody取得
        transform = this.GetComponent<Transform>(); // Transform取得
        anim = GetComponent<Animator>();    // アニメーター取得

        isJump = false; // ジャンプフラグ初期化
        isAttack = false;   // 攻撃フラグ初期化
        playerState = (int)PLAYERSTATE.IDLE + (int)PLAYERDIR.RIGHT;  // 右向き待機                  
        scale = transform.localScale;// スケール値取り出し

        weapon = GameObject.Find("Weapon");

    }

    // Update is called once per frame
    void Update() {
        Keyboard keyboard = Keyboard.current;
        if (keyboard != null) {
            if (keyboard.aKey.isPressed) {
                OnMoveLeft();
            } else if (keyboard.dKey.isPressed) {
                OnMoveRight();
            } else {
                //if (!isJump) {
                //    StartCoroutine("DelayMoveStop");
                //}
                //_moveVal = Vector2.zero;
                //if (!isJump) {
                    moveVal = Vector2.zero;
                //}

            }

            if (keyboard.jKey.wasReleasedThisFrame) {
                OnAttack();
            }
            if (keyboard.spaceKey.wasReleasedThisFrame) {
                OnJump();
            }
        }

        Touchscreen touchscreen = Touchscreen.current;
        if (touchscreen != null) {
            foreach (var touch in touchscreen.touches) {
                if(touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.None) {
                    continue;
                }

                if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Moved) {
                    if (RectTransformUtility.RectangleContainsScreenPoint(buttonRt_R, touch.startPosition.ReadValue())) {
                        OnMoveRight();
                        //OnJump();
                    } else if (RectTransformUtility.RectangleContainsScreenPoint(buttonRt_L, touch.startPosition.ReadValue())) {
                        OnMoveLeft();
                        //OnJump();
                    }
                    if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began) {
                        if (RectTransformUtility.RectangleContainsScreenPoint(buttonRt_J, touch.startPosition.ReadValue())) {
                            OnJump();
                        }
                        if (RectTransformUtility.RectangleContainsScreenPoint(buttonRt_A, touch.startPosition.ReadValue())) {
                            OnAttack();
                        }
                    }
                //} else {
                //    if (!isJump) {
                //        moveVal = Vector2.zero;
                //    }
                }

                if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began) {
                    if (RectTransformUtility.RectangleContainsScreenPoint(buttonRt_J, touch.startPosition.ReadValue())) {
                        OnJump();
                    }
                    if (RectTransformUtility.RectangleContainsScreenPoint(buttonRt_A, touch.startPosition.ReadValue())) {
                        OnAttack();
                    }
                }
            }

        }

        //if (Input.touchCount > 0) {
        //    // タッチ情報の取得
        //    Touch touch = Input.GetTouch(0);

        //    if (touch.phase == UnityEngine.TouchPhase.Began) {
        //        //Debug.Log("押した瞬間");
        //    }
        //    if (touch.phase == UnityEngine.InputSystem.TouchPhase.Moved) {
        //        //Debug.Log("押しっぱなし");
        //    } 
        //}

        // 横移動をやめたらアイドル
        //if (_moveVal.x == 0.0f && playerState >= 2 && playerState <= 4) {
        if (moveVal.x == 0.0f && playerState >= 2 && playerState <= 4) {
            anim.SetBool("isMove", false);
            if (playerState % 2 == 1) {
                playerState = (int)PLAYERSTATE.IDLE + (int)PLAYERDIR.LEFT;
            } else if (playerState % 2 == 0) {
                playerState = (int)PLAYERSTATE.IDLE + (int)PLAYERDIR.RIGHT;
            }
            
            //StartCoroutine("DelayMoveStop");
        }


        // プレイヤーの向きによりアニメーション、向きを変化
        if (playerState%2 == 0) {
            // 右方向に移動中
            scale.x = -1.5f; // 左右反転
        } else if(playerState%2 == 1) {
            // 左方向に移動中
            scale.x = 1.5f; // 反転無し
        }

        //if (isJump) {
        //    if (rb2D.velocity.x > 2.5) {
        //        _moveVal.x = 0;
        //    }
        //    _moveVal.y -= 2.0f;
        //} else if (rb2D.velocity.x > 5.0f) {
        //    _moveVal.x = 0;
        //    //rb2D.AddForce(_moveVal);
        //}

        // 代入し直す
        transform.localScale = scale;

        // 移動量をもとに移動
        transform.position = new Vector3(transform.position.x + moveVal.x ,transform.position.y + moveVal.y ,transform.position.z);

        // 重力かける
        //transform.position = new Vector3(transform.position.x,transform.position.y-gravity,transform.position.z);
        

        // デバッグログ
        //Debug.Log(playerState);
        //Debug.Log(isJump);
        //Debug.Log(_moveVal);
        //Debug.Log("x:"+rb2D.velocity.x);
        //Debug.Log("y:"+rb2D.velocity.y);
        //Debug.Log("magnitude:"+rb2D.velocity.magnitude);
    }

    private void FixedUpdate() {
        //rb2D.AddForce(_moveVal);

        //if (isJump) {

        //} else
        //if (rb2D.velocity.x > 10.0f) {
        //    //rb2D.AddForce(_moveVal);
        //    _moveVal = Vector2.zero;
        //}
        //rb2D.velocity = new Vector2();
    }


    private void OnMoveLeft() {
        //_moveVal.x = -1.0f;  // 移動方向を指定
        //_moveVal.x *= moveSpeed; // 移動スピードを乗算

        moveVal.x = -1.0f;  // 移動方向を指定
        moveVal.x *= moveSpeed; // 移動スピードを乗算


        playerState = (int)PLAYERSTATE.WALK + (int)PLAYERDIR.LEFT;  // 画像のステータスを設定
        anim.SetBool("isMove", true); // アニメーションのフラグを立てる
    }

    private void OnMoveRight() {
        //_moveVal.x = 1.0f;// 移動方向を指定
        //_moveVal.x *= moveSpeed;// 移動スピードを乗算     

        moveVal.x = 1.0f;// 移動方向を指定
        moveVal.x *= moveSpeed;// 移動スピードを乗算

        playerState = (int)PLAYERSTATE.WALK + (int)PLAYERDIR.RIGHT; // 画像のステータスを設定
        anim.SetBool("isMove", true);   // アニメーションのフラグを立てる
    }

    public void OnJump() {
        if (!isJump) {
            Vector2 jumpVec;
            jumpVec.x = 0;
            jumpVec.y = 5;

            //moveVal.y = 1.0f;

            rb2D.AddForce(jumpVec, ForceMode2D.Impulse);
            isJump = true;
            anim.SetBool("isJump", true);
            SoundManager.Play(SoundData.eSE.SE_JUMP, SoundData.GameAudioList);
        }
    }

    private void OnAttack() {
        anim.SetTrigger("Attack");
        isAttack = true;
        StartCoroutine("DelayAttackOff");
    }

    private IEnumerator DelayAttackOff() {
        yield return new WaitForSeconds(0.25f);
        isAttack = false;
    }

    private IEnumerator DelayMoveStop() {
        yield return new WaitForSeconds(1.0f);
        //_moveVal = Vector2.zero;
        //rb2D.velocity = Vector2.zero;
    }


    private void OnCollisionStay2D(Collision2D collision) {
        if (isJump && collision.gameObject.tag == "Field") {
            anim.SetBool("isJump", false);
            isJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Warp") {
            int randomScene = Random.Range(1, 3);
            MySceneManager.nextScene = randomScene;
            MySceneManager.SceneChange();
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision) {
    //if (collision.tag == "DeadArea") {
    //    GameObject _gameObject = GameObject.FindWithTag("Respawn");
    //    this.transform.position = _gameObject.transform.position;
    //}
    // }
}
