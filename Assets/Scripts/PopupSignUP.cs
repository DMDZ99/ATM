using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupSignUP : MonoBehaviour
{
    public TMP_InputField IDInput;
    public TMP_InputField NameInput;
    public TMP_InputField PSInput;
    public TMP_InputField PSConfirmInput;

    public GameObject signUpError;
    public GameObject signUpPopup;

    public void OnSignUp()
    {
        if ((IDInput.text.Length == 0 || NameInput.text.Length == 0 || PSInput.text.Length == 0 || PSConfirmInput.text.Length == 0)
            || PSInput.text != PSConfirmInput.text)
        {
            ShowError();
            return;
        }

        PlayerPrefs.SetString("ID", IDInput.text);
        PlayerPrefs.SetString("Name", NameInput.text);
        PlayerPrefs.SetString("PassWord", PSInput.text);
        //PlayerPrefs.SetString("PSConfirm", PSConfirmInput.text);  // 재확인은 저장할 필요가없지않나
        PlayerPrefs.Save();

        signUpPopup.SetActive(false);
    }

    public void CloseSignUP()
    {
        signUpPopup.SetActive(false);
    }

    public void ShowError()
    {
        signUpError.SetActive(true);
    }

    public void HideError()
    {
        signUpError.SetActive(false);
    }
}
