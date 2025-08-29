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
        Debug.Log("OnLogin 호출됨");
        string savedID = PlayerPrefs.GetString("ID", "");       // 저장된 정보   ""는 입력값 초기화
        string savedPS = PlayerPrefs.GetString("PassWord", "");
        Debug.Log($"저장된 ID: {savedID}, PW: {savedPS}");

        string inputID = IDInput.text;
        string inputPS = PSInput.text;      // 입력값

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
