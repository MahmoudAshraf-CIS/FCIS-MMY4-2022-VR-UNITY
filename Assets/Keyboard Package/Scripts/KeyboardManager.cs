using UnityEngine;
using TMPro;

public class KeyboardManager : MonoBehaviour
{
    public static KeyboardManager Instance;
    [SerializeField] TextMeshProUGUI textBox;
    [SerializeField] TextMeshProUGUI printBox;
    [SerializeField] GameObject keyboardGameObject;
    InputFieldKeyboard curentInputField;
    public void OnSelectInputField(InputFieldKeyboard inputField)
    {
        keyboardGameObject.SetActive(true);
        curentInputField = inputField;
    }


    public void OnDeselectInputField(InputFieldKeyboard inputField)
    {
        
       
    }

    private void Start()
    {
        Instance = this;
        printBox.text = "";
        textBox.text = "";
    }

    public void DeleteLetter()
    {
        if(textBox.text.Length != 0) {
            textBox.text = textBox.text.Remove(textBox.text.Length - 1, 1);
        }

        if (curentInputField)
        {
            if (curentInputField.text.Length != 0)
                curentInputField.text = curentInputField.text.Remove(curentInputField.text.Length - 1, 1);
        }
    }

    public void AddLetter(string letter)
    {
        textBox.text = textBox.text + letter;
        if (curentInputField)
            curentInputField.text = curentInputField.text + letter;
    }

    public void SubmitWord()
    {
        printBox.text = textBox.text;
        textBox.text = "";

         
        // Debug.Log("Text submitted successfully!");
    }


}
