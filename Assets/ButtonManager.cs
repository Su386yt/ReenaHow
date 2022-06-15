using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return))
            OnSearch();  
    }

    public void OnSearch() {
        
        string acceptableCharacters = "abcdefghijklmnopqrstuvwxyz 1234567890'\"";
        string inputText = gameManager.inputText.text;
        string searchTerm = inputText.ToLower();

        // Gets rid of any punctuation
        foreach (char c in searchTerm) {
            if (acceptableCharacters.Contains(c))
                continue;
            searchTerm.Replace("" + c, string.Empty);
        }
        
        
        //Get rid of question for the search term
        if (searchTerm.Contains("how to")) {
            searchTerm = searchTerm[(searchTerm.IndexOf("how to") + "how to".Length + 1)..];
        }
        else if (searchTerm.Contains("how do you")) {
            searchTerm = searchTerm[(searchTerm.IndexOf("how do you") + "how do you".Length + 1)..];
        }
        else if (searchTerm.Contains("how does one")) {
            searchTerm = searchTerm[(searchTerm.IndexOf("how does one") + "how does one".Length + 1)..];
        }
        else if (searchTerm.Contains("how does someone")) {
            searchTerm = searchTerm[(searchTerm.IndexOf("how does someone") + "how does someone".Length + 1)..];
        }
        if (searchTerm.StartsWith(" "))
            searchTerm = searchTerm[1..];
        if (searchTerm.Equals("")) return;

        
        int numberOfSteps = 1;
        string bodyText = "";

        if (searchTerm.StartsWith("draw")) {
            numberOfSteps = 2;
            string objectToDraw = searchTerm[(searchTerm.IndexOf("draw") + "draw".Length + 1)..];
            if (objectToDraw.StartsWith("a ")) {
                objectToDraw = objectToDraw[(objectToDraw.IndexOf("a ") + "a ".Length)..];
            }
            else if (objectToDraw.StartsWith("an ")) {
                objectToDraw = objectToDraw[(objectToDraw.IndexOf("an ") + "an ".Length)..];
            }
            bodyText = RemoveDoubleWords("Drawing " + searchTerm[(searchTerm.IndexOf("draw ") + "draw ".Length)..] + " is really quite simple. This article will teach you how to " + searchTerm + " in " + numberOfSteps + " step(s).\n\nStep 1: The circle\n   Draw a circle.\n\nStep 2: The " + objectToDraw + "\n   Draw the rest of the " + objectToDraw + ".");


        }
        else if (searchTerm.StartsWith("make")) {
            numberOfSteps = 2;
            string objectToDraw = searchTerm[(searchTerm.IndexOf("make") + "make".Length + 1)..];
            if (objectToDraw.StartsWith("a ")) {
                objectToDraw = objectToDraw[(objectToDraw.IndexOf("a ") + "a ".Length)..];
            }
            else if (objectToDraw.StartsWith("an ")) {
                objectToDraw = objectToDraw[(objectToDraw.IndexOf("an ") + "an ".Length)..];
            }
            else if (objectToDraw.StartsWith("the ")) {
                objectToDraw = objectToDraw[(objectToDraw.IndexOf("the ") + "the ".Length)..];
            }
            bodyText = RemoveDoubleWords("Making " + searchTerm[(searchTerm.IndexOf("make ") + "make ".Length)..] + " is rather simple. This article will teach you how to " + searchTerm + " in " + numberOfSteps + " step(s).\n\nStep 1: The base\n   The base is the most important part of any project. Start off by making a really strong base.\n\nStep 2: The " + objectToDraw + "\n   Make the rest of the " + objectToDraw + ".");


        }
        else if (searchTerm.StartsWith("build")) {
            numberOfSteps = 2;
            string objectToDraw = searchTerm[(searchTerm.IndexOf("build") + "build".Length + 1)..];
            if (objectToDraw.StartsWith("a ")) {
                objectToDraw = objectToDraw[(objectToDraw.IndexOf("a ") + "a ".Length)..];
            }
            else if (objectToDraw.StartsWith("an ")) {
                objectToDraw = objectToDraw[(objectToDraw.IndexOf("an ") + "an ".Length)..];
            }
            else if (objectToDraw.StartsWith("the ")) {
                objectToDraw = objectToDraw[(objectToDraw.IndexOf("the ") + "the ".Length)..];
            }
            bodyText = RemoveDoubleWords("Building " + searchTerm[(searchTerm.IndexOf("build ") + "build ".Length)..] + " is rather simple. This article will teach you how to " + searchTerm + " in " + numberOfSteps + " step(s).\n\nStep 1: The base\n   The base is the most important part of any build. Start off by building a really strong base.\n\nStep 2: The " + objectToDraw + "\n   Build the rest of the " + objectToDraw + ".");


        }
        else if (searchTerm.Contains("not be depressed")) {
            bodyText = RemoveDoubleWords("Not being depressed is actually really easy when you think about it. Here is how to do it in 1 easy step(s).\nStep 1:\nJust be happy!.");
        }
        else {
            numberOfSteps = 1;
            if (searchTerm.StartsWith("not "))
                searchTerm = ("don't " + searchTerm[(searchTerm.IndexOf("not ") + "not ".Length)..]);
            bodyText = RemoveDoubleWords("To " + searchTerm + " is rather simple. This article will teach you how to " + searchTerm + " in " + numberOfSteps + " step(s).\n\nStep 1:\nJust " + searchTerm + ".");
        }

        gameManager.container.text = bodyText;
        gameManager.title.text = ("How to " + searchTerm + ": In " + numberOfSteps + " easy step(s)");

        
    }

    static string RemoveDoubleWords(string input) {
        char[] charArray = input.ToCharArray();
        List<string> words = new();
        List<char> chars = new();
        foreach (char c in charArray) {
            if (c == ' ') {
                words.Add(CharListToString(chars));
                chars.Clear();
            }
            else {
                chars.Add(c);
            }
        }
        words.Add(CharListToString(chars));

        string previousWord = "";
        for (int i = 0; i < words.Count; i++) {
            if (previousWord.ToLower().Equals((words[i].ToLower()))) {
                previousWord = words[i];
                words[i] = "";
            }
            previousWord = words[i];
        }

        string str = "";
        foreach (string word in words) {
            if (!word.Equals(""))
                str += (word + " ");
        }

        return str;

    }

    static string CharListToString(List<char> chars) {
        string str = "";
        foreach (char c in chars)
            str += c;
        return str;
    }
}
