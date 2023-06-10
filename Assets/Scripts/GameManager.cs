using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] AudioSource startSFX;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        startSFX = GetComponent<AudioSource>();
        startSFX.Play();
    }

    public Transform playerTransform;
}
