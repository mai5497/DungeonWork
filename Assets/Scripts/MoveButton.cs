using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{
	//インスペクターから、対象のボタンを紐付けしておく。
	[SerializeField]
	RectTransform buttonRt;

    //インスペクターから、対象のボタンの親キャンバスを紐付けしておく。
    //プレイヤーが移動不可能な時はenabledを無効化しておく(メニュー画面を開いた時等)。
    [SerializeField]
    Canvas buttonCanvas;


    void Update() {


		//ボタンの親キャンバスが無効化されている場合は、タッチ判定しないように弾く。
		//(GameObject.activeSelfで判定すると、親オブジェクトを非アクティブ化した場合に望んだ動作をしない為、こちらに変更)
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


	//押下した瞬間。
	void OnDown() {
		Debug.Log("OnDown");
	}

	//押している最中(ポインターが、ボタンの上の状態)。
	//ここでプレイヤーの移動用メソッドを呼ぶ。
	void OnPressed() {
		Debug.Log("OnPressed");
		
		gameObject.GetComponent<Player>().OnJump();
	}

	//押上した瞬間(ポインターが、ボタンの上で放した場合のみ)。
	void OnRelease() {
		Debug.Log("OnRelease");
	}
}
