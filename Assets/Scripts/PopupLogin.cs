using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupLogin : MonoBehaviour
{
    public TMP_InputField IDInput;
    public TMP_InputField PSInput;

    public GameObject signUpPopup;
    public GameObject loginPopup;
    public GameObject loginError;

    public void OnLogin()
    {
        Debug.Log("OnLogin ȣ���");
        string savedID = PlayerPrefs.GetString("ID", "");       // ����� ����   ""�� �Է°� �ʱ�ȭ
        string savedPS = PlayerPrefs.GetString("PassWord", "");
        Debug.Log($"����� ID: {savedID}, PW: {savedPS}");

        string inputID = IDInput.text;
        string inputPS = PSInput.text;      // �Է°�

        if (inputID == savedID && inputPS == savedPS && inputID != "")
        {
            loginPopup.SetActive(false);
        }
        else
        {
            loginError.SetActive(true);
        }
    }
    public void SignUpShow()
    {
        signUpPopup.SetActive(true);
    }

    public void ErrorHide()
    {
        loginError.SetActive(false);
    }
}
