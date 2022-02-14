using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text;

public class WindowNameInput : MonoBehaviour
{
    public TMP_InputField inputFieldName;
    public Button BtnOK;
    public Button BtnCancel;
    public string InputName;

    void Start()
    {
        BtnOK.interactable = false;
        BtnOK.onClick.AddListener(() =>
        {
            if (TitleData.Instance.GameInfo.HasKey("PlayerName") == false)
            {
                TitleData.Instance.GameInfo.Add("PlayerName", InputName);
            }
            else
            {
                TitleData.Instance.GameInfo.SetValue("PlayerName", InputName);
            }
            TitleData.Instance.GameInfo.Save();
            SceneManager.LoadScene("Home");
        });

        BtnCancel.onClick.AddListener(() =>
        {
            inputFieldName.text = "";
        });

        inputFieldName.onValueChanged.AddListener(InputValueChange);
    }
    public void InputValueChange(string value)
    {
        int count = Encoding.GetEncoding("Shift_JIS").GetByteCount(value);
        InputName = value;
        BtnOK.interactable = 0 < count && 10 >= count;
        Debug.Log(count);
    }
}
