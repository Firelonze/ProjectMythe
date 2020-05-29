using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    private string[] textPlayer;
    private string[] textTezca;
    private TextMeshProUGUI subs;

    private void Awake()
    {
        subs = GameObject.Find("Subs").GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        textPlayer[0] = "[Player]: 5 bullets left.";
        textPlayer[1] = "[Player]: 4 bullets left.";
        textPlayer[2] = "[Player]: 3 bullets left.";
        textPlayer[3] = "[Player]: 2 bullets left.";
        textPlayer[4] = "[Player]: 1 bullets left.";
        textPlayer[5] = "[Player]: No bullets left...";
        textTezca[0] = "";
    }

    private void SetSubs()
    {

    }
   
}
