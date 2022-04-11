using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class habd : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingspeed;

    public GameObject continueButton;

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    void Start()
    {
        StartCoroutine(Type());
    }
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void Nextsentence()
    {
        continueButton.SetActive(false);
        if(index < sentences.Length -1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            this.sentences = null;
            index = 0;
            Destroy(gameObject);
        }            
    }
    // Update is called once per frame
    
}
