using System;
using Test_Week6.Repositories;

namespace Test_Week6.Entities
{
	public class Agente : Persona
	{
		//		L’agente ha le seguenti caratteristiche: - Nome
		//- Cognome
		//- Codice fiscale
		//- Area geografica
		//- Anno di inizio attività

		public string AreaGeografica { get; set; }
		public int AnnoInizioAttivita { get; set; }
		public int AnniAttivita { get { return CalcolaAnniServizio(); } }
	

		public Agente()
		{
		}

		public Agente(string nome, string cognome, string codiceFiscale, string areaGeografica, int annoInizioAttivita):base(nome, cognome, codiceFiscale)
        {
			AreaGeografica = areaGeografica;
			AnnoInizioAttivita = annoInizioAttivita;
        }

		public int CalcolaAnniServizio()
        {
			int anniServizio = DateTime.Now.Year - AnnoInizioAttivita;

			return anniServizio;
        }

		public string GetInfo()
        {
			return $"Agente: {Nome} {Cognome}, CF: {CodiceFiscale} \n" +
				$"Area geografica: {AreaGeografica} \n" +
                $"Iniziata l'attività nel {AnnoInizioAttivita}";
        }

    }
}

