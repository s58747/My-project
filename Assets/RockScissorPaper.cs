using UnityEngine;
using TMPro;

public class RockScissorPaper : MonoBehaviour
{
    [SerializeField] private TMP_Text win;
    [SerializeField] private TMP_Text userText;
    [SerializeField] private TMP_Text robotText;
    [SerializeField] private TMP_Text status;

    bool gameOngoing = false;

    private Color originalColor;
    private Renderer selectedRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        status.text = "Click the object to choose.";
        win.text = "";
        userText.text = "";
        robotText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R)) {
            status.text = "Click the object to choose.";
            win.text = "";
            userText.text = "";
            robotText.text = "";

            gameOngoing = false;

            if (selectedRenderer != null) {
                selectedRenderer.material.color = originalColor;
            }
        }

        if (!gameOngoing && Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit)) {

                string user = hit.collider.gameObject.name;
                Renderer renderer = hit.collider.GetComponent<Renderer>();
                selectedRenderer = renderer;

                int robot = Random.Range(0, 3);

                if (user == "Rock") {
                    originalColor = hit.collider.GetComponent<Renderer>().material.color;

                    gameOngoing = true;
                    status.text = "";
                    
                    renderer.material.color = Color.red;
                    userText.text = "Your choice: Rock";

                    if (robot == 0) {
                        robotText.text = "Robot's choice: Rock";
                        win.text = "Draw!";
                    } else if (robot == 1) {
                        robotText.text = "Robot's choice: Scissor";
                        win.text = "You win!";
                    } else {
                        robotText.text = "Robot's choice: Paper";
                        win.text = "You lose!";
                    }

                    status.text = "Press R to restart.";
                }

                else if (user == "Scissor") {
                    originalColor = hit.collider.GetComponent<Renderer>().material.color;

                    gameOngoing = true;
                    status.text = "";

                    renderer.material.color = Color.red;
                    userText.text = "Your choice: Scissor";

                    if (robot == 0) {
                        robotText.text = "Robot's choice: Rock";
                        win.text = "You lose!";
                    } else if (robot == 1) {
                        robotText.text = "Robot's choice: Scissor";
                        win.text = "Draw!";
                    } else {
                        robotText.text = "Robot's choice: Paper";
                        win.text = "You win!";
                    }

                    status.text = "Press R to restart.";
                }

                else if (user == "Paper") {
                    originalColor = hit.collider.GetComponent<Renderer>().material.color;

                    gameOngoing = true;
                    status.text = "";

                    renderer.material.color = Color.red;
                    userText.text = "Your choice: Paper";

                    if (robot == 0) {
                        robotText.text = "Robot's choice: Rock";
                        win.text = "You win!";
                    } else if (robot == 1) {
                        robotText.text = "Robot's choice: Scissor";
                        win.text = "You lose!";
                    } else {
                        robotText.text = "Robot's choice: Paper";
                        win.text = "Draw!";
                    }

                    status.text = "Press R to restart.";
                }

            }
        }
    }
}
