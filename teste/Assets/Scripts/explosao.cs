using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosao : MonoBehaviour {


	public GameObject explosaoSFX;
	public float tempoInicial;
	public float tempo;
	public float tempoAtualizado;
	public bool acionar;

	public Transform Player;
	public Transform ponto;
	public float distancia;
	public bool acionaTempo;
	// Use this for initialization
	void Start () {
		//acionar = false;
	}
	
	// Update is called once per frame
	void Update () {


		




		if (Player.transform.position.x < 0 && acionaTempo == false) {

			acionaTempo = true;
		}

		if (acionaTempo == true) {
			tempo += Time.deltaTime;

			tempoAtualizado = tempoInicial - tempo;


			acionar = true;
		}


		if (tempoAtualizado <= 0 && acionar ==true) {
			explosaoSFX.SetActive(true);
			acionar = false;
        }

	}

}
