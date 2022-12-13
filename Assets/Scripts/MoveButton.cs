using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{
	//�C���X�y�N�^�[����A�Ώۂ̃{�^����R�t�����Ă����B
	[SerializeField]
	RectTransform buttonRt;

    //�C���X�y�N�^�[����A�Ώۂ̃{�^���̐e�L�����o�X��R�t�����Ă����B
    //�v���C���[���ړ��s�\�Ȏ���enabled�𖳌������Ă���(���j���[��ʂ��J��������)�B
    [SerializeField]
    Canvas buttonCanvas;


    void Update() {


		//�{�^���̐e�L�����o�X������������Ă���ꍇ�́A�^�b�`���肵�Ȃ��悤�ɒe���B
		//(GameObject.activeSelf�Ŕ��肷��ƁA�e�I�u�W�F�N�g���A�N�e�B�u�������ꍇ�ɖ]�񂾓�������Ȃ��ׁA������ɕύX)
		//if (!buttonCanvas.enabled)
		//	return;

		Touchscreen touchscreen = Touchscreen.current;
		if (touchscreen != null) {

			if (touchscreen.touches[0].phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began) {
				if (RectTransformUtility.RectangleContainsScreenPoint(buttonRt, touchscreen.touches[0].startPosition.ReadValue())) {
					OnDown();
				}
			} else if (touchscreen.touches[0].phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began) {
				if (RectTransformUtility.RectangleContainsScreenPoint(buttonRt, touchscreen.touches[0].startPosition.ReadValue())) {
					OnPressed();
				}
			} else if (touchscreen.touches[0].phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Ended) {
				if (RectTransformUtility.RectangleContainsScreenPoint(buttonRt, touchscreen.touches[0].startPosition.ReadValue())) {
					OnRelease();
				}
			}
		}
	}


	//���������u�ԁB
	void OnDown() {
		Debug.Log("OnDown");
	}

	//�����Ă���Œ�(�|�C���^�[���A�{�^���̏�̏��)�B
	//�����Ńv���C���[�̈ړ��p���\�b�h���ĂԁB
	void OnPressed() {
		Debug.Log("OnPressed");
		
		gameObject.GetComponent<Player>().OnJump();
	}

	//���サ���u��(�|�C���^�[���A�{�^���̏�ŕ������ꍇ�̂�)�B
	void OnRelease() {
		Debug.Log("OnRelease");
	}
}
