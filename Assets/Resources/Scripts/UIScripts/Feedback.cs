using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//This is a very simple script that sends an email to us with any text that the player has input in the respective field.
//It is combined with an Inputfield on UI.
public class Feedback : MonoBehaviour
{
    string mailContent;
    public TextMeshProUGUI feedback;

    private void Awake()
    {
    }

    public void ReceiveFeedback()
    {
        mailContent = feedback.text;
        Debug.Log("mailContent " + mailContent);   
    }

    public void SendEmail()
    {
        string email = "O.Chatzifoti1@student.gsa.ac.uk, P.Brosz1@student.gsa.ac.uk, D.Murray1@student.gsa.ac.uk, A.Wolfe1@student.gsa.ac.uk";
        string subject = "Feedback!";
        string body = mailContent;

        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
    }


}
