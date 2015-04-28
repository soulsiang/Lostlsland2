using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CutScene : MonoBehaviour {

	bool noTalking = false;
	bool noReading = true;
	[SerializeField] Animator maskAnim;
	[SerializeField] Text talkingText;
	[SerializeField] Text diaryText;
	[SerializeField] Animator cutSceneAnim;

	string[] speech = new string[8] {
		"漫無邊際的大海... 這、這是第幾天了?",
		"距離離開上次那座島已經有好一陣子了吧",
		"還是想不透那裡究竟發生了什麼事",
		"只在逃走之前撿到了這幾張日記紙...",
		"",
		"看來光憑這些日記片段還是不太能理解",
		"只能再多找一些相關線索了",
		"咦? 那是... 另一座島?"
	};

	int speechIndex = 0;

	void NextSpeech () {
		cutSceneAnim.SetTrigger ("murmur");
	}

	void NextSpeechText () {
		if (speechIndex == 4) {
			noTalking = true;
			noReading = false;
			talkingText.text = "";
			NextDiary ();
		}
		else if (speechIndex == 8) {
			// fade out
			noTalking = true;
			noReading = true;
			talkingText.text = "";
			cutSceneAnim.SetTrigger ("idle");
			maskAnim.SetBool ("show", true);
			Invoke ("TurnOffPreviousThings", 3f);
		}
		else if (!noTalking && speechIndex < speech.Length) {
			talkingText.text = speech [speechIndex++];
		}
	}

	void TurnOffPreviousThings () {
		GameObject.Find ("PreviousCamera").SendMessage ("TurnOffPreviousThings");
	}

	string[] diary = new string[4] {
		"OOOO年O月X日\n\n這次的森林遺跡探險挺順利，蒐羅到了相當多的寶藏，同時也發現了一樣相當古怪的東西，外型像是石碑，但是卻沒有石碑應有的重量以及材質，摸起來非金非木，而且奇怪的是石碑上所篆刻的文字，看在每個人眼中好像不一樣，據在場所有看到的人都說是以自己的母語寫的，而我看到的確實也是中文，上面寫著：「未來的子孫們，汝切記不可與之為敵，他開始了一切，也結束了一切，我等終將只是掌中物矣。」多國語文呈現的不自然現象讓大家覺得非常神奇，但我卻有一種不祥的感覺。",
		"OOOO年O月O日\n\n挖掘作業順利完成，同時也接到上級命令把寶藏連同石碑送回國內封存，裝箱作業持續了一整個下午，直到傍晚最後一個運輸車隊總算離開了，但詭異的事情從此開始...\n\n遺跡不見了！\n\n偌大的一片遺跡連同紮營的所有裝備以及留守在遺跡的人手都消失了！周邊只剩下一大片平整的土地，那是一種被非自然的力量所剷平似的平整，我們用剩下的人手搜索了將近一個禮拜，絲毫找不出任何線索有關那座消失的遺跡，也聽說了上級似乎動用了衛星以及探測儀等高科技設備卻也是毫無所獲，這真的是太詭異了，難道我們受到了某種詛咒？不... 這一點也不科學。",
		"OXOX年X月O日\n\n又接到了上級的遺跡探索指令，這已經是這個月第四次了，為什麼從那次詭異的遺跡消失事件過後，突然就暴增了好幾個要求做遺跡探索的地點？遺跡並不是路邊的小石頭隨腳踢就有啊，哪來這麼多準確的情報，是有傳言說跟那個古怪的石碑有關，石碑似乎從遺跡消失之後，上面的文字就轉變成一塊大陸的地圖，而這塊大陸在世界地圖上竟然沒有標記，而且需要由持有石碑之人掌舵並走特定的渠道才能抵達... 這真是太荒謬了！",
		"OXOX年O月X日\n\n發生太多事情寫不來了，但總而言之我現在接到任務，目的是要將那古怪的石碑護送往編號CTX1-1的島嶼，聽說島上正在開發延長人類壽命的實驗，我想應該是醫療方面的研究吧，不過這島我有印象，上次被發派到這座島嶼的時候，還差點收不到衛星訊號導致接我們的船隻慢了六個小時才到，島嶼的中間倒是有一座高聳的山脈，也就是實驗室的所在地，把怪石碑送到那裏就可以走了。"
	};

	int diaryIndex = 0;

	void NextDiary () {
		cutSceneAnim.SetTrigger ("read");
	}

	void NextDiaryText () {
		if (diaryIndex == 4) {
			noTalking = false;
			noReading = true;
			speechIndex ++;
			cutSceneAnim.SetTrigger("murmur");
		}
		else if (!noReading && diaryIndex < diary.Length) {
			diaryText.text = diary [diaryIndex++];
		}
	}
}
