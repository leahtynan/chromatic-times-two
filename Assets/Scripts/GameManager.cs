using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
	[Header("Oxen")]
	public OxManager oxManager;

	[Header("Song")]
	public string[] songNotes;
	public AudioClip recordedSong;
	private int notesPlayed = 0;

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
		StartCoroutine(PlaySong(1f));
	}

	public void PlayNote(int noteNumber)
	{
		string[] noteToPlay = MapNoteToPlay(songNotes[noteNumber]);
		int octave = Convert.ToInt32(noteToPlay[0]);
		int note = Convert.ToInt32(notesMapping[noteToPlay[1]]);
		audioSource.clip = xylophoneKeysManager.notes[octave, note];
		audioSource.Play();
		StartCoroutine(oxManager.oxGrid[octave, note].Bump(1f));
	}

	string[] MapNoteToPlay(string shortHand)
	{
		// Converts shorthand for note (e.g. 1-af, middle octave's A flat) into octave number and musical note
		string[] mapping = shortHand.Split('-');
		return mapping;
	}

	IEnumerator PlaySong(float WaitTime)
	{
		yield return new WaitForSeconds(10f); // Wait for scale to finish playing
		for (int i = 0; i < songNotes.Length; i++)
        {
			PlayNote(i);
			yield return new WaitForSeconds(WaitTime);
			notesPlayed++;
			if(notesPlayed == songNotes.Length)
            {
				audioSource.clip = recordedSong;
				audioSource.Play();
				foreach(OxViewer ox in oxManager.oxen)
                {
					StartCoroutine(ox.SmileAndSway(1f));
                }
				yield return new WaitForSeconds(audioSource.clip.length);
			}
		}
	}

	IEnumerator PlayScale(float WaitTime)
	{
		yield return new WaitForSeconds(2f); // Wait a moment so this doesn't start right away when the application starts
		int number = 0;
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				audioSource.clip = xylophoneKeysManager.notes[i, j];
				audioSource.Play();
				StartCoroutine(oxManager.oxGrid[i, j].Bump(WaitTime));
				yield return new WaitForSeconds(WaitTime * 2);
				number++;
			}
		}
	}

}
