using UnityEngine;
using System.Collections;

public static class KeyMap
{ 
    public const KeyCode pauseGameKey = KeyCode.Escape;
    public const KeyCode runningKey = KeyCode.LeftShift;
    public const KeyCode jumpingKey = KeyCode.Space;
    public const KeyCode floatingKey = KeyCode.CapsLock;
    
    //Interactions
    public const KeyCode InteractKey = KeyCode.E;
    public const int LongPressThresholdInSeconds = 1; //How long to hold the interact key for long press action

    //Q for Querry
    //E for Engage
    //R for Retrieve and Renounce
    //F for float

    //    public static KeyCode inspectKey = KeyCode.I;
    //    public static KeyCode interactKey = KeyCode.?;
    //    public static KeyCode interactKey = inspectKey;

    //would it be better if we use the Q and E and R?
    //public static KeyCode pickUpKey = KeyCode.P; //Replaced with longkeypress logic
    //public static KeyCode discardKey = pickUpKey; // KeyCode.D //Replaced with longkeypress logic

}
