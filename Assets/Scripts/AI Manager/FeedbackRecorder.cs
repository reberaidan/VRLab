using OpenAI.Samples.Chat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackRecorder : MonoBehaviour
{
    public int itemsDropped = 0;

    public List<string> itemDroppedNames = new List<string> { };

    public int burns = 0;

    public int itemsEaten = 0;

    public string[] itemEatenNames = new string[] { };

    [SerializeField] private ChatBehaviour conversation;


    public void startFeedback()
	{
        conversation.inputText += "I have completed my lab! Here are some of the things that I did during my lab: ";

        feedbackBurns();

        feedbackDropped();

        conversation.SubmitChat();
	}
    public void feedbackBurns()
	{
        conversation.inputText += "I burned myself " + burns.ToString() + " times!";
	}

	public void feedbackDropped()
	{
        conversation.inputText += "I dropped " + itemsDropped.ToString() + " items during the lab. ";


        //  conversation.inputText += "The most frequently dropped item: beaker";
	}
}
