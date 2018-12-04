using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    // default 3
    public static int roundCount = 3;
    // default 2
    public static int accidentCount = 2;

    public InputField inputRoundCount;
    public InputField inputAccidentCount;

    public void SaveOptions() {
        int.TryParse(inputAccidentCount.text, out accidentCount);
        int.TryParse(inputRoundCount.text, out roundCount);
        //Debug.Log(OptionsMenu.accidentCount);
        //Debug.Log(OptionsMenu.roundCount);
    }
}
