using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using patronesCSHARP.Builder.Entidades;

namespace patronesCSHARP.Builder.Clases
{
    interface IMaterialDiscrograficoBuilder
    {
        MaterialDiscograficoBuilder ConNombre(String nombre);
        MaterialDiscograficoBuilder TienePrecio(Double precio);
        MaterialDiscograficoBuilder EnStock(int stock);

        MaterialDiscograficoBuilder ComoGenero(Genero genero);
        MaterialDiscograficoBuilder ComoAutor(Autor autor);
        MaterialDiscograficoBuilder ComoTipoMaterialDiscografico(TipoMaterialDiscografico tipoMaterialDiscografico);
        MaterialDiscograficoBuilder ComoCanciones(List<Cancion> canciones);
    }
}
