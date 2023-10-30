using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Home
{
    interface Idao<T>
    {
        void create(T o);

        void update(T o, int id);

        void delete(String nom);

        T FindbyId(int id);

        List<T> findAll();
    }
}
