using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI inputText;
    public TMPro.TextMeshProUGUI title;
    public TMPro.TextMeshProUGUI container;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Screen.currentResolution.width);
        Debug.Log(Screen.currentResolution.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
