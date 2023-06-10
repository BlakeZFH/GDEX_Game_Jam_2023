using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] AudioSource buttonSFX;

    private void Start()
    {
        buttonSFX = GetComponent<AudioSource>();
    }

    public void StartLevel()
    {
        buttonSFX.Play();
        SceneManager.LoadScene("Level_1");
    }
}
