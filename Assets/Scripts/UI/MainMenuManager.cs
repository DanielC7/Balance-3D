using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject AreYouSurePopup;
    [SerializeField] private GameObject HowToPlayPopup;

    public void SureExit() {
        Application.Quit();
    }

    public void ActiveDisactiveAreYouSure(bool i_active) {
        AreYouSurePopup.SetActive(i_active);
    }

    public void ActiveDisactiveHowToPlay(bool i_active) {
        HowToPlayPopup.SetActive(i_active);
    }
    
    public void GoToGameScene() {
        SceneManager.LoadScene("GameScene");
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
