using System;
using System.Collections.Generic;
using TimHanewich.Toolkit;

namespace Codemasters.F1_2021
{
    public class ParticipantPacket : Packet
    {

        public byte NumberOfActiveCars { get; set; }
        public ParticipantData[] FieldParticipantData { get; set; }

        public override void LoadBytes(byte[] bytes)
        {
            ByteArrayManager BAM = new ByteArrayManager(bytes);
            base.LoadBytes(BAM.NextBytes(24));

            NumberOfActiveCars = BAM.NextByte();

            List<ParticipantData> PDs = new List<ParticipantData>();
            int t = 1;
            for (t = 0; t < 22; t++)
            {
                PDs.Add(ParticipantData.Create(BAM.NextBytes(56)));
            }
            FieldParticipantData = PDs.ToArray();
        }

        public class ParticipantData
        {
            public bool IsAiControlled { get; set; }
            public Driver PilotingDriver { get; set; }
            public byte NetworkId { get; set; } //New to F1 2021
            public Team ManufacturingTeam { get; set; }
            public bool MyTeam { get; set; } //New to F1 2021. Indicates if it is their own team
            public byte CarRaceNumber { get; set; }
            public byte NationalityId { get; set; } //I'm too lazy to do this right now.  Will leave it as a byte ID for now... -Tim 1/26/2020
            public string Name { get; set; }
            public bool TelemetryPrivate { get; set; }

            public static ParticipantData Create(byte[] bytes)
            {
                ParticipantData ReturnInstance = new ParticipantData();
                ByteArrayManager BAM = new ByteArrayManager(bytes);

                //Get AI controlled
                byte nb = BAM.NextByte();
                ReturnInstance.IsAiControlled = nb == 1 ? true : false;

                //Get piloting driver
                ReturnInstance.PilotingDriver = CodemastersToolkit.GetDriverFromDriverId(BAM.NextByte());

                //Get NetworkId
                ReturnInstance.NetworkId = BAM.NextByte();

                //Get Team
                ReturnInstance.ManufacturingTeam = CodemastersToolkit.GetTeamFromTeamId(BAM.NextByte());

                //My Team
                byte mt = BAM.NextByte();
                ReturnInstance.MyTeam = mt == 1 ? true : false;

                //Get race number
                ReturnInstance.CarRaceNumber = BAM.NextByte();

                //Get nationallity ID
                ReturnInstance.NationalityId = BAM.NextByte();

                //Get name
                string FullName = System.Text.Encoding.UTF8.GetString(BAM.NextBytes(48));
                ReturnInstance.Name = FullName.Trim();

                //Get telemetry private or not.
                nb = BAM.NextByte();
                if (nb == 0)
                {
                    ReturnInstance.TelemetryPrivate = true;
                }
                else if (nb == 1)
                {
                    ReturnInstance.TelemetryPrivate = false;
                }


                return ReturnInstance;
            }

        }
    }

}