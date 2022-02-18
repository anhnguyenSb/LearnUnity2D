using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
public class PageListStruct : MonoBehaviour
{
    public TextMeshProUGUI Label;
    public Image ChosenPage;
    public Action<int> OnClick;
    public int PageNumber;

    public void setLabel(int PageNumber)
    {
        Label.text = PageNumber.ToString();
        this.PageNumber = PageNumber;
    }

    public void OnClicked()
    {
        OnClick?.Invoke(PageNumber);
    }
}
