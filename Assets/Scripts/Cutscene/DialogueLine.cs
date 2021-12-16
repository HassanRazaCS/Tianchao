using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueLine : Dialogue
{
    private Text textHolder;
    [SerializeField] private string input;
    [SerializeField] private Color textColor;
    [SerializeField] private Font textFont;
    [SerializeField] private float delay;
    [SerializeField] private float maxEndDelay;
    [SerializeField] private AudioClip sound;
    [SerializeField] private Image imageHolder;
    [SerializeField] private Sprite character;

    private void Awake()
    {
        textHolder = GetComponent<Text>();
        textHolder.text = "";

        imageHolder.sprite = character;
        imageHolder.preserveAspect = true;
    }
    private void Start()
    {
        StartCoroutine(WriteText(input, textHolder, textColor, textFont, sound, delay, maxEndDelay));
    }
}
