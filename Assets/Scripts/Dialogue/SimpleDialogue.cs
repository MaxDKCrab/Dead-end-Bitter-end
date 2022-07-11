using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Simple Dialogue", menuName = "Simple Dialogue Object")]
public class SimpleDialogue : ScriptableObject
{
    public Line[] lines;
    public Line onReturnDialogue;
    public bool isDialogueFinishedSimple = false;
}

