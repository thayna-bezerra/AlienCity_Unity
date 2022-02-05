using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour 
{
	[Header("Move Player")] 
	[Space]
	public float MoveSpeed;
	public float RotationSpeed;
	CharacterController cc;
	private Animator anim;
	protected Vector3 gravidade = Vector3.zero;
	protected Vector3 move = Vector3.zero;
	private bool jump = false;
	public Joystick joystick;

	[Space(10)]

	[Header("ENERGIA")]
	public Slider barraDeEnergia;

	public int energiaPlayer = 5;
	public int energiaAtual;
	[Space]

	[Header("VIDA")]
	public int VidaPlayer;
	public GameObject[] VidasHUD = new GameObject[3];

	[Space]
	[Header("Condição Vitória/Derrota")]
	public int isVictory = 0; //0 - perdeu // 1-ganhou

	void Start()
	{
		cc = GetComponent<CharacterController> ();
		anim = GetComponent<Animator>();
		anim.SetTrigger("Parado");

		VidaPlayer = 3;
		VidaPlayer = PlayerPrefs.GetInt("VidaOnLoad");

		energiaAtual = energiaPlayer;
		barraDeEnergia.maxValue = energiaPlayer;

	}

	void Update()
	{
		PlayerPrefs.SetInt("Victory", isVictory);

        if (energiaAtual == 0)
        {
			energiaAtual = 5;
			VidaPlayer--;
			
			PlayerPrefs.SetInt("VidaOnLoad", VidaPlayer);


			SceneManager.LoadScene(SceneManager.GetActiveScene().name);

			if(VidaPlayer == 0)
            {
				isVictory = 0;
				SceneManager.LoadScene("Terminou");
			}
		}

		barraDeEnergia.value = energiaAtual;

		Vector3 a = Input.GetAxis ("Vertical") * transform.TransformDirection (Vector3.forward) * MoveSpeed;
		transform.Rotate (new Vector3 (0, Input.GetAxis ("Horizontal") * RotationSpeed * Time.deltaTime, 0));


		Vector3 move = joystick.Vertical * transform.TransformDirection (Vector3.forward) * MoveSpeed;
		transform.Rotate (new Vector3 (0, joystick.Horizontal * RotationSpeed * Time.deltaTime, 0));
		
		if (!cc.isGrounded) {
			gravidade += Physics.gravity * Time.deltaTime;
		} 
		else 
		{
			gravidade = Vector3.zero;
			if(jump)
			{
				gravidade.y = 6f;
				jump = false;
			}
		}
		move += gravidade;
		cc.Move (move* Time.deltaTime);

		Anima();
		HUDdisplay();
	}
	 
	void Anima()
	{
		if (!Input.anyKey && Input.GetAxis("Vertical") == 0)
		{
			anim.SetTrigger("Parado");
		} 

		else { anim.SetTrigger("Corre"); }
	}

	public void btnJump()
	{
		anim.SetTrigger("Pula");
		jump = true;
	}

	public void resetarPlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
		VidaPlayer = 3;
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "pedra")
		{
			isVictory = 1;
			SceneManager.LoadScene("Terminou");
		}
	}

	public void HUDdisplay()
	{
		switch (VidaPlayer)
		{
			case 3:
				VidasHUD[0].SetActive(false); //com uma vida desativado
				VidasHUD[1].SetActive(false); //com duas vidas desativado
				VidasHUD[2].SetActive(true);  //com 3 vidas
				break; 

			case 2:
				VidasHUD[0].SetActive(false);
				VidasHUD[1].SetActive(true);
				VidasHUD[2].SetActive(false);
				break;

			case 1:
				VidasHUD[0].SetActive(true);
				VidasHUD[1].SetActive(false);
				VidasHUD[2].SetActive(false);
				break;

			default:
				VidasHUD[0].SetActive(false);
				VidasHUD[1].SetActive(false);
				VidasHUD[2].SetActive(false);
				break;
		}
	}
}
