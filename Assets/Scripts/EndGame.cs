using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public GameObject winBackground;
    public GameObject winTitle;
    public GameObject loseBackground;
    public GameObject loseTitle;
    public GameObject prompt;

    void Update()
    {
        if (player.currentHealth <= 1)
        {
            loseBackground.SetActive(true);
            loseTitle.SetActive(true);
            Quit();
        }
        else if (enemy.currentHealth <= 1)
        {
            winBackground.SetActive(true);
            winTitle.SetActive(true);
            Quit();
        }
    }

    void Quit()
    {
        prompt.SetActive(true);
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
