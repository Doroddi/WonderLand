using System.Collections;
using UnityEngine;
using TMPro;

public class DialogTest : MonoBehaviour
{
	private static DialogTest dialogTest;


	[SerializeField]
	private DialogSystem dialogSystem01;
	private bool isInit = false;

	public static DialogTest getInstance()
	{
		if (dialogTest == null)
		{
			dialogTest = new DialogTest();
		}
		return dialogTest;
	}

	private void Start() { }

	public void StartAsync()
	{
		if (!isInit)
		{
			dialogSystem01.Setup();
			isInit = true;
			StartCoroutine("InitDialog");
		}

		Debug.Log("InitDialog");
	}
	public IEnumerator InitDialog()
	{
		// 첫 번째 대사 분기 시작
		yield return new WaitUntil(() => dialogSystem01.UpdateDialog());

		// UnityEditor.EditorApplication.ExitPlaymode();
	}
}
