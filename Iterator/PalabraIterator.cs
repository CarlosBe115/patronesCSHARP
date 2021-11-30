using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patronesCSHARP.Iterator
{
    public class PalabraIterator : IEnumerator
    {
        char[] _palabra;
        int _pos;

        public PalabraIterator(string palabra)
        {
            _palabra = palabra.ToCharArray();
        }

        public object Current => _palabra[_pos];

        public bool MoveNext()
        {
            if (_pos < _palabra.Length - 1)
            {
                _pos++;
                return true;
            }
            else
            {
                return false;
            }

        }

        public void Reset()
        {
            _pos = -1;
        }
    }
}
