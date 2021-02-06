using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxViewer : MonoBehaviour
{

    public IEnumerator Bump(float WaitTime)
	{
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
		Debug.Log("Bumping down");
        currentTime = 0.0f;
        do
        {
            this.transform.localScale = Vector3.Lerp(bumpedUpScale, regularScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
        Debug.Log("Bump animation complete");
    }

    public IEnumerator Sway(float WaitTime)
    {
        // TODO: Sway ox face left/right several cycles 
        for(int i = 0; i < 5; i++)
        {
            StartCoroutine(SwayLeft(WaitTime));
            yield return new WaitForSeconds(WaitTime); // TODO: Should be amount of time SwayLeft takes
            StartCoroutine(SwayRight(WaitTime));
            yield return new WaitForSeconds(WaitTime); // TODO: Should be amount of time SwayRight takes
        }
    }

    public IEnumerator SwayLeft(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
    }

    public IEnumerator SwayRight(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
    }

}
