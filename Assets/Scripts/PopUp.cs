using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField] private Text text;

    public void ShowPopUp(string teamVictoty, Color teamColor)
    {
        text.color = teamColor;
        text.text = $"Победа за {teamVictoty} ";
    }
}
