using System.Collections;
using UnityEngine;
using TMPro;

public class DialogTest : MonoBehaviour
{
	public static DialogTest dialogTest;


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


	public void AdaptDialogSystem(DialogSystem dialogSystem)
	{
		dialogSystem01 = dialogSystem;
	}
	public void StartAsync(bool isRestart)
	{

		if (!isInit && isRestart)
		{
			GameManager.instance.Stop();
			dialogSystem01.Setup();
			isInit = true;
			StartCoroutine("InitDialog");

		}
		else if (!isInit && !isRestart)
		{
			GameManager.instance.Stop();
			dialogSystem01.Setup();
			isInit = true;
			StartCoroutine("RestartDialog");
		}
	}
	public IEnumerator InitDialog()
	{
		// 첫 번째 대사 분기 시작
		yield return new WaitUntil(() => dialogSystem01.UpdateDialog());
		InteractionManager.instance.CompleteInteraction();
		isInit = false;
		GameManager.instance.Resume();

		if (dialogSystem01.evnt != null)
		{
			dialogSystem01.evnt.Invoke();
		}
	}

	public IEnumerator RestartDialog()
	{
		yield return new WaitUntil(() => dialogSystem01.UpdateDialog());
		isInit = false;
		GameManager.instance.Resume();
	}
}
