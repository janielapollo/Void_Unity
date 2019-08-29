using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {


   
    private GameObject player;

    private GameObject gameMenu;

    private Text gameScoreTxt;
    private Text gameHighTxt;
    private Text score;


    private float playerscore;
    private float currentscore;
    private float timer;

    private int Highscore;

    private bool alive;
    
    private PlaySound sound;
    void Awake () {
        score = GameObject.Find ("Score-Text").GetComponent<Text> ();
        player = GameObject.FindGameObjectWithTag ("Player");
        sound = GameObject.Find ("SoundManager").GetComponent<PlaySound> ();
        gameScoreTxt = GameObject.Find ("Game-Score").GetComponent<Text> ();
        gameHighTxt = GameObject.Find ("Game-High").GetComponent<Text> ();
        Highscore = Mathf.RoundToInt (PlayerPrefs.GetFloat ("Highscore"));
        gameMenu = GameObject.Find ("Game-Panel");
    }
	void Start () {
        score.text = "Score:" + currentscore;
        gameMenu.SetActive (false);
        alive = true; // The player is alive
        timer = 2F;
    }
	
	// Update is called once per frame
	void Update () {
        playerscore = player.transform.position.y + 3;
        if (alive && playerscore >= 0) {
            currentscore = Mathf.RoundToInt (playerscore);
            score.text = "Score:" + currentscore;
            if (playerscore > Highscore) {
                Highscore = (int) currentscore;
            }

        }else if(!alive){
            timer -= Time.deltaTime;
            if (timer <= 0) {
                GameMenu ();
            }
            
        }
        //If player beat the high and is alive = false;
        if (playerscore >= Highscore && !alive) {
            SaveHighscore ();
        }


    }
    public void isDead (bool val) {
        alive = val;
    }
    public void ResetLevel () {
        sound.PlayTap ();
        PlayerPrefs.Save (); 
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
    }
    public void BackToMain () {
        sound.PlayTap ();
        PlayerPrefs.Save (); 
        SceneManager.LoadScene (0);
    }
    private void GameMenu () {
        gameMenu.SetActive (true);
        gameScoreTxt.text = "" + currentscore;
        gameHighTxt.text = "" + Mathf.RoundToInt (PlayerPrefs.GetFloat ("Highscore"));
        score.gameObject.SetActive (false);
    }
    private void SaveHighscore () {
        PlayerPrefs.SetFloat ("Highscore", Highscore);
    }
    

}
