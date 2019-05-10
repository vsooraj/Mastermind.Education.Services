using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Education.Services.ViewModels
{
    public class ResponseViewModel<T>
    {
        public T Result { get; set; }
        public int StatusCode { get; set; }
        public string Messsage { get; set; }
    }
}
