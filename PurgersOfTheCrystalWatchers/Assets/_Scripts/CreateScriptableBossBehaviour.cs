using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace POTCW
{
    public class CreateScriptableBossBehaviour
    {
        [MenuItem("Assets/Create/Bosses/ScriptableBossBehaviour")]
        public static void CreateMyAsset()
        {
            ScriptableBossBehaviour asset = ScriptableObject.CreateInstance<ScriptableBossBehaviour>();

            AssetDatabase.CreateAsset(asset, "Assets/ScriptableBossBehaviours/NewScriptableBossBehaviour.asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}