using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    private float time = 0f;
    [SerializeField] private GameObject BackToMainMenu;
    [SerializeField] private Text counter;
    [SerializeField] private Text bestTime;
    public static float best;
    static bool isFirst = true;
    void Start()
    {
        best = PlayerPrefs.GetFloat("BestTime");

        PlayerPrefs.SetInt("isFirstGame", isFirst ? 1 : 0);
        isFirst = (PlayerPrefs.GetInt("isFirstGame") != 0);
        
        if(!isFirst){
            bestTime.text = "Best Time: " + formatToTimeString(best);
        }
    }
    // Update is called once per frame
    
    void Update()
    {
        time += Time.deltaTime;
        float seconds = (time%60);
        float minutes = (Mathf.FloorToInt(time/60));
        counter.text = "Time: " + string.Format("{0:00}:{1:00}", + minutes, seconds);
    }
    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    string formatToTimeString(float numberInSeconds) {
         float hours = Mathf.FloorToInt(numberInSeconds/3600);
         float minutes = Mathf.FloorToInt(numberInSeconds/60);
         float secondsLeftDig = Mathf.FloorToInt(((numberInSeconds-hours*3600-minutes*60)/10)%6);
         float secondsRightDig = Mathf.FloorToInt(numberInSeconds%10);
        return (hours +""+ minutes + ":" + secondsLeftDig + secondsRightDig);
    }
    public void GameOver(bool didReachFinish)
    {
        PlayerPrefs.SetFloat("CurrentGameTime", time);
        if(!didReachFinish) {
            if(!isFirst){
                bestTime.text = "Best Time: " + formatToTimeString(best);
                PlayerPrefs.SetFloat("BestTime", best);
            } 
        } else {
            if(isFirst) {
                PlayerPrefs.SetFloat("BestTime", 999);
                isFirst = false;
            }
            if( time < PlayerPrefs.GetFloat("BestTime"))
            {
                bestTime.text = "Best Time: " + formatToTimeString(time);
                PlayerPrefs.SetFloat("BestTime", time);
            } else {
                bestTime.text = "Best Time: " + formatToTimeString(best);
            }
        }
    }

    
}
