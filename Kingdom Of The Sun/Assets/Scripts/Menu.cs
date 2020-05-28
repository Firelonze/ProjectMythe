using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text text;

    public void StartGame()
    {
        SceneManager.LoadScene("Mythe");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void options()
    {
        StartCoroutine(OptionsText());
    }

    IEnumerator OptionsText()
    {
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        text.gameObject.SetActive(false);
    }
}
