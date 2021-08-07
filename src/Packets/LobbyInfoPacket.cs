using System;
using System.Collections.Generic;
using TimHanewich.Toolkit;

namespace Codemasters.F1_2021
{
    public class LobbyInfoPacket : Packet
    {
        public byte NumberOfPlayers { get; set; }
        public LobbyInfoData[] LobbyPlayers { get; set; }

        public override void LoadBytes(byte[] bytes)
        {
            ByteArrayManager BAM = new ByteArrayManager(bytes);

            //Load header
            base.LoadBytes(BAM.NextBytes(24));

            //Get number of players
            NumberOfPlayers = BAM.NextByte();

            //Get lobby players
            List<LobbyInfoData> ToAdd = new List<LobbyInfoData>();
            for (int i = 0; i < 22; i++)
            {
                ToAdd.Add(LobbyInfoData.Create(BAM.NextBytes(53)));
            }
            LobbyPlayers = ToAdd.ToArray();

        }
        
        public class LobbyInfoData
        {
            public bool AiControlled { get; set; }
            public Team TeamId { get; set; }
            public byte Nationality { get; set; }
            public string Name { get; set; }
            public byte CarNumber {get; set;}
            public ReadyStatus ReadyStatus { get; set; }

            public static LobbyInfoData Create(byte[] bytes)
            {
                LobbyInfoData ToReturn = new LobbyInfoData();

                ByteArrayManager BAM = new ByteArrayManager(bytes);

                //AI controlled
                ToReturn.AiControlled = Convert.ToBoolean(BAM.NextByte());

                //Team iD
                ToReturn.TeamId = CodemastersToolkit.GetTeamFromTeamId(BAM.NextByte());

                //Nationality
                ToReturn.Nationality = BAM.NextByte();

                //name
                for (var t = 1; t <= 48; t++)
                {
                    var currentChar = Convert.ToChar(BAM.NextByte());
                    ToReturn.Name += currentChar.ToString();
                }

                //Car number
                ToReturn.CarNumber = BAM.NextByte();

                //Ready status
                ToReturn.ReadyStatus = (ReadyStatus)BAM.NextByte();

                return ToReturn;
            }
        }

        public enum ReadyStatus
        {
            NotReady = 0,
            Ready = 1,
            Spectating = 2
        }
     
    }

}