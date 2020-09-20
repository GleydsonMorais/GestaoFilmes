using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoFilmesAPI.Data.Helpers
{
    public class QueryResult<T>
    {
        public bool Succeeded { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }
    }
}
