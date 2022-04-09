using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEditor;
using UnityEditor.UI;

public class InputFieldKeyboard : InputField
{
    public UnityEvent _OnSelected, _OnDeselect;

    public override void OnSelect(BaseEventData eventData)
    {
        Debug.Log("Overrides InputField.OnSelect", this.gameObject);
        text = "";

        base.OnSelect(eventData);
        ActivateInputField();

        if (_OnSelected!= null)
            _OnSelected.Invoke();

        KeyboardManager.Instance.OnSelectInputField(this);
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("Overrides InputField.Deselect", this.gameObject);
        
        DeactivateInputField();
        base.OnDeselect(eventData);

        if (_OnDeselect != null)
            _OnDeselect.Invoke();

        KeyboardManager.Instance.OnDeselectInputField(this);

    }


#if UNITY_EDITOR
    [CustomEditor(typeof(InputFieldKeyboard))]
    class InputFieldKeyboardEditor : InputFieldEditor
    {
        SerializedProperty m_OnSelected;
        SerializedProperty m_OnDeselect;
        protected override void OnEnable()
        {
            base.OnEnable();
            m_OnSelected = serializedObject.FindProperty("_OnSelected");
            m_OnDeselect = serializedObject.FindProperty("_OnDeselect");

        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.PropertyField(m_OnSelected);
            EditorGUILayout.PropertyField(m_OnSelected);

        }
    }
#endif
}
