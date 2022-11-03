using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	public static bool isTime(float wantedTime, ref bool taskDone){
		if (!taskDone) {
			float currentTime = Time.time;
			float futureTime = Time.time + Time.fixedDeltaTime;
			bool reachedTime = currentTime <= wantedTime && wantedTime < futureTime;
			if (reachedTime) taskDone = true;
			return reachedTime;
		}
		return false;
	}
}
