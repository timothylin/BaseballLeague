using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseballLeague.DataLayer;
using BaseballLeague.Models;

namespace BaseballLeague.BLL
{
    public class BaseballOperations
    {
        private BaseballRepository _repo = new BaseballRepository();
        private Response _response;

        public BaseballOperations()
        {
            _response = new Response();
        }
    }
}
