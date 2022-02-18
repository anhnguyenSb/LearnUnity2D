using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public List<Transform> Bots;
    public bool IsMoving = false;
    public int MainCar = 0, RightCar = 1,  LeftCar = 2;
    private void Update() {
        if (IsMoving){
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            MovingLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            MovingRight();
        }
    }
    public void MoveBot(Transform Bot, Vector3 position, Action action = null) {
        Bot.DOMove(position, 0.3f).OnComplete(() => {
            action?.Invoke();
        });
    }
    public void SortCanvas(int a, int b){
        Bots[MainCar].GetComponent<Canvas>().sortingOrder = 2;
        Bots[a].GetComponent<Canvas>().sortingOrder = 2;
        Bots[b].GetComponent<Canvas>().sortingOrder = 1;
    }
    public void Moving(int b, int c) {
        Vector3 temp = Bots[0].position;
        MoveBot(Bots[0], Bots[b].position, () => IsMoving = false);
        MoveBot(Bots[b], Bots[c].position);
        MoveBot(Bots[c], temp);
    }
    public void ScaleBot(int car) {
        Bots[MainCar].localScale/=1.75f;
        Bots[car].localScale*=1.75f;
    }
    public void IndexedBot(ref int a, ref int b){
        int temp = MainCar;
        MainCar = a;
        a = b;
        b = temp;
    }
    public void MovingLeft() {
        SortCanvas(RightCar, LeftCar);
        Moving(2,1);
        IsMoving = true;
        ScaleBot(RightCar);
        IndexedBot(ref RightCar, ref LeftCar);
    }
    public void MovingRight() {
        SortCanvas(LeftCar, RightCar);
        Moving(1,2);
        IsMoving = true;
        ScaleBot(LeftCar);
        IndexedBot(ref LeftCar, ref RightCar);
    }
    public void OnClickCar(int car) {
        if (car == MainCar) return;
        if (car == RightCar) {
            MovingLeft();   
        }
        if (car == LeftCar) {
            MovingRight();
        }
    }

    public void OnClickInvBtn(string sceneName) {
        Debug.Log("Inventory Clicked !");
        SceneManager.LoadScene(sceneName);
    }
}
