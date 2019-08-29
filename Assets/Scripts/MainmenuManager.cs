using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainmenuManager : MonoBehaviour {
    public GameObject [] menus;
    public GameObject [] score;
    public GameObject back;

    private float currentscore;
    public Text bestscore;
    // Use this for initialization
    void Start () {

        bestscore.GetComponent<Text>();
        ToggleScore(false); //To make sure the highscore menu is disable
        
    }
	
    public void Play () {
        SceneManager.LoadScene (1);
    }
    public void Highscore () {

        ToggleMenu(false);
        ToggleScore(true);

        //Score Updater!
        currentscore = (int)PlayerPrefs.GetFloat ("Highscore");
        bestscore.text =  currentscore.ToString();

    }
    public void Back () {
        ToggleMenu(true);
        ToggleScore(false);

    }
    public void ToggleMenu(bool value)
    {
        foreach (GameObject m in menus)
        {
            m.SetActive(value);
        }
    }
    public void ToggleScore(bool value)
    {
        foreach (GameObject h in score)
        {
            h.SetActive(value);
        }
        back.SetActive(value);
    }
}
