using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    private Text levelText;

    private EXPBar _EXPBar; // 現在のシーンに存在するEXPBarというスクリプトを取得
                            // プレイヤーの現在のレベルを持っているため

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
