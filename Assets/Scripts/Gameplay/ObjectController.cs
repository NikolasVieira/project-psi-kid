using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {
    const string MOVABLE_TAG = "Movable";
    private Camera cam;
    private bool isDragging = false;
    private GameObject selectedObject;
    private Rigidbody2D selectedObjectRb;
    public GameObject boxUnselected;
    public GameObject boxSelected;
    public LayerMask selectableLayer; // Camada que define os objetos selecion�veis
    private Vector3 offset; // Para ajustar a posi��o do mouse em rela��o � caixa

    void Start() {
        cam = Camera.main;
        boxSelected.SetActive(false);  // Garantir que a caixa selecionada comece desativada
    }

    void Update() {
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, selectableLayer);

        if (hit.collider != null) {
            GameObject hitObject = hit.collider.gameObject;

            // Se o objeto for selecion�vel e o bot�o esquerdo for pressionado
            if (Input.GetMouseButtonDown(0) && hitObject.CompareTag(MOVABLE_TAG)) {
                isDragging = true;
                selectedObject = hitObject;  // Atribui o objeto selecionado
                selectedObjectRb = selectedObject.GetComponent<Rigidbody2D>(); // Pega o Rigidbody2D do objeto

                // Calcular o deslocamento do mouse em rela��o � posi��o da caixa para manter o arrasto suave
                offset = selectedObject.transform.position - cam.ScreenToWorldPoint(Input.mousePosition);

                // Desativar a gravidade temporariamente durante o arrasto
                selectedObjectRb.gravityScale = 0f;
                selectedObjectRb.velocity = Vector2.zero;  // Para parar qualquer movimento anterior
                boxSelected.SetActive(true);  // Ativa a visualiza��o da caixa selecionada
                boxUnselected.SetActive(false); // Desativa a visualiza��o da caixa n�o selecionada
            }
        }

        // Se o bot�o esquerdo estiver pressionado, mover o objeto selecionado
        if (isDragging && selectedObject != null && selectedObjectRb != null) {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition) + offset;
            Vector2 targetPosition = new Vector2(mousePos.x, mousePos.y);

            // Movimentar o objeto com uma velocidade controlada para manter a f�sica
            selectedObjectRb.MovePosition(targetPosition);

            // Soltar o objeto ao soltar o bot�o esquerdo
            if (Input.GetMouseButtonUp(0)) {
                isDragging = false;
                selectedObjectRb.gravityScale = 1f; // Reativar a gravidade
                boxSelected.SetActive(false); // Volta para o estado n�o selecionado
                boxUnselected.SetActive(true); // Mostra a caixa n�o selecionada novamente
                selectedObject = null;  // Limpa a refer�ncia ao objeto selecionado
                selectedObjectRb = null;  // Limpa a refer�ncia ao Rigidbody2D
            }
        }
    }
}
