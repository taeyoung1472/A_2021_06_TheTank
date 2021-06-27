using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemy;
    [SerializeField]
    private float[] spawnCoolTime;
    [SerializeField]
    private float[] FirstSpawnCoolTime;
    private float Difficulty = 1;
    private int hp = 1000;
    private int high;
    private int best;
    private int score;
    [SerializeField]
    private Text bestScoreTxt;
    [SerializeField]
    private Text scoreTxt;
    [SerializeField]
    private Text DifficultyTxt;
    [SerializeField]
    private Slider hpSlider;
    private Scene scene;
    [SerializeField]
    private GameObject gameOver;
    private bool isHard;
    [SerializeField]
    private GameObject armorCarry;
    [SerializeField]
    private Slider armor;
    // Start is called before the first frame update
    void Start()
    {
        hpSlider.value = hp * 0.001f;
        if (PlayerPrefs.GetInt("Difficulty") == 0)
        {
            isHard = false;
        }
        else
        {
            isHard = true;
        }
        if (isHard == true)
            Difficulty = 0.2f;
        scene = FindObjectOfType<Scene>();
        Debug.Log(isHard);
        Load();
        updateUI();
        StartCoroutine(HumanSpawn());
        StartCoroutine(RpgSpawn());
        StartCoroutine(BunkerSpawn());
        StartCoroutine(TankSpawn());
        StartCoroutine(ItemSpawn());
        StartCoroutine(T34());
        StartCoroutine(DifficultyChange());
    }
    public void GetScore(int get)
    {
        score += get;
        if(score >= best)
        {
            best = score;
            Save();
        }
        Save();
        updateUI();
    }
    void Save()
    {
        if(isHard == false)
        {
            PlayerPrefs.SetInt("Best", best);
        }
        else
        {
            PlayerPrefs.SetInt("HardBest", best);
        }
    }
    void Load()
    {
        if(isHard == false)
        {
            best = PlayerPrefs.GetInt("Best");
        }
        else
        {
            best = PlayerPrefs.GetInt("HardBest");
        }
    }
    void updateUI()
    {
        scoreTxt.text = string.Format("SCORE : {0}", score);
        bestScoreTxt.text = string.Format("BESTSCORE : {0}", best);
        DifficultyTxt.text = string.Format("DIFFICULTY : {0}", 10 - (Difficulty*10));
    }
    public void Damaged(int damage)
    {
        hp -= damage;
        if (hp > 1000)
        {
            armorCarry.SetActive(true);
            armor.value = (hp - 1000) * 0.001f;
            if (hp > 2000)
                hp = 2000;
        }
        else
        {
            armor.value = 0;
            armorCarry.SetActive(false);
            hpSlider.value = hp * 0.001f;
            if (hp <= 0)
                gameOver.SetActive(true);
        }
    }
    private IEnumerator HumanSpawn()
    {
        yield return new WaitForSeconds(FirstSpawnCoolTime[0]);
        while (true)
        {
            high = Random.Range(-2, 2) * 2;
            Instantiate(enemy[0],new Vector2(15, high), Quaternion.identity);
            yield return new WaitForSeconds(spawnCoolTime[0] * Difficulty);
        }
        //yield return new WaitForSeconds(1f);
    }
    private IEnumerator RpgSpawn()
    {
        yield return new WaitForSeconds(FirstSpawnCoolTime[1]);
        while (true)
        {
            high = Random.Range(-2, 2) * 2;
            Instantiate(enemy[1], new Vector2(15, high), Quaternion.identity);
            yield return new WaitForSeconds(spawnCoolTime[1] * Difficulty);
        }
        //yield return new WaitForSeconds(1f);
    }
    private IEnumerator BunkerSpawn()
    {
        yield return new WaitForSeconds(FirstSpawnCoolTime[2]);
        while (true)
        {
            high = Random.Range(-2, 2) * 2;
            Instantiate(enemy[2], new Vector2(15, high), Quaternion.identity);
            yield return new WaitForSeconds(spawnCoolTime[2] * Difficulty);
        }
        //yield return new WaitForSeconds(1f);
    }
    private IEnumerator TankSpawn()
    {
        yield return new WaitForSeconds(FirstSpawnCoolTime[3]);
        while (true)
        {
            high = Random.Range(-2, 2) * 2;
            Instantiate(enemy[3], new Vector2(15, high), Quaternion.identity);
            yield return new WaitForSeconds(spawnCoolTime[3] * Difficulty);
        }
        //yield return new WaitForSeconds(1f);
    }
    private IEnumerator ItemSpawn()
    {
        yield return new WaitForSeconds(FirstSpawnCoolTime[4]);
        while (true)
        {
            high = Random.Range(-2, 2) * 2;
            Instantiate(enemy[4], new Vector2(15, high), Quaternion.identity);
            yield return new WaitForSeconds(spawnCoolTime[4]);
        }
        //yield return new WaitForSeconds(1f);
    }
    private IEnumerator T34()
    {
        yield return new WaitForSeconds(FirstSpawnCoolTime[5]);
        while (true)
        {
            high = Random.Range(-2, 2) * 2;
            Instantiate(enemy[5], new Vector2(15, high), Quaternion.identity);
            yield return new WaitForSeconds(spawnCoolTime[5] * Difficulty);
        }
        //yield return new WaitForSeconds(1f);
    }
    private IEnumerator DifficultyChange()
    {
        if(isHard == false)
        {
            yield return new WaitForSeconds(60);
            Difficulty = 0.8f;
            updateUI();
            yield return new WaitForSeconds(60);
            Difficulty = 0.6f;
            updateUI();
            yield return new WaitForSeconds(60);
            Difficulty = 0.5f;
            updateUI();
            yield return new WaitForSeconds(60);
            Difficulty = 0.4f;
            updateUI();
            yield return new WaitForSeconds(60);
            Difficulty = 0.2f;
            updateUI();
        }
        else
        {
            yield return new WaitForSeconds(30);
            Difficulty = 0.2f;
            updateUI();
            yield return new WaitForSeconds(30);
            Difficulty = 0.18f;
            updateUI();
            yield return new WaitForSeconds(30);
            Difficulty = 0.15f;
            updateUI();
            yield return new WaitForSeconds(30);
            Difficulty = 0.1f;
            updateUI();
            yield return new WaitForSeconds(30);
            Difficulty = 0.05f;
            updateUI();
        }
    }
}
