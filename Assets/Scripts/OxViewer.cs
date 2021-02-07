using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxViewer : MonoBehaviour
{
    public Image imageBase;
    public Image face;
    public Sprite eyesOpen;
    public Sprite eyesClosed;

    public IEnumerator Bump(float WaitTime)
	{
        yield return new WaitForSeconds(WaitTime/4);
        Vector3 regularScale = this.transform.localScale;
        Vector3 bumpedUpScale = new Vector3(1.25f, 1.25f, 1.0f);
        float time = WaitTime/2;
        float currentTime = 0.0f;
        do
        {
            this.transform.localScale = Vector3.Lerp(regularScale, bumpedUpScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
		yield return new WaitForSeconds(WaitTime);
        currentTime = 0.0f;
        do
        {
            this.transform.localScale = Vector3.Lerp(bumpedUpScale, regularScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }

    public IEnumerator SmileAndSway(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        face.sprite = eyesClosed;
        RectTransform rectTransform = this.GetComponent<RectTransform>();
        // Sway right from center to right
        for (int j = 0; j < 5; j++)
        {
            rectTransform.Rotate(new Vector3(0, 0, -4));
            yield return new WaitForSeconds(0.1f);
        }
        for (int i = 0; i < 4; i++)
        {
            // Sway left from right to left
            for (int j = 0; j < 5; j++)
            {
                rectTransform.Rotate(new Vector3(0, 0, 8));
                yield return new WaitForSeconds(0.1f);
            } 
            yield return new WaitForSeconds(WaitTime);
            // Sway right from left to right
            for (int j = 0; j < 5; j++)
            {
                rectTransform.Rotate(new Vector3(0, 0, -8));
                yield return new WaitForSeconds(0.1f);
            }
        }
        // Sway left from right to center
        // Sway left from right to left
        for (int j = 0; j < 5; j++)
        {
            rectTransform.Rotate(new Vector3(0, 0, 4));
            yield return new WaitForSeconds(0.1f);
        }
        face.sprite = eyesOpen;
    }

}
