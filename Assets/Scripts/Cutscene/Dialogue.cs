using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue: MonoBehaviour
{
    public bool finished;
    protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, AudioClip sound, float delay, float maxEndDelay)
    {  
        textHolder.color = textColor;
        textHolder.font = textFont;
        for (int i = 0; i < input.Length; i++)
        {
            textHolder.text += input[i];
            SoundManager.instance.PlaySound(sound);
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(maxEndDelay);
        finished = true;
        
    }
}