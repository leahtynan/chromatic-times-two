using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XylophoneKeysManager : MonoBehaviour
{
	[Header("Musical Notes")]
	public AudioClip[] lowOctave = new AudioClip[4]; 
	public AudioClip[] highOctave = new AudioClip[4];
	public AudioClip[,] notes = new AudioClip[2, 4];

	void Start()
	{
		LoadNotes();
	}

	void LoadNotes()
	{
		for (int i = 0; i < lowOctave.Length; i++)
		{
			notes[0, i] = lowOctave[i];
		}
		for (int i = 0; i < highOctave.Length; i++)
		{
			notes[1, i] = highOctave[i];
		}
	}
}
