using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
	public Image background; // Image just for testing the colors
	private Color[,] colors = new Color[3, 3];
	public Color[] darkColors;
	public Color[] mediumColors;
	public Color[] lightColors;

	void Start()
	{
		LoadColors();
	}

	private void LoadColors()
	{
		for (int i = 0; i < darkColors.Length; i++)
		{
			colors[0, i] = darkColors[i];
		}
		for (int i = 0; i < mediumColors.Length; i++)
		{
			colors[1, i] = mediumColors[i];
		}
		for (int i = 0; i < lightColors.Length; i++)
		{
			colors[2, i] = lightColors[i];
		}
	}

	public void UpdateColor(int color, int shade)
    {
		background.color = colors[color, shade];
    }
}
