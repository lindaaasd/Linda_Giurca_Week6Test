using System;
using Test_Week6.Entities;

namespace Test_Week6.Repositories
{
	internal interface IRepository
	{
		 List<Agente> GetAll();

		 List<Agente> GetInfoAreaGeografica(string areaGeografica);

		 List<Agente> GetInfoAnniServizio(int anniServizio);

		 bool InserisciAgente(Agente item);

	}


}

