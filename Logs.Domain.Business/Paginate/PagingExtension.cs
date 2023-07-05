using Logs.Domain.Business.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logs.Domain.Business.Paginate
{
    public class PagingExtension<T> : List<T>
    {
        /// <summary>
        /// Metodo que se encarga de devolver los datos filtrados de acuerdo al número de pagína.
        /// </summary>
        /// <param name="query">Lista con los datos a filtrar</param>
        /// <param name="pageIndex">Indica el número de la pagína a posicionar</param>
        /// <param name="pageSize">Indica la cantidad de datos a mostrar por pagína</param>
        /// <returns></returns>
        public static PaginatedListDTO<T> GetPaged(List<T> query, int page, int take)
        {
            var originalPages = page;

            page--;
            if (page > 0)
                page *= take;

            var result = new PaginatedListDTO<T>()
            {
                Data = query.Skip(page).Take(take).ToList(),
                Total = query.Count(),
                Page = originalPages
            };

            if (result.Total > 0)
            {
                result.TotalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(result.Total) / take));
            }

            return result;
        }
    }
}
