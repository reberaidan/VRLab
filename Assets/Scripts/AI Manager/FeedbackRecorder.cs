using OpenAI.Samples.Chat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackRecorder : MonoBehaviour
{
    
    private int itemsDropped = 0;

    private List<string> itemDroppedNames = new List<string> { };

    private int burns = 0;

    private int liquidsAdded = 0;

    private int itemsEaten = 0;

    private string[] itemEatenNames = new string[] { };

    [SerializeField] private ChatBehaviour conversation;
    [SerializeField] private GameObject FeedbackField;


    public void startFeedback()
	{
        conversation.inputText += "I have completed my lab! Here are some of the things that I did during my lab: ";

        feedbackBurns();

        feedbackDropped();

        FeedbackField.SetActive(true);
        conversation.SubmitChat();
	}
    public void feedbackBurns()
	{
        if(burns!= 0) { 
            conversation.inputText += "I burned myself " + burns.ToString() + " times!";
        }
	}

    public void incrementBurns()
    {
        burns++;
    }

	private void feedbackDropped()
	{
        if(itemsDropped!= 0)
        {
            conversation.inputText += "I dropped " + itemsDropped.ToString() + " items during the lab. ";
        }


        //  conversation.inputText += "The most frequently dropped item: beaker";
	}

    public void incrementDropped()
    {
        itemsDropped++;
    }

   private void feedbackLiquidMixed()
    {
        if(liquidsAdded!= 0)
        {
            conversation.inputText += "I added " + liquidsAdded.ToString() + " liquids to beakers during the lab.";
        }
    }

    public void incrementLiquidMixed()
    {
        liquidsAdded++;
    }
}
