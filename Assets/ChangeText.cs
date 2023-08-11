using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    private List<string> strings = new List<string>();

    // Start is called before the first frame update
    void Awake()
    {
        strings.Add("The Tube is a lie");
        strings.Add("A Tube a Day keeps the Doctor away");
        strings.Add("What a Tubetastical Day");
        strings.Add("You just got tubed");
        strings.Add("And I just walked 500 Tubes");
        strings.Add("What´s a Tube");
        strings.Add("Tube was here");
        strings.Add("Put that Tube down");
        strings.Add("It´s the Tube 14 Pro Max Special Gamers HD 80s Retro Combat Edition 4k 60fps");
        strings.Add("All hail Tubethullu");
        strings.Add("Welcome to Baldurs Tube");
        strings.Add("Tubes 4 Life");
        strings.Add("Gotta Tube'em all");

        int index = Random.Range(0, strings.Count);
        GetComponent<Text>().text = strings[index];
    }
}
