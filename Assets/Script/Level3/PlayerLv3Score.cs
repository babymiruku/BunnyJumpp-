using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLv3Score : MonoBehaviour
{
    public int score;
    public float timeLeft = 60;
    public GameObject TimeUI;
    public GameObject ScoreUI;
    private AudioSource au;
    public AudioClip coinClip;
    void Start()
    {
        au = GetComponent<AudioSource>();
    }


    void Update()
    {
        timeLeft -= Time.deltaTime;
        TimeUI.gameObject.GetComponent<Text>().text = "" + (int)timeLeft;
        ScoreUI.gameObject.GetComponent<Text>().text = "" + score;

        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene(5);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            score += 1;
            Destroy(other.gameObject);
            au.clip = coinClip;
            au.Play();
        }
        if (other.gameObject.tag == "ExtraCoin")
        {
            score += 10;
            Destroy(other.gameObject);
            au.clip = coinClip;
            au.Play();
        }
    }
}
