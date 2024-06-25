using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        saveManager.Initializer();
        soundManager.Initializer();
        PlayBGM(BGMEnum.TITLE);
    }
    #region 씬전환
    [SerializeField] private Image FadeBlinding;
    Coroutine FadeCoroutine;

    public void FadeIn()
    {
        if (FadeCoroutine != null) StopCoroutine(FadeCoroutine);
        FadeCoroutine = StartCoroutine(Fade(false));
    }
    public void MoveScene(int targetSceneIndex)
    {
        if (FadeCoroutine != null) StopCoroutine(FadeCoroutine);
        FadeCoroutine = StartCoroutine(MoveSceneCo(targetSceneIndex));
    }
    IEnumerator Fade(bool nowFadeOut)
    {
        Color c;
        Color delta;
        if (nowFadeOut)
        {
            c = new Color(0, 0, 0, 1);
            delta = new Color(0, 0, 0, 1);
            FadeBlinding.gameObject.SetActive(true);
        }
        else
        {
            c = new Color(0, 0, 0, 0);
            delta = new Color(0, 0, 0, -1);
        }
        while (true)
        {
            FadeBlinding.color += delta * Time.deltaTime;
            float alpha = FadeBlinding.color.a;
            alpha = Mathf.Clamp01(alpha);
            if(Mathf.Abs(c.a- alpha) < 0.01f)
            {
                FadeBlinding.color = c;
                break;
            }
            yield return null;
        }
        if (!nowFadeOut)
        {
            FadeBlinding.gameObject.SetActive(false);
        }
    }
    IEnumerator MoveSceneCo(int targetSceneIndex)
    {
        yield return StartCoroutine(Fade(true));
        SceneManager.LoadScene(targetSceneIndex);
    }
    #endregion

    #region 알림
    public GameObject AlertObj;
    public TextMeshProUGUI AlertText;
    Coroutine AlertCoroutine;
    public void ShowAlert(string message)
    {
        PlaySFX(SFXEnum.Alert);
        AlertText.text = message;  
        AlertObj.SetActive(true);
        if (AlertCoroutine != null) StopCoroutine(AlertCoroutine);
        AlertCoroutine = StartCoroutine(AlertCo());
    }
    IEnumerator AlertCo()
    {
        yield return new WaitForSecondsRealtime(3);
        AlertObj.SetActive(false);
    }
    #endregion
    [SerializeField] private SaveManager saveManager;
    public GameData nowData;
    public void SaveGame()
    {
        saveManager.SaveData(nowData);
    }
    public bool LoadGame()
    {
        if (saveManager.TryLoadData(out GameData data))
        {
            nowData = data;
            return true;
        }
        else return false;
    }
    [SerializeField] private SoundManager soundManager;
    public void PlayBGM(BGMEnum target)
    {
        soundManager.PlayBGM(target);

    }
    public void PlaySFX(SFXEnum target)
    {
        soundManager.PlaySFX(target);
    }

   
    [SerializeField] private DataManager dataManager;



}