using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Series>
    {
        private List<Series> listaseries = new List<Series>();

        public void Atualiza(int id, Series objeto)
        {
            listaseries[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaseries[id].Excluir();
        }

        public void Insere(Series objeto)
        {
            listaseries.Add(objeto);
        }

        public List<Series> Lista()
        {
            return listaseries;
        }

        public int ProximoId()
        {
            return listaseries.Count;
        }

        public Series RetornaPorId(int id)
        {
            return listaseries[id];
        }
    }
}