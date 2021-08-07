using System;
using TimHanewich.Toolkit;
using System.Collections.Generic;

namespace Codemasters.F1_2021
{

    public class FinalClassificationPacket : Packet
    {
        public byte NumberOfCars {get; set;}
        public FinalClassificationData[] FieldClassificationData {get; set;}

        public override void LoadBytes(byte[] bytes)
        {
            ByteArrayManager BAM = new ByteArrayManager(bytes);

            //Get header
            base.LoadBytes(BAM.NextBytes(24));

            //Get number of cars
            NumberOfCars = BAM.NextByte();

            //Get Final Classification Data
            List<FinalClassificationData> fcdata = new List<FinalClassificationData>();
            int t = 0;
            for (t=0; t < 22; t++)
            {
                fcdata.Add(FinalClassificationData.Create(BAM.NextBytes(37)));
            }
            FieldClassificationData = fcdata.ToArray();
        }


        public class FinalClassificationData
        {
            public byte FinishingPosition {get; set;}
            public byte NumberOfLaps {get; set;}
            public byte StartingGridPosition {get; set;}
            public byte PointsScored {get; set;}
            public byte NumberOfPitStops {get; set;}
            public ResultStatus FinalResultStatus {get; set;}
            public uint BestLapTimeMilliseconds {get; set;}
            public double TotalRaceTimeSeconds {get; set;}
            public byte PenaltiesTimeSeconds {get; set;}
            public byte NumberOfTyreStints {get; set;}
            //Skipping tyre stints actual
            //Skipping tyre stints visual

            public static FinalClassificationData Create(byte[] bytes)
            {
                FinalClassificationData ToReturn = new FinalClassificationData();
                ByteArrayManager BAM = new ByteArrayManager(bytes);

                //Finishing position
                ToReturn.FinishingPosition = BAM.NextByte();

                //Number of laps
                ToReturn.NumberOfLaps = BAM.NextByte();

                //Starting grid position
                ToReturn.StartingGridPosition = BAM.NextByte();

                //Points scored
                ToReturn.PointsScored = BAM.NextByte();

                //Number of pit stops
                ToReturn.NumberOfPitStops = BAM.NextByte();

                //Result status
                byte nb = BAM.NextByte();
                ToReturn.FinalResultStatus = (ResultStatus)nb;

                //Best lap time in milliseconds (uint32)
                ToReturn.BestLapTimeMilliseconds = BitConverter.ToUInt32(BAM.NextBytes(4));

                //Total race time in seconds
                ToReturn.TotalRaceTimeSeconds = BitConverter.ToDouble(BAM.NextBytes(8), 0);

                //Penalties time in seconds
                ToReturn.PenaltiesTimeSeconds = BAM.NextByte();

                //Number of tyre stints
                ToReturn.NumberOfTyreStints = BAM.NextByte();

                return ToReturn;
            }

            public float BestLapTimeSeconds
            {
                get
                {
                    return Convert.ToSingle(BestLapTimeMilliseconds) / 1000f;
                }
            }

        }

        public enum ResultStatus
        {
            Invalid = 0,
            Inactive = 1,
            Active = 2,
            Finished = 3,
            DidNotFinish = 4,
            Disqualified = 5,
            NotClassified = 6,
            Retired = 7
        }
    }


    

    
}