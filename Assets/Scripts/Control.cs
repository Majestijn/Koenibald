using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
	public PlayerController thePlayer;
	public GameObject myCanvas, toActivateCanvas, pauseScreen;
	public string levelname;
	public MainMusicStopController music;
	public AudioSource audioData;
	bool yes = true;

	void Start()
	{
		audioData = GetComponent<AudioSource>();

		music = FindObjectOfType<MainMusicStopController>();
		thePlayer = FindObjectOfType<PlayerController>();
		if (pauseScreen != null) pauseScreen.SetActive(false);
	}


	public void ActivateCanvas()
	{
		//toActivateCanvas.enabled=true;
		//myCanvas.enabled=false;
		Instantiate(toActivateCanvas);
		Destroy(myCanvas);
	}
	public void loadLevel(string level)
	{
		Time.timeScale = 1;
		Scenes.setParam("");
		SceneManager.LoadScene(level);
	}
	public void shoot()
	{
		thePlayer.spearThrow();
	}
	public void shovel()
	{
		thePlayer.Shovel();
	}
	public void jump()
	{
		thePlayer.NormalJump();
	}
	public void mute()
	{
		audioData.mute = yes;
		yes = !yes;
	}
	public void resume()
	{
		pauseScreen.SetActive(false);
		music.pauseMusic(false);

		Time.timeScale = 1;
	}
	public void pause()
	{

		pauseScreen.SetActive(true);
		music.pauseMusic(true);

		Time.timeScale = 0;
	}
	public void restart(string level)
	{
		Time.timeScale = 1;
		loadLevel(level);

	}
}