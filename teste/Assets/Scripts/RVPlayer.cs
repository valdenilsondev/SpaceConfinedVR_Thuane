using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(AudioSource))]
public class RVPlayer : MonoBehaviour
{

	public static RVPlayer instance;

	public Camera cameraRayCast;
	public float speed = 0.7f;
	public int distanceToMove = 10;
	public GameObject arrowToMove;
	public AudioClip clickASound;

	private AudioSource audioSource;

	private RaycastHit hit;
	private Vector3 starPoint;
	private Vector3 endPoint;
	public float starTime;
	public float jorneyLength;
	private bool flagStop = false;



	//	public GameObject painelInformacao;

	public GameObject nome;

	public Image imgGaze;
	public float totalTime = 2;
	public float gvrTime;
	public bool gvrStatus;

	public float tempoesperar;

	public bool isDestino;

	private Rigidbody rbPlayer;
	public float movimentoX;

	public bool verificarDirecao;

	public Transform direcaoMovemento;

	public bool animacao;



	public Transform posicaoFinal;


	public GameObject objetoDetectado;

	public GameObject posicaoCadeado;

	public GameObject CadeadoSeguranca;


	public GameObject setaDesligar;




	public GameObject desligar;

	public GameObject trasicaoInicial;

	public GameObject posicaoNaoOpere;

	// Use this for initialization
	void Start()
	{

		audioSource = GetComponent<AudioSource>();
		rbPlayer = GetComponent<Rigidbody>();







	}



	// Update is called once per frame
	void Update()
	{



		float movimento = Input.GetAxisRaw("Vertical");
		float movim = Input.GetAxis("Submit");




		/*if (Input.GetButton("Vertical") || movimento == 1 || movim == 1)
		{
			Debug.Log("Apertar botao");
			rbPlayer.velocity = direcaoMovemento.forward*2;
		}
		if (Input.GetKeyUp(KeyCode.W) || movimento == 0)
		{
			rbPlayer.velocity = direcaoMovemento.forward * 0;
		}
		*/

		Ray ray = cameraRayCast.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));


		if (gvrStatus)
		{
			gvrTime += Time.deltaTime;

			imgGaze.fillAmount = gvrTime / totalTime;


		}


		if (Physics.Raycast(ray, out hit, distanceToMove))
		{

			float scaleArrow = Vector3.Distance(hit.transform.position, this.transform.position) / 13000;

			arrowToMove.transform.localScale = new Vector3(scaleArrow, scaleArrow, scaleArrow);
			arrowToMove.transform.position = hit.transform.position;


		}

		Debug.DrawRay(ray.origin, ray.direction * distanceToMove, Color.red, 1);


		if (Physics.Raycast(ray, out hit, distanceToMove))
		{


			if (imgGaze.fillAmount == 1 && hit.transform.tag == "Cadeado" )
			{

				audioSource.clip = clickASound;
				audioSource.Play();

				starPoint = transform.position;

				endPoint = hit.transform.position;

				starTime = Time.time;

				jorneyLength = Vector3.Distance(starPoint, endPoint);

				flagStop = true;
				

				hit.collider.gameObject.transform.position = posicaoCadeado.transform.position;


			}
			else

			if (hit.transform.tag == "cadeadoSeguranca")
			{

				//audioSource.clip = clickASound;
				//audioSource.Play();

				//starPoint = transform.position;

				//endPoint = hit.transform.position;

				//starTime = Time.time;

				//jorneyLength = Vector3.Distance(starPoint, endPoint);

				//flagStop = true;


				hit.collider.gameObject.transform.position = CadeadoSeguranca.transform.position;
				hit.collider.gameObject.transform.rotation = CadeadoSeguranca.transform.rotation;


			}
			
			/*else 
			if (imgGaze.fillAmount == 1 && hit.transform.tag == "cadeadoSeguranca")
			{

				//audioSource.clip = clickASound;
				//audioSource.Play();

				//starPoint = transform.position;

				//endPoint = hit.transform.position;

				//starTime = Time.time;

				//jorneyLength = Vector3.Distance(starPoint, endPoint);

				//flagStop = true;
				

				hit.collider.gameObject.transform.position = CadeadoSeguranca.transform.position;

				hit.collider.gameObject.transform.rotation  = CadeadoSeguranca.transform.rotation;


			}*/

			else 
			if (imgGaze.fillAmount == 1 && hit.transform.tag == "AllowerPosition" && isDestino == false)
			{

				audioSource.clip = clickASound;
				audioSource.Play();

				starPoint = transform.position;

				endPoint = hit.transform.position;

				starTime = Time.time;

				jorneyLength = Vector3.Distance(starPoint, endPoint);

				flagStop = true;
				isDestino = true;


			}/*
			else if (hit.transform.tag == "naoOpere")
			{

				//audioSource.clip = clickASound;
				//audioSource.Play();

				//starPoint = transform.position;

				//endPoint = hit.transform.position;

				//starTime = Time.time;

				//jorneyLength = Vector3.Distance(starPoint, endPoint);

				//flagStop = true;


				hit.collider.gameObject.transform.position = posicaoNaoOpere.transform.position;
				hit.collider.gameObject.transform.rotation = posicaoNaoOpere.transform.rotation;


			}*/


			//objetoDetectado.transform.position = posicaoCadeado.transform.position;

		}
		else
        {
			objetoDetectado = null;

		}


		if (Physics.Raycast(ray, out hit, distanceToMove))
		{




			if (imgGaze.fillAmount == 1 && hit.transform.tag == "quadro")
			{


			}



			/*

			if (Input.GetMouseButtonDown(0)) {

				if (Physics.Raycast(ray, out hit, distanceToMove)) {

					if (hit.transform.tag == "AllowerPosition") {

						audioSource.clip = clickASound;
						audioSource.Play();

						starPoint = transform.position;

						endPoint = hit.transform.position;

						starTime = Time.time;

						jorneyLength = Vector3.Distance(starPoint, endPoint);

						flagStop = true;
					}



		}*/


			if (flagStop)
			{

				float distConverd = (Time.time - starTime) * speed;

				float fracJourney = distConverd / jorneyLength;

				Vector3 move = Vector3.Lerp(starPoint, endPoint, fracJourney);

				this.transform.position = move;


				if (this.transform.position == endPoint)
				{


					flagStop = false;
				}


			}



		}




		/*
		public void painelInfo() {

			audioSource.clip = clickASound;
			audioSource.Play();

			starPoint = transform.position;

			endPoint = hit.transform.position;

			starTime = Time.time;

			jorneyLength = Vector3.Distance(starPoint, endPoint);

			flagStop = true;


		}
		*/


		if (animacao == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, posicaoFinal.transform.position, 0.5f * Time.deltaTime);

			trasicaoInicial.SetActive(false);
			
		}if(transform.position == posicaoFinal.transform.position)
        {
			animacao = false;
        }


	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "transporteConfinado")
		{

			//	transform.position = posicaoFinal.transform.position;

			animacao = true;

			setaDesligar.SetActive(false);

			//desligar.SetActive(false);
			


		}


	}

	public void GazeON()
	{

		gvrStatus = true;

	}
	public void GVROFF()
	{

		gvrStatus = false;
		gvrTime = 0;
		imgGaze.fillAmount = 0;
		isDestino = false;


	}



}



