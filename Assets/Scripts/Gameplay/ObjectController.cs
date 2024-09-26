using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    const string MOVABLE_TAG = "Movable";
    private Camera cam;
    private bool isDragging = false;
    private GameObject selectedObject;
    public GameObject boxUnselected;
    public GameObject boxSelected;
    public LayerMask selectableLayer; // Camada que define os objetos selecionáveis

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, selectableLayer);

        if (hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;

            // Se o objeto for selecionável e o botão esquerdo for pressionado
            if (Input.GetMouseButtonDown(0) && hitObject.CompareTag(MOVABLE_TAG))
            {
                isDragging = true;
                boxSelected.SetActive(true);
                boxUnselected.SetActive(false);
            }
        }

        // Se o botão esquerdo estiver pressionado, mover o objeto selecionado
        if (isDragging && selectedObject != null)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            selectedObject.transform.position = new Vector2(mousePos.x, mousePos.y);

            // Soltar o objeto ao soltar o botão esquerdo
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                boxSelected.SetActive(false);
                boxUnselected.SetActive(true);
                selectedObject = null;
            }
        }
    }
}
