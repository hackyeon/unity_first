using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    [SerializeField] private Text mText;
    private int mScore = 0;
    public void OnButtonClicked()
    {
        mScore++;
        mText.text = $"점수: {mScore}점";
    }
}
