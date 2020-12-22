using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class EndMenuManager : MonoBehaviour
{
    [SerializeField] private Text title;

    void Start() {
        string finishTimeStr = formatToTimeString(PlayerPrefs.GetFloat("CurrentGameTime"));
        title.text = "Nice! Finish time: " + finishTimeStr;
    }

    string formatToTimeString(float numberInSeconds) {
         float hours = Mathf.FloorToInt(numberInSeconds/3600);
         float minutes = Mathf.FloorToInt(numberInSeconds/60);
         float secondsLeftDig = Mathf.FloorToInt(((numberInSeconds-hours*3600-minutes*60)/10)%6);
         float secondsRightDig = Mathf.FloorToInt(numberInSeconds%10);
        return (hours +""+ minutes + ":" + secondsLeftDig + secondsRightDig);
    }

    public void GoToGameScene() {
        SceneManager.LoadScene("GameScene");
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
