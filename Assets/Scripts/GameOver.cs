using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private AudioSource gameOverSFX;
    public GameObject gameOverPanel;
    [SerializeField] GameObject weaponParent;

    private void Start()
    {
        gameOverSFX = GetComponent<AudioSource>();
    }

    public void PlayerGameOver()
    {
        gameOverSFX.Play();
        GetComponent<PlayerMovement>().enabled = false;
        gameOverPanel.SetActive(true);
        weaponParent.SetActive(false);
    }
}
