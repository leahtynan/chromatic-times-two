using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[Header("Oxen")]
	public OxManager oxManager;

	[Header("Song")]
	public string[] songNotes;

	[Header("Musical Notes")]
	public AudioSource audioSource;
	public XylophoneKeysManager xylophoneKeysManager;
	Dictionary<string, int> notesMapping = new Dictionary<string, int>()
	{
		{ "c", 0 },
		{ "d", 1 },
		{ "ef", 2 },
		{ "f", 3 },
	};

	[Header("Colors")]
	public ColorManager colorManager;
	
	void Start()
    {
		StartCoroutine(PlayScale(0.5f));
		//StartCoroutine(PlaySong(1f));
	}

	public void PlayNote(int noteNumber)
	{
		string[] noteToPlay = MapNoteToPlay(songNotes[noteNumber]);
		int octave = Convert.ToInt32(noteToPlay[0]);
		int note = Convert.ToInt32(notesMapping[noteToPlay[1]]);
		audioSource.clip = xylophoneKeysManager.notes[octave, note];
		audioSource.Play();
	}

	string[] MapNoteToPlay(string shortHand)
	{
		// Converts shorthand for note (e.g. 1-af, middle octave's A flat) into octave number and musical note
		string[] mapping = shortHand.Split('-');
		return mapping;
	}

	IEnumerator PlaySong(float WaitTime)
	{
		for (int i = 0; i < songNotes.Length; i++)
        {
			PlayNote(i);
			// TODO: Need to re-structure ox UI as a 2D array
			//StartCoroutine(oxManager.oxen[row, column].Bump(WaitTime));
			yield return new WaitForSeconds(WaitTime);
		}
	}

	IEnumerator PlayScale(float WaitTime)
	{
		int number = 0;
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				audioSource.clip = xylophoneKeysManager.notes[i, j];
				audioSource.Play();
				StartCoroutine(oxManager.oxen[number].Bump(WaitTime));
				yield return new WaitForSeconds(WaitTime * 2);
				number++;
			}
		}
	}

}
