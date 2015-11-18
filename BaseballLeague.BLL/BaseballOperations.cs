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

        public Response GetPlayersByTeamName(string teamName)
        {
            List<Player> players = _repo.GetPlayersByTeamName(teamName);
            _response = new Response();

            if (players != null)
            {
                _response.Success = true;
                _response.Players = players;
            }
            return _response;
        }


        public Response GetPlayerByID(int playerID)
        {
            var player = _repo.GetPlayerByID(playerID);
            _response = new Response();

            if (player != null)
            {
                _response.Success = true;
                _response.Player = player;

            }

            return _response;
        }


        public Response CreatePlayer(Player p)
        {
            var player = _repo.CreatePlayer(p);

            _response = new Response();

            if (player != null)
            {
                _response.Success = true;
                _response.Player = player;
            }

            return _response;
        }

        public Response RemovePlayerByID(int playerID)
        {
            var player = _repo.RemovePlayer(playerID);

            _response = new Response();

            if (player == null)
            {
                _response.Success = true;

            }
            else
            {
                _response.Success = false;
            }

            return _response;

        }



    }
}
