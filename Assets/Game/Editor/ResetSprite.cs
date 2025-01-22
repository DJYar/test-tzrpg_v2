using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game.Editor
{
    public class ResetSprite : EditorWindow
    {
        private static readonly Dictionary<string, int> _fixup = new()
        {
            ["shadow"] = -1,
            ["foot"] = 0,
            ["body"] = 1,
            ["hand l"] = 1,
            ["hand r"] = 3,
            ["head"] = 4,
            ["eye"] = 5,
            ["mouth"] = 5,
            ["hat"] = 7,
            ["acc"] = 7
        };

        private GameObject rootObject;

        private void OnGUI()
        {
            GUILayout.Label("Set Sprite Order In Layer", EditorStyles.boldLabel);

            rootObject =
                (GameObject)EditorGUILayout.ObjectField("Root GameObject", rootObject, typeof(GameObject), true);

            if (GUILayout.Button("Set Order"))
            {
                if (rootObject != null)
                    SetOrderInLayer(rootObject);
                else
                    Debug.LogError("Please assign a root GameObject.");
            }
        }

        [MenuItem("Tools/Set Sprite Order In Layer")]
        public static void ShowWindow()
        {
            GetWindow<ResetSprite>("Set Sprite Order In Layer");
        }

        private void SetOrderInLayer(GameObject root)
        {
            var children = root.GetComponentsInChildren<SpriteRenderer>();

            foreach (var child in children)
            {
                child.sortingOrder = 2;
                child.sortingLayerName = "Default";

                foreach (var (key, value) in _fixup)
                    if (child.gameObject.name.Contains(key, StringComparison.InvariantCultureIgnoreCase))
                        child.sortingOrder = value;
            }
        }
    }
}