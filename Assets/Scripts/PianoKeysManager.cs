using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoKeysManager : MonoBehaviour
{
	[Header("Musical Notes")]
	public AudioClip[] lowOctave = new AudioClip[12]; // TODO: Low C# and low C are the same audio file. Find originals or re-record to resolve.
	public AudioClip[] middleOctave = new AudioClip[12];
	public AudioClip[] highOctave = new AudioClip[12];
	public AudioClip[,] notes = new AudioClip[3, 12];

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
		for (int i = 0; i < middleOctave.Length; i++)
		{
			notes[1, i] = middleOctave[i];
		}
		for (int i = 0; i < highOctave.Length; i++)
		{
			notes[2, i] = highOctave[i];
		}
	}
}
