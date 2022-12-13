using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DataManager))]
public class SoundTableEditor : Editor {
    int SEListSize => (int)SoundData.eSE.MAX_SE;//enum eSE�̒���
    int BGMListSize => (int)SoundData.eBGM.MAX_BGM;//enum eSE�̒���
    SerializedProperty SEtable;
    SerializedProperty BGMtable;

    
    private void OnEnable() {
        SEtable = serializedObject.FindProperty("SEdat");
        BGMtable = serializedObject.FindProperty("BGMdat");
        if (SEtable.arraySize != SEListSize || BGMtable.arraySize != BGMListSize) {
            serializedObject.Update();  // �X�V

            SEtable.arraySize = SEListSize;
            BGMtable.arraySize = BGMListSize;

            serializedObject.ApplyModifiedProperties(); // �ۑ�
        }
    }


    public override void OnInspectorGUI() {
        serializedObject.Update();  // �X�V
        //----- �X�N���v�g��\�� -----
        EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((MonoBehaviour)target), typeof(MonoScript), false);
        
        //----- SE�̃��X�g��\�� -----
        //���X�g�̖��O���L��
        EditorGUILayout.LabelField("SE");
        //�\��
        for (int i = 0; i < (int)SoundData.eSE.MAX_SE; ++i) {
            EditorGUILayout.PropertyField(SEtable.GetArrayElementAtIndex(i), new GUIContent(Enum.GetName(typeof(SoundData.eSE), i)));
        }
        
        //----- BGM�̃��X�g��\�� -----
        //���X�g�̖��O���L��
        EditorGUILayout.LabelField("BGM");
        //�\��
        for (int i = 0; i < (int)SoundData.eBGM.MAX_BGM; ++i) {
            EditorGUILayout.PropertyField(BGMtable.GetArrayElementAtIndex(i), new GUIContent(Enum.GetName(typeof(SoundData.eBGM), i)));
        }

        serializedObject.ApplyModifiedProperties(); // �ۑ�
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
//    int ListSize => (int)SoundData.eSE.MAX_SE;//enum eSE�̒���

//    private void OnEnable() {
//        table = new SoundData();
//        SO = new SerializedObject(table);

//        SEProp = SO.FindProperty("SE");

//        if (SEProp.arraySize != ListSize) {
//            SO.Update();  // �X�V

//            SEProp.arraySize = ListSize;

//            SO.ApplyModifiedProperties(); // �ۑ�
//        }

//    }



//    void OnGUI() {
//        SO.Update();

//        //���X�g�̖��O���L��
//        EditorGUILayout.LabelField("SE");

//        //�\��
//        for (int i = 0; i < (int)SoundData.eSE.MAX_SE; ++i) {
//            //�\��
//            EditorGUILayout.PropertyField(SEProp.GetArrayElementAtIndex(i), new GUIContent(Enum.GetName(typeof(SoundData.eSE), i)));
//        }



//        SO.ApplyModifiedProperties();

//    }

//}