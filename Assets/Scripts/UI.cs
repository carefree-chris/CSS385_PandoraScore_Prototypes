using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

    int health;
    int key;
    public GameObject heart_1;
    public GameObject heart_2;
    public GameObject heart_3;
    public GameObject key_1;
    public GameObject key_2;
    public GameObject key_3;
    public GameObject key_4;
    public GameObject Button;
    public Button myButton;

    // Use this for initialization
    void Start () {
        health = 3;
        key = 0;
        heart_1 = GameObject.Find("heart1");
        heart_2 = GameObject.Find("heart2");
        heart_3 = GameObject.Find("heart3");
        key_1 = GameObject.Find("key1");
        key_2 = GameObject.Find("key2");
        key_3 = GameObject.Find("key3");
        key_4 = GameObject.Find("key4");

    }

	
	// Update is called once per frame
	void Update () {
        if (health == 3) {
            heart_1.SetActive(true);
            heart_2.SetActive(true);
            heart_3.SetActive(true);
        }
        if (health == 2) {
            heart_1.SetActive(true);
            heart_2.SetActive(true);
            heart_3.SetActive(false);
        }
        if (health == 1) {
            heart_1.SetActive(true);
            heart_2.SetActive(false);
            heart_3.SetActive(false);
        }
        if (health == 0) {
            heart_1.SetActive(false);
            heart_2.SetActive(false);
            heart_3.SetActive(false);
            SceneManager.LoadScene("Over");
        }
        if (key == 4)
        {
            key_1.SetActive(true);
            key_2.SetActive(true);
            key_3.SetActive(true);
            key_4.SetActive(true);
        }
        if (key == 3)
        {
            key_1.SetActive(true);
            key_2.SetActive(true);
            key_3.SetActive(true);
            key_4.SetActive(false);
        }
        if (key == 2)
        {
            key_1.SetActive(true);
            key_2.SetActive(true);
            key_3.SetActive(false);
            key_4.SetActive(false);
        }
        if (key == 1)
        {
            key_1.SetActive(true);
            key_2.SetActive(false);
            key_3.SetActive(false);
            key_4.SetActive(false);
        }
        if (key == 0) {
            key_1.SetActive(false);
            key_2.SetActive(false);
            key_3.SetActive(false);
            key_4.SetActive(false);
        }
    }

    public void addKey() {
        key ++;
    }
    public void lostHealth() {
        health --;
    }

    public void reset()
    {
        health = 3;
        key = 0;
    }
}
