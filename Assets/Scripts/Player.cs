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
    //private Vector2 _moveVal;    // �ړ���
    private Vector2 moveVal;    // �ړ���
    private const float moveSpeed = 0.1f;
    private const float gravity = 0.5f;
    private int playerState;    // �v���C���[�̏�Ԏ擾

    private Animator anim;  // �A�j���[�V����

    private bool isJump;    // �W�����v�����ǂ���
    public static bool isAttack;  // �U�������ǂ���

    private Vector3 scale;  // �v���C���[�摜���]�̈׃X�P�[�����Ƃ�

    private GameObject weapon;


    // Start is called before the first frame update
    void Start() {
        rb2D = this.GetComponent<Rigidbody2D>();    // rigidbody�擾
        transform = this.GetComponent<Transform>(); // Transform�擾
        anim = GetComponent<Animator>();    // �A�j���[�^�[�擾

        isJump = false; // �W�����v�t���O������
        isAttack = false;   // �U���t���O������
        playerState = (int)PLAYERSTATE.IDLE + (int)PLAYERDIR.RIGHT;  // �E�����ҋ@                  
        scale = transform.localScale;// �X�P�[���l���o��

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
        //    // �^�b�`���̎擾
        //    Touch touch = Input.GetTouch(0);

        //    if (touch.phase == UnityEngine.TouchPhase.Began) {
        //        //Debug.Log("�������u��");
        //    }
        //    if (touch.phase == UnityEngine.InputSystem.TouchPhase.Moved) {
        //        //Debug.Log("�������ςȂ�");
        //    } 
        //}

        // ���ړ�����߂���A�C�h��
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


        // �v���C���[�̌����ɂ��A�j���[�V�����A������ω�
        if (playerState%2 == 0) {
            // �E�����Ɉړ���
            scale.x = -1.5f; // ���E���]
        } else if(playerState%2 == 1) {
            // �������Ɉړ���
            scale.x = 1.5f; // ���]����
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

        // ���������
        transform.localScale = scale;

        // �ړ��ʂ����ƂɈړ�
        transform.position = new Vector3(transform.position.x + moveVal.x ,transform.position.y + moveVal.y ,transform.position.z);

        // �d�͂�����
        //transform.position = new Vector3(transform.position.x,transform.position.y-gravity,transform.position.z);
        

        // �f�o�b�O���O
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
        //_moveVal.x = -1.0f;  // �ړ��������w��
        //_moveVal.x *= moveSpeed; // �ړ��X�s�[�h����Z

        moveVal.x = -1.0f;  // �ړ��������w��
        moveVal.x *= moveSpeed; // �ړ��X�s�[�h����Z


        playerState = (int)PLAYERSTATE.WALK + (int)PLAYERDIR.LEFT;  // �摜�̃X�e�[�^�X��ݒ�
        anim.SetBool("isMove", true); // �A�j���[�V�����̃t���O�𗧂Ă�
    }

    private void OnMoveRight() {
        //_moveVal.x = 1.0f;// �ړ��������w��
        //_moveVal.x *= moveSpeed;// �ړ��X�s�[�h����Z     

        moveVal.x = 1.0f;// �ړ��������w��
        moveVal.x *= moveSpeed;// �ړ��X�s�[�h����Z

        playerState = (int)PLAYERSTATE.WALK + (int)PLAYERDIR.RIGHT; // �摜�̃X�e�[�^�X��ݒ�
        anim.SetBool("isMove", true);   // �A�j���[�V�����̃t���O�𗧂Ă�
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
