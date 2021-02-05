using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[Header("Song")]
	// TODO: Songs will be stored elsewhere once the full architecture is planned
	public string[] songNotes;

	[Header("Musical Notes")]
	public AudioSource audioSource;
	public PianoKeysManager pianoKeysManager;
	Dictionary<string, int> notesMapping = new Dictionary<string, int>()
	{
		{ "c", 0 },
		{ "cs", 1 },
		{ "d", 2 },
		{ "ef", 3 },
		{ "e", 4 },
		{ "f", 5 },
		{ "fs", 6 },
		{ "g", 7 },
		{ "af",8 },
		{ "a", 9 },
		{ "bf", 10 },
		{ "b", 11 }
	};

	[Header("Colors")]
	public ColorManager colorManager;
	
	void Start()
    {
		//StartCoroutine(PlayScale(0.5f));
		//StartCoroutine(CycleColors(1f));
		StartCoroutine(PlaySong(1f));
	}

	public void PlayNote(int noteNumber)
	{
		string[] noteToPlay = MapNoteToPlay(songNotes[noteNumber]);
		int octave = Convert.ToInt32(noteToPlay[0]);
		int note = Convert.ToInt32(notesMapping[noteToPlay[1]]);
		audioSource.clip = pianoKeysManager.notes[octave, note];
		colorManager.UpdateColor(octave, note);
		audioSource.Play();
	}

	string[] MapNoteToPlay(string shortHand)
	{
		// Converts shorthand for note (e.g. 1-af, middle octave's A flat) into octave number and musical note
		string[] mapping = shortHand.Split('-');
		return mapping;
	}

	/*	The following are quick demos as proof of concept for iterating through music and color data structures */


	IEnumerator PlaySong(float WaitTime)
	{
		for (int i = 0; i < songNotes.Length; i++)
        {
			PlayNote(i);
			yield return new WaitForSeconds(WaitTime);
		}
	}

	IEnumerator PlayScale(float WaitTime)
	{
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 12; j++)
			{
				audioSource.clip = pianoKeysManager.notes[i, j];
				audioSource.Play();
				yield return new WaitForSeconds(WaitTime);
			}
		}
	}

	IEnumerator CycleColors(float WaitTime)
	{
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				colorManager.UpdateColor(i, j); 
				audioSource.clip = pianoKeysManager.notes[i, j + 4]; // Starting more toward middle of the octave due to repeat audio files for low C/C#
				audioSource.Play();
				yield return new WaitForSeconds(WaitTime);
			}
		}
	}

}
