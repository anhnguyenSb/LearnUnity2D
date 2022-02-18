using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
public class InventoryController : MonoBehaviour
{
    public RectTransform Viewport;
    public Transform Content;
    public Transform PageList;
    public PageListStruct PageLabel;
    public ListingStruct List;
    public List<Sprite> ImageList;
    public List<PageListStruct> labelPagelist;
    public Sprite PageHover;
    public Sprite PageOff;
    public int MainPage = 1;
    private void Start()
    {
        Debug.Log(Viewport.rect.width);

        for (int i = 0; i < 5; ++i)
        {
            var pageLalebl = Instantiate(PageLabel, PageList);
            pageLalebl.setLabel(i + 1);
            if (i == 0) pageLalebl.ChosenPage.sprite = PageHover;
            pageLalebl.OnClick = OnClickPage;
            labelPagelist.Add(pageLalebl);
        }

        for (int i = 0; i < 25; ++i)
        {
            List.Img1.sprite = ImageList[Random.Range(0, 5)];
            List.Img2.sprite = ImageList[Random.Range(0, 5)];
            Instantiate(List, Content);
        }
    }
    public void OnClickBackBtn(string sceneName)
    {
        Debug.Log("Clicked Back Button !!");
        SceneManager.LoadScene(sceneName);
    }

    public void OnClickPage(int page)
    {
        Content.DOLocalMoveX(-(page - 1) * Viewport.rect.width, 0.3f);
        labelPagelist[MainPage - 1].ChosenPage.sprite = PageOff;
        labelPagelist[page - 1].ChosenPage.sprite = PageHover;
        this.MainPage = page;
    }
}
