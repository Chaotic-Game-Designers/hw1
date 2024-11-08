using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject loadingCanvas;
    public GameObject gameCanvas;

    // Start is called before the first frame update
    void Start()
    {
        ShowMenuCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMenuCanvas()
    {
        menuCanvas.SetActive(true);
        loadingCanvas.SetActive(false);
        gameCanvas.SetActive(false);
    }

    public void ShowLoadingCanvas()
    {
        menuCanvas.SetActive(false);
        loadingCanvas.SetActive(true);
        gameCanvas.SetActive(false);
    }

    public void ShowGameCanvas()
    {
        menuCanvas.SetActive(false);
        loadingCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }
}
