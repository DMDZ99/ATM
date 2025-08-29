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
        if (GameManager.Instance == null || GameManager.Instance.userData == null)  // �̱��� �ƴϰų� ���������Ϳ��� �ȵ������� ����
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
            Debug.Log("�Ա� ����! Errorâ ���");
            Error();
        }
    }

    public void DepositInput()
    {
        if(depositInput == null)
            return;

        int amount;
        if (int.TryParse(depositInput.text, out amount))    // �Է¹��� ���ڿ� -> ���ڷ�
        {
            Deposit(amount);
            depositInput.text = ""; // ��ǲ�ʵ� �ʱ�ȭ
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
        // string �������� ��������
        if (targetName != "") // ���� �ƴϴٷ� �ϸ� �� ���ڿ��� �����
        {
            // �� �۱ݴ�����׷� ���� ����

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
                targetBalance += amount; // �ٸ����� ��������

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
        Debug.Log("����");

        if (errorPopup != null)
        {
            errorPopup.SetActive(false);
            errorPopup.SetActive(true);
            Debug.Log("��������");
        }
    }

    public void CloseError()
    {
        if (errorPopup != null)
            errorPopup.SetActive(false);
    }
}
