using System.Collections;
using UnityEngine;

namespace PuzzleTogetherCheat
{
	public class Cheats : MonoBehaviour
	{
		Rect windowRect = new Rect(0f, 0f, 500f, 500f);

        bool menuOpened = true;
		JigsawPuzzle? jigsawPuzzle;
		GameObject? activePiece;

		public void Start()
		{
            jigsawPuzzle = FindObjectOfType<JigsawPuzzle>();
        }


		public void Update()
		{
			if (Input.GetKeyDown(KeyCode.P))
			{
				menuOpened = !menuOpened;
			}

			if (jigsawPuzzle is not null)
			{
				activePiece = jigsawPuzzle.GetActivePiece();
			}
        }

		public void cheatMenu(int windowID)
		{
            if (GUILayout.Button("solve"))
            {
				if (jigsawPuzzle is not null)
				{
					jigsawPuzzle.CompletePuzzle();
				}
            }

            GUILayout.Label("active piece: ");
            if (activePiece is not null)
            {
                Vector3 vec3 = activePiece.transform.position;
				GUILayout.Label(activePiece.name);
				GUILayout.Label(vec3.x.ToString());
				GUILayout.Label(vec3.y.ToString());
				GUILayout.Label(vec3.z.ToString());
            }

            GUI.DragWindow(new Rect(0, 0, windowRect.width, windowRect.height));
        }

		public void OnGUI()
		{
			if (menuOpened)
			{
				windowRect = GUI.Window(0, windowRect, cheatMenu, "Puzzle Together Cheat");
			}
        }
    }
}
