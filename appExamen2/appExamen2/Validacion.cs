using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace appExamen2
{
    class Validacion
    {
        public Boolean validarLetra(int e)
        {
            if ((e < 65 || e > 90) && (e < 97 || e > 122)
                && e != 8 && e != 13 && e != 32 &&
                e != 241 && e != 209 &&
                e != 250 && e != 233 &&
                e != 237 && e != 243 &&
                e != 225 && e != 225 &&
                e != 193 && e != 201 &&
                e != 205 && e != 218)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean validarNumero(int e)
        {
            if ((e < 48 || e > 57) && e != 13 && e != 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean validarDecimal(int e)
        {
            if ((e < 48 || e > 57) && e != 8 && e != 46)
            { return true; }
            else
            { return false; }
        }

        public Boolean validarDecimal(int e, String cadena)
        {
            int h = cadena.IndexOf(".");//ubica la posicion de un punto decimal en la cadena
            if ((e < 48 || e > 57) && e != 8 && e != 46)
            { return true; }
            else
            {
                if (e == 46)//si es punto decimal 
                {
                    if (cadena.Length == 0)//no puede empezar por punto
                    { return true; }
                    else//solo una vez debe estar un punto decimal
                    {
                        if (h > -1)//si la posición del punto decimal es menor a 0 no hay punto decimal aún
                        { return true; }
                        else
                        { return false; }
                    }
                }
                else//si es un digito (numero)
                {
                    if (h >= 0 && e != 8)//si la ubicación del punto de decimal es mayor o igual a cero y la tecla es un numero
                    {
                        String g = cadena.Substring(h); //subcadena desde el punto decimal hacia la derecha
                        int l = g.Length;//longitud de la subcadena
                        if (l > 2)//si es mayor a 2 es porque esta màs de 2 decimales
                        { return true; }
                        else
                        { return false; }
                    }
                    else
                    { return false; }
                }
            }
        }
    }
}
