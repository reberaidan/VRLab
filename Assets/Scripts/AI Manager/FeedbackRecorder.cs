using OpenAI.Samples.Chat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackRecorder : MonoBehaviour
{
	[Tooltip("Add items dropped to AI feedback")]
	[SerializeField] private bool addItemsDropped;
	private int itemsDropped = 0;

    private List<string> itemDroppedNames = new List<string> { };

	[Tooltip("Add burns to AI feedback")]
	[SerializeField] private bool addBurns;
	private int burns = 0;

	[Tooltip("Add items eaten to AI feedback")]
	[SerializeField] private bool addItemsEaten;
	private int itemsEaten = 0;

    [Tooltip("Add mixtures to AI feedback")]
    [SerializeField] private bool addLiquidsAdded;
    private int liquidsAdded;

    private string[] itemEatenNames = new string[] { };

    [SerializeField] private ChatBehaviour conversation;
    [SerializeField] private GameObject FeedbackField;
    private GameObject roomManager;

    [SerializeField] private int marginOfError;

	private void Start()
	{
        roomManager = GameObject.FindWithTag("roomManager");
	}

	public void startFeedback()
	{
        conversation.inputText += "I have completed my lab! Here are some of the things that I did during my lab: ";

        if (addBurns)
        {
            feedbackBurns();
        }

        if (addItemsDropped)
        {
            feedbackDropped();
        }

        if (addLiquidsAdded)
        {
            feedbackLiquidMixed(); 
        }

        conversation.inputText += "What do you think of my performance? ";

        FeedbackField.SetActive(true);
        conversation.SubmitChat();
        print(conversation.inputText);
	}

    public void tutorialFeedback()
    {
		conversation.inputText += "Explain your role and function in the lab. What can you do and what do you provide for me?";


		FeedbackField.SetActive(true);
		conversation.SubmitChat();
	}
    public void feedbackBurns()
	{
        conversation.inputText += "I burned myself " + burns.ToString() + " times!";
	}

    public void incrementBurns()
    {
        burns++;
    }

	private void feedbackDropped()
	{
        conversation.inputText += "I dropped " + itemsDropped.ToString() + " items during the lab. ";
	}

    public void incrementDropped()
    {
        itemsDropped++;
    }

   private void feedbackLiquidMixed()
    {

        conversation.inputText += "I added " + liquidsAdded.ToString() + " liquids to beakers during the lab. ";
        if(roomManager.GetComponent<liquidRoomManager>() != null)
        {
            var rmAsset = roomManager.GetComponent<liquidRoomManager>();
            conversation.inputText += "The lab could have been completed with " + (rmAsset.getTotalMixtures() * rmAsset.getTotalSteps()) + " liquids. ";
            conversation.inputText += ("My grade is affected negatively by a letter grade for every {0} liquids I go over or under. Tell me how many liquids I added and how many were expected. ", marginOfError);
        }

    }

    public void incrementLiquidMixed()
    {
        liquidsAdded++;
    }

    public void resubmitFeedback()
    {
        conversation.inputText = "Can I get some more feedback for the lab? Start you response with 'Some additional feedback I can provide'";

        conversation.SubmitChat();
    }
}
