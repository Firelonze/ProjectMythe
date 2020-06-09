using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text text1;

    private int health;

    private void Start()
    {
        health = GetComponent<ObjectHealth>().health;
    }

    private void Update()
    {
        text1.text = "Player health: " + health;
    }
}
