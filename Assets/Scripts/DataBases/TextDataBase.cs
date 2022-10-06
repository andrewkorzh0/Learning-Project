using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newLanguagePack", menuName = "LanguagePack")]
public class TextDataBase : ScriptableObject
{
    [Header("UI, MainMenu and etc.")]
    public string loadButton;
    public string languageButton;
    [Header("Dialogues: volleyball fox")]
    public string[] volleyballfox_1;
    [Header("Dialogues: tara kun")]
    public string[] tarakunsshop_1;
    public string[] tarakunsshop_2;
    [Header("2nd room")]
    public string[] LockedDoor;
    public string[] LockedDoorPrank;
    public string[] LockedDoorPrank2;
}
