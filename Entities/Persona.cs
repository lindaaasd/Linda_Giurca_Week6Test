using System;
namespace Test_Week6.Entities
{
	public abstract class Persona
	{

		//L’agente deriva da un’astrazione di persona.La persona ha le seguenti caratteristiche: - Nome
		//- Cognome
		//- Codice fiscale

		public string Nome { get; set; }
		public string Cognome { get; set; }
		public string CodiceFiscale { get; set; }


		public Persona()
		{
		}

		public Persona(string nome, string cognome, string codiceFiscale)
        {
			Nome = nome;
			Cognome = cognome;
			CodiceFiscale = codiceFiscale;
        }
	}
}

