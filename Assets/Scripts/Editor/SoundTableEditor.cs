using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DataManager))]
public class SoundTableEditor : Editor {
    int SEListSize => (int)SoundData.eSE.MAX_SE;//enum eSEの長さ
    int BGMListSize => (int)SoundData.eBGM.MAX_BGM;//enum eSEの長さ
    SerializedProperty SEtable;
    SerializedProperty BGMtable;

    
    private void OnEnable() {
        SEtable = serializedObject.FindProperty("SEdat");
        BGMtable = serializedObject.FindProperty("BGMdat");
        if (SEtable.arraySize != SEListSize || BGMtable.arraySize != BGMListSize) {
            serializedObject.Update();  // 更新

            SEtable.arraySize = SEListSize;
            BGMtable.arraySize = BGMListSize;

            serializedObject.ApplyModifiedProperties(); // 保存
        }
    }


    public override void OnInspectorGUI() {
        serializedObject.Update();  // 更新
        //----- スクリプトを表示 -----
        EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((MonoBehaviour)target), typeof(MonoScript), false);
        
        //----- SEのリストを表示 -----
        //リストの名前を記載
        EditorGUILayout.LabelField("SE");
        //表示
        for (int i = 0; i < (int)SoundData.eSE.MAX_SE; ++i) {
            EditorGUILayout.PropertyField(SEtable.GetArrayElementAtIndex(i), new GUIContent(Enum.GetName(typeof(SoundData.eSE), i)));
        }
        
        //----- BGMのリストを表示 -----
        //リストの名前を記載
        EditorGUILayout.LabelField("BGM");
        //表示
        for (int i = 0; i < (int)SoundData.eBGM.MAX_BGM; ++i) {
            EditorGUILayout.PropertyField(BGMtable.GetArrayElementAtIndex(i), new GUIContent(Enum.GetName(typeof(SoundData.eBGM), i)));
        }

        serializedObject.ApplyModifiedProperties(); // 保存
    }
}

//public class SoundTableEditor : EditorWindow {

//    [MenuItem("Window/My SoundEdit Window")]

//    public static void ShowWindow() {

//        GetWindow<SoundTableEditor>();

//    }

//    public GameObject[] AThings;

//    ScriptableObject table;
//    SerializedObject SO;
//    SerializedProperty SEProp;
//    int ListSize => (int)SoundData.eSE.MAX_SE;//enum eSEの長さ

//    private void OnEnable() {
//        table = new SoundData();
//        SO = new SerializedObject(table);

//        SEProp = SO.FindProperty("SE");

//        if (SEProp.arraySize != ListSize) {
//            SO.Update();  // 更新

//            SEProp.arraySize = ListSize;

//            SO.ApplyModifiedProperties(); // 保存
//        }

//    }



//    void OnGUI() {
//        SO.Update();

//        //リストの名前を記載
//        EditorGUILayout.LabelField("SE");

//        //表示
//        for (int i = 0; i < (int)SoundData.eSE.MAX_SE; ++i) {
//            //表示
//            EditorGUILayout.PropertyField(SEProp.GetArrayElementAtIndex(i), new GUIContent(Enum.GetName(typeof(SoundData.eSE), i)));
//        }



//        SO.ApplyModifiedProperties();

//    }

//}