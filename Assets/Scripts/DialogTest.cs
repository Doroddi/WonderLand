using System.Collections;
using UnityEngine;
using TMPro;

public class DialogTest : MonoBehaviour
{
    [SerializeField]
	private	DialogSystem	dialogSystem01;

	private IEnumerator Start()
	{
		// 첫 번째 대사 분기 시작
		yield return new WaitUntil(()=>dialogSystem01.UpdateDialog());

		UnityEditor.EditorApplication.ExitPlaymode();
	}
}
