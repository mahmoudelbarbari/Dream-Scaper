using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour
{
    public Dialogue DialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            string[] dialogue = { "Alora: Where am I?", "Spark: Alora , you've been trapped inside your own dream realm scape by wicked and manipulating forces go on through the gate to  start your journey." };

            DialogueManager.Setsentences(dialogue);
            DialogueManager.StartCoroutine(DialogueManager.TypeDialogue());
        }
    }
}
