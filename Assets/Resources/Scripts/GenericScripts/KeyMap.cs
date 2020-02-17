using UnityEngine;
using System.Collections;

public static class KeyMap
{ 
    public static KeyCode pauseGameKey = KeyCode.Escape;
    public static KeyCode runningKey = KeyCode.LeftShift;
    public static KeyCode jumpingKey = KeyCode.Space;
    public static KeyCode floatingKey = KeyCode.CapsLock;
    public static KeyCode floatingKeyGoUp = KeyCode.Space;
    public static KeyCode floatingKeyGoDown = KeyCode.LeftShift;

    public static KeyCode examineKey = KeyCode.E;

    //Q for Querry
    //E for Engage
    //R for Retrieve and Renounce
    //F for float

    //    public static KeyCode inspectKey = KeyCode.I;
    //    public static KeyCode interactKey = KeyCode.?;
    //    public static KeyCode interactKey = inspectKey;

    //would it be better if we use the Q and E and R?
    public static KeyCode pickUpKey = KeyCode.P;

    public static KeyCode discardKey = pickUpKey; // KeyCode.D

}
