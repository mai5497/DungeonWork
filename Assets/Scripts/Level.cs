using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    private Text levelText;

    private EXPBar _EXPBar; // ���݂̃V�[���ɑ��݂���EXPBar�Ƃ����X�N���v�g���擾
                            // �v���C���[�̌��݂̃��x���������Ă��邽��

    // Start is called before the first frame update
    void Start() {
        levelText = GetComponent<Text>();

        _EXPBar = GameObject.Find("Player").GetComponent<EXPBar>();
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = _EXPBar.GetCurrentLevel().ToString("D5");
    }
}
