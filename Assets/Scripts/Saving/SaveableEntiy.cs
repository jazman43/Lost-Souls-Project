using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



namespace LostSouls.Saving
{
    [ExecuteAlways]
    public class SaveableEntiy : MonoBehaviour
    {
        [SerializeField] private string uniqueIdentifier = "";
        static Dictionary<string, SaveableEntiy> gloabalLookUp = new Dictionary<string, SaveableEntiy>();


        public string GetUniqueIdenerifer()
        {
            return uniqueIdentifier;
        }

        public object CaptureState()
        {
            Dictionary<string, object> state = new Dictionary<string, object>();

            foreach(ISaveable saveable in GetComponents<ISaveable>())
            {
                state[saveable.GetType().ToString()] = saveable.CapturState();
            }

            return state;
        }


        public void RestoreState(object state)
        {
            Dictionary<string, object> stateRestore = (Dictionary<string, object>)state;

            foreach( ISaveable saveable in GetComponents<ISaveable>())
            {
                string typeString = saveable.GetType().ToString();

                if (stateRestore.ContainsKey(typeString))
                {
                    saveable.RestoreState(stateRestore[typeString]);
                }
            }
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (Application.IsPlaying(gameObject)) return;
           

            if (string.IsNullOrEmpty(gameObject.scene.path)) return;

            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty property = serializedObject.FindProperty("uniqueIdentifier");

            if(string.IsNullOrEmpty(property.stringValue) || !IsUnique(property.stringValue))
            {
                property.stringValue = System.Guid.NewGuid().ToString();
                serializedObject.ApplyModifiedProperties();
            }

            gloabalLookUp[property.stringValue] = this;
        }

        private bool IsUnique(string stringValue)
        {
            if (!gloabalLookUp.ContainsKey(stringValue)) return true;
            
            if (gloabalLookUp[stringValue] == this) return true;

            if(gloabalLookUp[stringValue] = null)
            {
                gloabalLookUp.Remove(stringValue);
                return true;
            }

            if (gloabalLookUp[stringValue].GetUniqueIdenerifer() != stringValue)
            {
                gloabalLookUp.Remove(stringValue);
                return true;
            }

            return false;
        }

#endif
    }

}