using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{
    public TMP_InputField Username;
    public TMP_InputField Password;
    
    public void OnClickLogin(string sceneName) {
       if (Username.GetComponent<TMP_InputField>().text.Equals("hoanganh") && Password.GetComponent<TMP_InputField>().text.Equals("123456")) {
            Debug.Log("Load main menu");
            SceneManager.LoadScene(sceneName);
        }
        else {
            Debug.Log("Error Username or Password");
        }
    }
}
