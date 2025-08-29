using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupBank : MonoBehaviour
{
    public Text cashText;
    public Text balanceText;
    public Text nameText;

    public GameObject depositPanel;
    public GameObject withdrawPanel;
    public GameObject errorPopup;
    public GameObject remittancePanel;

    public TMP_InputField depositInput;
    public TMP_InputField withdrawInput;
    public TMP_InputField remittanceInput;
    public TMP_InputField remittanceTargetInput;

    private string targetName;
    private int targetBalance;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (GameManager.Instance == null || GameManager.Instance.userData == null)  // 싱글톤 아니거나 유저데이터연결 안되있으면 종료
            return;

        var data = GameManager.Instance.userData;
        nameText.text = data.userName;
        cashText.text = string.Format("{0:N0}", data.cash);
        balanceText.text = string.Format("{0:N0}", data.balance);
    }

    public void Deposit(int amount)
    {
        if (GameManager.Instance == null || GameManager.Instance.userData == null)
            return;

        var data = GameManager.Instance.userData;

        if (amount > 0 && amount <= data.cash)
        {
            data.cash -= amount;
            data.balance += amount;
            Refresh();

            GameManager.Instance.SaveUserData();
        }
        else
        {
            Debug.Log("입금 실패! Error창 띄움");
            Error();
        }
    }

    public void DepositInput()
    {
        if(depositInput == null)
            return;

        int amount;
        if (int.TryParse(depositInput.text, out amount))    // 입력받은 문자열 -> 숫자로
        {
            Deposit(amount);
            depositInput.text = ""; // 인풋필드 초기화
        }
    }

    public void Withdraw(int amount)
    {
        if (GameManager.Instance == null || GameManager.Instance.userData == null)
            return;

        var data = GameManager.Instance.userData;

        if (amount > 0 && amount <= data.balance)
        {
            data.balance -= amount;
            data.cash += amount;
            Refresh();

            GameManager.Instance.SaveUserData();
        }
        else
        {
            Error();
        }
    }

    public void WithdrawInput()
    {
        if (withdrawInput == null)
            return;

        int amount;
        if (int.TryParse(withdrawInput.text, out amount))
        {
            Withdraw(amount);
            withdrawInput.text = "";
        }
    }

    public void RemittanceTarget()
    {
        if (remittanceTargetInput == null)
            return;

        targetName = remittanceTargetInput.text;
        // string 네임으로 들어왓으면
        if (targetName != "") // 널이 아니다로 하면 빈 문자열이 통과됨
        {
            // 그 송금대상한테로 가게 저장

        }
        else
        {
            Error();
        }
    }

    public void RemittanceInput()
    {
        if (remittanceInput == null)
            return;

        int amount;
        if (int.TryParse(remittanceInput.text, out amount))
        {
            var myData = GameManager.Instance.userData;

            if (amount > 0 && amount <= myData.balance)
            {
                myData.balance -= amount;
                targetBalance += amount; // 다른유저 돈들어오게

                Refresh();
                GameManager.Instance.SaveUserData();
            }
            else
            {
                Error();
            }
        }
    }

    public void ShowDeposit()
    {
        depositPanel.SetActive(true);
    }

    public void HideDeposit()
    {
        depositPanel.SetActive(false);
    }

    public void ShowWithdraw()
    {
        withdrawPanel.SetActive(true);
    }

    public void HideWithdraw()
    {
        withdrawPanel.SetActive(false);
    }

    public void ShowRemittance()
    {
        remittancePanel.SetActive(true);
    }

    public void HideRemittance()
    {
        remittancePanel.SetActive(false);
    }

    public void Error()
    {
        Debug.Log("에러");

        if (errorPopup != null)
        {
            errorPopup.SetActive(false);
            errorPopup.SetActive(true);
            Debug.Log("에러났음");
        }
    }

    public void CloseError()
    {
        if (errorPopup != null)
            errorPopup.SetActive(false);
    }
}
