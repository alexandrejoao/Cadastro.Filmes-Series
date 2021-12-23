using System.Collections.Generic;

namespace Cadastro.Series
{
    public interface IRepositorio<T> // Esse T é um tipo generico
    {
        // método
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void excluir(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();

    }
}