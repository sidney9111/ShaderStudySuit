using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class GUIUtil : MonoBehaviour {
	public enum TargetFrame
	{
		Thirty,
		Sixty,
		One,
		Zero
	}
	private TargetFrame _frame;
	float _frameNum = 0;
	float _currTime = 0;
	float _lastNumTime = 0;
	float _fpsTime = 0;
	void Awake(){
		_frame = TargetFrame.Thirty;

	}
	void OnGUI(){



		GUILayout.Label ("fps:"+_fpsTime.ToString("#0.00"));
		if (GUILayout.Button ("" + _frame.ToString())) {		
			int curr = (int)_frame + 1;
			if (!Enum.IsDefined (typeof(TargetFrame), curr)) {
				curr = 0;
			}
			_frame = (TargetFrame)Enum.ToObject(typeof(TargetFrame),curr);
			switch (_frame) {
			case TargetFrame.Thirty:
				Application.targetFrameRate = 30;
				break;
			case TargetFrame.Sixty:
				Application.targetFrameRate = 60;
				break;
			case TargetFrame.One:
				Application.targetFrameRate = 1;
				break;
			case TargetFrame.Zero:
				Application.targetFrameRate = 0;
				break;
			}
			//SRCDebug.Instance.ShowDebugPanel ();
			//SRCDebug.Instance.OpenTab(SRDebugger.DefaultTabs.Console);
		}
	}


	void Update(){

		_currTime += Time.deltaTime;
		_frameNum++;
		if (_currTime - _lastNumTime >= 1.0f) {
			_fpsTime = _frameNum / (_currTime - _lastNumTime);
			_lastNumTime = _currTime;
			_frameNum = 0;
		}
	}

}
