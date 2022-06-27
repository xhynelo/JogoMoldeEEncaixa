using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecionaVertices : MonoBehaviour
{
    public RectTransform selecaoComQuadrado;

    public Canvas canvasUIElement;

    Vector3 squareStartPos;
    Vector3 squareEndPos;

    bool hasCreatedSquare;

    Rect retangulo;

    public GameObject objetoInterativo;
    public bool podeSelecionar = true;
    // Start is called before the first frame update
    void Start()
    {
        selecaoComQuadrado.gameObject.SetActive(false);   

        float CanvasWidth = canvasUIElement.GetComponent<RectTransform>().rect.width;
        float CanvasHeight = canvasUIElement.GetComponent<RectTransform>().rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        if(podeSelecionar)
        {
            SelectUnits();
        }
    }

    void SelectUnits(){
        
        bool isHoldingDown = false;

        if(Input.GetButtonDown("Seleciona")){
            squareStartPos = Input.mousePosition;
        }

        if(Input.GetButton("Seleciona")){
            isHoldingDown = true;
        }

        if (isHoldingDown){
            selecaoComQuadrado.gameObject.SetActive(true);
            squareEndPos = Input.mousePosition;

            DisplaySquare();
        }

        if(Input.GetButtonUp("Seleciona")){
            foreach(Transform child in objetoInterativo.transform){
                child.SendMessage("ativaVertice", retangulo);
            }
            // objetoInterativo.SendMessage("ativaVertice", retangulo);
            selecaoComQuadrado.gameObject.SetActive(false);
        }
    }

    void DisplaySquare(){
        float CanvasWidth = canvasUIElement.GetComponent<RectTransform>().rect.width;
        float CanvasHeight = canvasUIElement.GetComponent<RectTransform>().rect.height;

        Vector3 StartPosCanvas = new Vector3((squareStartPos.x / Screen.width) * CanvasWidth, (squareStartPos.y / Screen.height) * CanvasHeight, 0);
        Vector3 EndPosCanvas = new Vector3((squareEndPos.x / Screen.width) * CanvasWidth, (squareEndPos.y / Screen.height) * CanvasHeight, 0);
        Vector3 middle = ((StartPosCanvas + EndPosCanvas) / 2f) - new Vector3(CanvasWidth/2, CanvasHeight/2, 0);

        selecaoComQuadrado.localPosition = middle;
        float sizeX = Mathf.Abs(squareStartPos.x - squareEndPos.x);
        float sizeY = Mathf.Abs(squareStartPos.y - squareEndPos.y);
        float sizeSquareX = Mathf.Abs(StartPosCanvas.x - EndPosCanvas.x);
        float sizeSquareY = Mathf.Abs(StartPosCanvas.y - EndPosCanvas.y);

        selecaoComQuadrado.sizeDelta = new Vector2(sizeSquareX, sizeSquareY);
        retangulo = new Rect(
            Mathf.Min(squareStartPos.x, squareEndPos.x),
            Mathf.Min(squareStartPos.y, squareEndPos.y), sizeX, sizeY
            );
        hasCreatedSquare = true;

    }
}
