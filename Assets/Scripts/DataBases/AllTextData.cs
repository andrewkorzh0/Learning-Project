using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//test structure. make polish
//used in GameManager.cs, A_VolleyballFox.cs
// set variable in manager class with definition of actuall language

public class DialogueData
{
    //public Font font;
    public string[] text;
    public bool shake;

    public DialogueData(string[] text, bool shake = false)
    {
        this.text = text;
        this.shake = shake;
    }

    public virtual string[] getText()
    {
        return text;
    }
}

public abstract class AbstractTextData
{

    public abstract DialogueData fox_1{get;}
    public abstract DialogueData taraKunShop_1{get;}

}


public class EnglishText : AbstractTextData
{
    public DialogueData fox1 = new DialogueData(
        new string []{
        "Hello, I'm volleybal fox ",
        "I very love volleyball actually.",
        "I think Haikyuu is a good anime because of volleyball"},
        true);
    public override DialogueData fox_1{get{return fox1;}}

    public DialogueData taraKunShop1 = new DialogueData
    (
        new string[]
        {
            "...",
            ".....",
            ".......",
            "OH",
            "GOSH",
            "PLEASE SORRY ME, I DIDN'T NOTICE YOU",
            "*khm*",
            "Well, what do you want?"
        }
    );
    public override DialogueData taraKunShop_1{get{return taraKunShop1;}}
}

public class RussianText : AbstractTextData
{
    public DialogueData fox1 = new DialogueData(
        new string []{
        "Мяу"});
    public override DialogueData fox_1{get{return fox1;}}

    public DialogueData taraKunShop1 = new DialogueData
    (
        new string[]
        {
            "...",
            ".....",
            ".......",
            "ОЙ",
            "БЛИН",
            "ПРОСТИ, ПОЖАЙЛУСТА, Я НЕ ЗАМЕТИЛ ТЕБЯ",
            "*кхм*",
            "Чтож, чего бы ты хотел?"
        }
    );
    public override DialogueData taraKunShop_1{get{return taraKunShop1;}}
}