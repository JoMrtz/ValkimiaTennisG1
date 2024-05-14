
using System.Net.NetworkInformation;
using ValkimiaTennisG1.Models.Entities;
using ValkimiaTennisG1.Models.Request;
using ValkimiaTennisG1.Models.Response;

namespace ValkimiaTennisG1.Mappers.Players
{
    public static class playerMapper
    {
        public static Player ToPlayerMan(this PlayerRequest newPlayer)
        { 
            return new Player  
            {
               
                GenderId = newPlayer.GenderId,
                Name = newPlayer.Name,
                Ability = newPlayer.Ability,
                Strength = newPlayer.Strength,
                Speed = newPlayer.Speed,
                ReactionTime = null,
                

            };

        }
        public static Player ToPlayerWoman(this PlayerRequest newPlayer)
        {
            return new Player
            {
              
                GenderId = newPlayer.GenderId,
                Name = newPlayer.Name,
                Ability = newPlayer.Ability,
                Strength = null,
                Speed = null,
                ReactionTime = newPlayer.ReactionTime,


            };

        }

        public static PlayersResponse ToPlayersResponse(this Player player)
        {
            return new PlayersResponse
            {
                Name = player.Name,
                Ability = player.Ability,
            };
        }
    }
}
