// See https://aka.ms/new-console-template for more information
using Test_Week6.Entities;
using Test_Week6.Repositories;

Console.WriteLine("Hello, World!");

//1.Quali sono i paradigmi della programmazione ad oggetti?
//a) Ereditarietà b) Interfacce e) Polimorfismo g) Incapsulamento

//2.Indicare la / le risposte corrette
//b) Un metodo di tipo abstract non è dotato di implementazione
//d) La classe che eredita un metodo di tipo abstract deve implementarne il funzionamento

//3.Data una classe padre contenente il metodo “public virtual void Stampa()”, quale / i metodi può contenere la classe figlia?
//c) public override void Stampa()

//Esercitazione pratica
// Implementare una Console App che tramite menù permetta di:
//-Mostrare tutti gli agenti di polizia
//- Scelta un’area geografica, mostrare gli agenti assegnati a quell’area
//- Scelti gli anni di servizio, mostrare gli agenti con anni di servizio
//maggiori o uguali rispetto all’input
//- Inserire un nuovo agente solo se non è già presente nel database

bool continua = true;
int scelta;
RepositoryAgenteDB repoAgenti = new RepositoryAgenteDB();

do
{
    scelta = PrintMenu();
    switch (scelta)
    {
        case 1:
            //stampa tutti
            StampaAgenti();
            break;
        case 2:
            //stampa per area geografica
            StampaAreaGeografica();
            break;
        case 3:
            //stampa per anni di servizio
            StampaAnniServizio();
            break;
        case 4:
            //inserimento nuovo agente
            InserisciNuovoAgente();
            break;
        default:
            continua = false;
            Console.WriteLine("Arrivederci");
            break;

    }

} while (continua);

int PrintMenu()
{
    Console.WriteLine("1. Stampa tutti gli agenti di polizia presenti ");
    Console.WriteLine("2. Stampa tutti gli agenti disponibili per area geografica ");
    Console.WriteLine("3. Stampa tutti gli agenti disponibii in base agli anni di servizio ");
    Console.WriteLine("4. Inserire un agente nuovo del db, solo se non è già presente ");
    Console.WriteLine("5. Esci ");
    Console.WriteLine("Scelta/> ");
    Int32.TryParse(Console.ReadLine(), out int scelta);
    return scelta;
}

void StampaAgenti()
{
    Console.WriteLine("Gli agenti disponibili sono i seguenti:");
    var agenti = repoAgenti.GetAll();
    List<Agente> ListaAgenti = new();
    ListaAgenti.AddRange(agenti);
   
    foreach (var agente in ListaAgenti)
    {
        Console.WriteLine(agente.GetInfo());
    }

}

void StampaAreaGeografica()
{
    Console.WriteLine("Di quale area geografica vuoi vedere gli agenti? ( nord / est / vest / sud ) ");
    string areaG = Console.ReadLine();

    var agentiArea = repoAgenti.GetInfoAreaGeografica(areaG);
    List<Agente> AgentiPerAreaGeografica = new();
    AgentiPerAreaGeografica.AddRange(agentiArea);

    foreach (var agente in AgentiPerAreaGeografica)
    {
        if(areaG == agente.AreaGeografica)
        {   
            Console.WriteLine(agente.GetInfo());
        }
    }
}

void StampaAnniServizio()
{
    Console.WriteLine("Al meno quanti anni di seniority devono avere gli agenti? ");
    Int32.TryParse(Console.ReadLine(), out int anniServizio);

    var agentiAnniAttivita = repoAgenti.GetInfoAnniServizio(anniServizio);
    List<Agente> AgentiPerAnniAttivita = new();
    AgentiPerAnniAttivita.AddRange(agentiAnniAttivita);

    foreach (var agente in AgentiPerAnniAttivita)
    {
        Console.WriteLine(agente.GetInfo());
    }
}

void InserisciNuovoAgente()
{
    Console.WriteLine("Inserisci il nome dell'agente ");
    string nomeAgente = Console.ReadLine();

    Console.WriteLine("Inserisci il cognome dell'agente");
    string cognomeAgente = Console.ReadLine();

    Console.WriteLine("Inserisci il codice fiscale dell'agente (16 caratteri) ");
    string codiceFiscaleAgente = Console.ReadLine();

    Console.WriteLine("In quale area geografica può sorvegliare? ");
    string areaGeograficaAgente = Console.ReadLine();

    Console.WriteLine("In che anno ha iniziato l'attività? ");
    Int32.TryParse(Console.ReadLine(), out int annoInizioAttivitaAgente);

    var verificaAgente = repoAgenti.VerificaAgenteEsistente(codiceFiscaleAgente);
    if (verificaAgente == false)
    {

    Agente nuovoAgente = new Agente();
    nuovoAgente.Nome = nomeAgente;
    nuovoAgente.Cognome = cognomeAgente;
    nuovoAgente.CodiceFiscale = codiceFiscaleAgente;
    nuovoAgente.AreaGeografica = areaGeograficaAgente;
    nuovoAgente.AnnoInizioAttivita = annoInizioAttivitaAgente;

    var nuovoAgenteDB = repoAgenti.InserisciAgente(nuovoAgente);
    } else
    {
        Console.WriteLine("L'agente è già inserito, inserisci un'altro");
    }


}

