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


        public Response GetAllTeams()
        {        
            _response = new Response();
            _response.Teams = _repo.GetAllTeams();

            if (_response.Teams != null)
            {
                _response.Success = true;
               
            }

            return _response;
        }


        public Response GetAllLeagues()
        {
            _response = new Response();
            _response.Leagues = _repo.GetAllLeagues();

            if (_response.Leagues != null)
            {
                _response.Success = true;

            }

            return _response;

        }


        public Response GetPlayersByTeamName(int teamID)
        {
            List<Player> players = _repo.GetPlayersByTeamName(teamID);
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

            if (player.PlayerID == 0)
            {
                _response.Success = true;

            }
            else
            {
                _response.Success = false;
            }

            return _response;

        }

        public Response GetAllPlayerOnAllTeams()
        {
            var players = _repo.GetAllPlayersOnAllTeams();

            _response = new Response();

            if (players != null)
            {
                _response.Success = true;
                _response.Players = players;
            }

            return _response;
        }

        public Response TradePlayer(int playerID, int newTeamID)
        {
            var players = _repo.GetAllPlayersOnAllTeams();
            var player = players.FirstOrDefault(p => p.PlayerID == playerID);
            _response = new Response();

            var tradedPlayer = _repo.TradePlayer(playerID, newTeamID);

            if (tradedPlayer.Team.TeamID == newTeamID)
            {
                _response.Success = true;
                _response.Player = tradedPlayer;
            }

            return _response;

        }

        public Response AddTeam(Team teamToAdd)
        {
            _response = new Response();

            var team = _repo.AddTeam(teamToAdd);

            if (team != null)
            {
                _response.Success = true;
                _response.Team = team;
            }
            else
            {
                _response.Success = false;
            }

            return _response;
        }

        //NOT IN REQUIREMENTS
        //public Response AddLeague(League leagueToAdd)
        //{
        //    _response = new Response();

        //    var league = _repo.AddLeague(leagueToAdd);

        //    if (league != null)
        //    {
        //        _response.Success = true;
        //        _response.League = league;
        //    }

        //    return _response;
        //}

        public Response GetTeamByID(int teamID)
        {
            _response = new Response();

            var team = _repo.GetTeamByID(teamID);

            if (team != null)
            {
                _response.Success = true;
                _response.Team = team;
            }
            else
            {
                _response.Success = false;
            }

            return _response;
        }

        public Response GetAllPositions()
        {
            _response = new Response();
            var positions = _repo.GetAllPositions();

            if (positions != null)
            {
                _response.Success = true;
                _response.Positions = positions;
            }

            return _response;
        }

        public Response GetTeamsByLeagueID(int leagueID)
        {
            _response = new Response();
            var leagueTeams = _repo.GetTeamsByLeagueID(leagueID);

            if (leagueTeams != null)
            {
                _response.Success = true;
                _response.League = leagueTeams;
            }
            else
            {
                _response.Success = false;
            }

            return _response;
        }
    }
}
