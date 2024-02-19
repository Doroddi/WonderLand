using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class DialogSystem : MonoBehaviour
{
	[SerializeField]
	private Speaker[] speakers;                 // 대화에 참여하는 캐릭터들의 UI 배열
	[SerializeField]
	private DialogData[] dialogs;                   // 현재 분기의 대사 목록 배열
	[SerializeField]
	private bool isAutoStart = true;            // 자동 시작 여부
	private int currentDialogIndex = -1;    // 대사 순번, 초기화는 -1로.
	private int currentSpeakerIndex = 0;    // 현재 말하는 화자의 speakers 배열 순번

	// 텍스트 타이핑 속도
	private float typingSpeed = 0.05f;          //
	private bool isTypingEffect = false;        //

	private bool firstLoopEnd = false;

	private StringBuilder sb = new StringBuilder();


	public UnityEvent evnt;
	private void Awake()
	{
	}

	public void Setup()
	{
		// 초기화 시 모든 대화 관련 오브젝트 비활성화
		for (int i = 0; i < speakers.Length; ++i)
		{
			SetActiveObjects(speakers[i], false);
			// 플레이어, NPC는 보이도록 설정

		}
		currentDialogIndex = -1;    // 대사 순번, 초기화는 -1로.
		currentSpeakerIndex = 0;
		SetNextDialog();

		// give delay for reading E keydown to avoid first dialog shows suddenly
		Invoke("DelaySkip", 1f);

	}

	// 대사 분기를 진행하고, 분기가 종료되었을 때 true를 반환하는 updatedialog 함수
	public bool UpdateDialog()
	{
		if (firstLoopEnd && Input.GetKeyDown(KeyCode.E))
		{
			if (isTypingEffect)
			{
				isTypingEffect = false;

				// 타이핑 중일 때 상호작용 키 누르면 대사 전체 출력
				StopCoroutine("OnTypingText");
				speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
				// 대사 완료 시 출력되는 블록 활성화
				speakers[currentSpeakerIndex].objectArrow.SetActive(true);

				return false;
			}

			// 현재 대화에 참여했던 플레이어, NPC, 대화 관련 UI를 보이지 않게 비활성화
			if (dialogs.Length > currentDialogIndex + 1)
			{
				SetNextDialog();
			}
			else
			{
				// SetActiveObjects 에 캐릭터 이미지를 보이지 않게 하는 부분이 없기 때문에 별도로 호출
				for (int i = 0; i < speakers.Length; ++i)
				{
					SetActiveObjects(speakers[i], false);
					// SetActiveObjects 에 캐릭터 이미지를 보이지 않게 하는 부분이 없기 때문에 별도로 호출
					speakers[i].spriteRenderer.gameObject.SetActive(false);
				}

				return true;
			}
		}

		return false;
	}

	private void SetNextDialog()
	{
		// 이전 대화 관련 오브젝트 비활성화
		SetActiveObjects(speakers[currentSpeakerIndex], false);

		// 다음 대사 진행
		currentDialogIndex++;

		// 현재 순번 설정
		currentSpeakerIndex = dialogs[currentDialogIndex].speakerIndex;

		// 현재 대화 관련 오브젝트 활성화
		SetActiveObjects(speakers[currentSpeakerIndex], true);
		// 현재 이름, 대사 텍스트 설정
		speakers[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name;
		// 현재 화자의 대사 텍스트 설정
		speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;

		StartCoroutine("OnTypingText");
	}

	private void SetActiveObjects(Speaker speaker, bool visible)
	{
		speaker.spriteRenderer.gameObject.SetActive(visible);
		speaker.imageDialog.gameObject.SetActive(visible);
		speaker.imageDialog.sprite = speaker.spriteRenderer.sprite;
		speaker.textName.gameObject.SetActive(visible);
		speaker.textDialogue.gameObject.SetActive(visible);
		speaker.panel.SetActive(visible);

		// 화살표는 대사가 종료되었을 때만 활성화하기 때문에 항상 false
		speaker.objectArrow.SetActive(false);

		// 캐릭터 알파 값 변경
		Color color = speaker.spriteRenderer.color;
		color.a = (visible ? 1 : 0.2f);
		speaker.spriteRenderer.color = color;
	}

	private IEnumerator OnTypingText()
	{
		int curIdx = 0;
		string curText = dialogs[currentDialogIndex].dialogue;

		isTypingEffect = true;
		sb.Clear();

		// 텍스트를 한글자씩 타이핑치듯 재생
		while (curIdx < curText.Length)
		{
			sb.Append(curText[curIdx++]);
			speakers[currentSpeakerIndex].textDialogue.text = sb.ToString();
			yield return new WaitForSeconds(typingSpeed);
		}

		isTypingEffect = false;

		// 대사가 완료되었을 때 출력되는 커서 활성화
		speakers[currentSpeakerIndex].objectArrow.SetActive(true);
	}

	private void DelaySkip()
	{
		firstLoopEnd = true;
	}
}

[System.Serializable]
public struct Speaker
{
	public Image spriteRenderer;       // 캐릭터 이미지 알파값 제어
	public Image imageDialog;       // 대화창 Image UI

	// 현재 대사 중인 캐릭터 이름, 대사 출력 UI
	public TextMeshProUGUI textName;
	public TextMeshProUGUI textDialogue;
	public GameObject objectArrow;      // 대사가 완료되었을 때 나오는 오브젝트

	public GameObject panel;
}

[System.Serializable]
public struct DialogData
{
	public int speakerIndex;    // 이름 대사 출력 시 현재 DialogSystem의 speaker 배열 순번
	public string name;
	public string dialogue;
}