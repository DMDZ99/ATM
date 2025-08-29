using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UserData userData;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);

        LoadUserData();
    }

    public void SaveUserData()
    {
        if (userData == null)
            return;

        PlayerPrefs.SetString("UserName", userData.userName);
        PlayerPrefs.SetInt("Cash", userData.cash);
        PlayerPrefs.SetInt("Balance", userData.balance);
        PlayerPrefs.Save();
    }

    public void LoadUserData()
    {
        if (PlayerPrefs.HasKey("UserName"))
        {
            userData.userName = PlayerPrefs.GetString("UserName");
            userData.cash = PlayerPrefs.GetInt("Cash");
            userData.balance = PlayerPrefs.GetInt("Balance");
        }
    }
}
