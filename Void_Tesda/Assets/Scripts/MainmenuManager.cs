using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainmenuManager : MonoBehaviour {
    private GameObject [] menus;
    private GameObject back;
    private GameObject [] score;

    private float currentscore;
    public Text bestscore;
    // Use this for initialization
    void Start () {
        menus = GameObject.FindGameObjectsWithTag ("Menu");
        back = GameObject.Find ("Back");
        score = GameObject.FindGameObjectsWithTag ("Highscore");
        bestscore = GameObject.Find("Score").GetComponent<Text> ();
        foreach (GameObject h in score) {
            h.SetActive (false);
        }
        back.SetActive (false);
    }
	
    public void Play () {
        SceneManager.LoadScene (1);
    }
    public void GoToHighscore () {

        foreach (GameObject m in menus) {
            m.SetActive (false);
        }
        
        back.SetActive (true);
        foreach (GameObject h in score) {
            h.SetActive (true);
        }
        currentscore = (int)PlayerPrefs.GetFloat ("Highscore");
        bestscore.text =  currentscore.ToString();

    }
    public void Back () {
        foreach (GameObject m in menus) {
            m.SetActive (true);
        }
        foreach (GameObject h in score) {
            h.SetActive (false);
        }
        back.SetActive (false);
    }
}
