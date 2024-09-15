using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    public TextMeshProUGUI sedingText;
    public TextMeshProUGUI gusiText;
    public TextMeshProUGUI jueseText;
    private int seding = 10;
    private int gusi = 10;
    private int juese = 10;
    private int linggan = 20;
    private int lingganMax = 100;
    private int money = 0;
    // Start is called before the first frame update
    void Start()
    {
        var moneyText = transform.Find("head/linggan/text").GetComponent<TextMeshProUGUI>();
        var slider = transform.Find("head/linggan").GetComponent<Slider>();
        var monsyBtn = transform.Find("caifeng/panel/money").GetComponent<Button>();
        monsyBtn.onClick.AddListener(() =>
        {
            moneyText.text = $"��У�{linggan}     Ǯ��{money += 100}";
        });
        var xiaofeiBtn = transform.Find("caifeng/panel/xiaofei").GetComponent<Button>();
        xiaofeiBtn.onClick.AddListener(() =>
        {
            if (money >= 100)
            {
                money -= 100;
                moneyText.text = $"��У�{linggan += 1}     Ǯ��{money}";
                slider.value = (float)linggan / (float)lingganMax;
            }
        });

        var sedingBtn = transform.Find("study/panel/seding").GetComponent<Button>();
        sedingBtn.onClick.AddListener(() =>
        {
            sedingText.text = $"�趨��{seding += 1}";
        });
        var gusiBtn = transform.Find("study/panel/gusi").GetComponent<Button>();
        gusiBtn.onClick.AddListener(() =>
        {
            gusiText.text = $"���£�{gusi += 1}";
        });
        var jueseBtn = transform.Find("study/panel/juese").GetComponent<Button>();
        jueseBtn.onClick.AddListener(() =>
        {
            jueseText.text = $"��ɫ��{juese += 1}";
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
