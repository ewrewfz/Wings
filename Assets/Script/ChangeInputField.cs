using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeInputField : MonoBehaviour
{
    [SerializeField] private InputField[] inputfields;
    [SerializeField] private OVRVirtualKeyboardInputFieldTextHandler handler;
    public void ChangeField(int _int)
    {
        print("waef");
        handler.InputField = inputfields[_int];
    }
}
