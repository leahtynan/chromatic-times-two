using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
	public OxManager oxManager;
	private Color[,] colors = new Color[2, 4];
	public Color[] darkColors;
	public Color[] lightColors;

	void Start()
	{
		LoadColors();
		SetOxColors();
	}

	private void LoadColors()
	{
		for (int i = 0; i < darkColors.Length; i++)
		{
			colors[0, i] = darkColors[i];
		}
		for (int i = 0; i < lightColors.Length; i++)
		{
			colors[1, i] = lightColors[i];
		}
	}

	public void ColorOx(OxViewer ox, int color, int shade)
    {
		ox.GetComponent<Image>().color = colors[color, shade];
    }

	public void SetOxColors()
    {
		int number = 0;
		for(int i = 0; i < 2; i++)
        {
			for(int j = 0; j < 4; j++)
            {
				ColorOx(oxManager.oxen[number], i, j);
				number++;
            }
        }
    }
}
