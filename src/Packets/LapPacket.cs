using System;
using System.Collections.Generic;
using TimHanewich.Toolkit;

namespace Codemasters.F1_2021
{
    public class LapPacket : Packet
    {

        public LapData[] FieldLapData { get; set; }

        public override void LoadBytes(byte[] bytes)
        {
            ByteArrayManager BAM = new ByteArrayManager(bytes);

            //Get header
            base.LoadBytes(BAM.NextBytes(24));




            //Get the next 20 data packages
            List<LapData> LDs = new List<LapData>();
            int t = 1;
            for (t = 0; t < 22; t++)
            {
                LDs.Add(LapData.Create(BAM.NextBytes(53)));
            }
            FieldLapData = LDs.ToArray();
        }

        /// <summary>
        /// 53 bytes long.
        /// </summary>
        public class LapData
        {
            public float LastLapTime { get; set; }
            public float CurrentLapTime { get; set; }
            public ushort Sector1TimeMilliseconds { get; set; }
            public ushort Sector2TimeMilliseconds { get; set; }        
            public float LapDistance { get; set; }
            public float TotalDistance { get; set; }
            public float SafetyCarDelta { get; set; }
            public byte CarPosition { get; set; }
            public byte CurrentLapNumber { get; set; }
            public PitStatus CurrentPitStatus { get; set; }
            public byte Sector { get; set; }
            public bool CurrentLapInvalid { get; set; }
            public byte Penalties {get; set;}
            public byte Warnings {get; set;} //Number of warnings that have been accumulated
            public byte UnservedDriveThroughPenalties {get; set;} //Number of unserved drive through penalties (still have to serve)
            public byte UnservedStopAndGoPenalties {get; set;}
            public byte StartingGridPosition { get; set; }
            public DriverStatus CurrentDriverStatus { get; set; }
            public ResultStatus FinalResultStatus { get; set; }
            public bool PitLaneTimerActive {get; set;}
            public ushort TimeInPitLaneMilliseconds {get; set;} //If in the pitlane, the number of milliseconds you have spent in there.
            public ushort PitStopTimerMilliseconds {get; set;}
            public bool ShouldServePenaltyDuringPitStop {get; set;}

            public static LapData Create(byte[] bytes)
            {
                LapData ReturnInstance = new LapData();
                ByteArrayManager BAM = new ByteArrayManager(bytes);

                ReturnInstance.LastLapTime = BitConverter.ToSingle(BAM.NextBytes(4), 0);
                ReturnInstance.CurrentLapTime = BitConverter.ToSingle(BAM.NextBytes(4), 0);

                ReturnInstance.Sector1TimeMilliseconds = BitConverter.ToUInt16(BAM.NextBytes(2), 0);
                ReturnInstance.Sector2TimeMilliseconds = BitConverter.ToUInt16(BAM.NextBytes(2), 0);

                ReturnInstance.LapDistance = BitConverter.ToSingle(BAM.NextBytes(4), 0);
                ReturnInstance.TotalDistance = BitConverter.ToSingle(BAM.NextBytes(4), 0);
                ReturnInstance.SafetyCarDelta = BitConverter.ToSingle(BAM.NextBytes(4), 0);
                ReturnInstance.CarPosition = BAM.NextByte();
                ReturnInstance.CurrentLapNumber = BAM.NextByte();

                //Get pit status
                byte nb = BAM.NextByte();
                ReturnInstance.CurrentPitStatus = (PitStatus)nb;

                //Get sector
                ReturnInstance.Sector = System.Convert.ToByte(BAM.NextByte() + 1);

                //Get current lap invalid
                nb = BAM.NextByte();
                if (nb == 0)
                {
                    ReturnInstance.CurrentLapInvalid = false;
                }
                else if (nb == 1)
                {
                    ReturnInstance.CurrentLapInvalid = true;
                }

                //Get penalties
                ReturnInstance.Penalties = BAM.NextByte();

                //Warnings
                ReturnInstance.Warnings = BAM.NextByte();

                //Number of unserved drive through penalties
                ReturnInstance.UnservedDriveThroughPenalties = BAM.NextByte();

                //Number of unserved stop & go penalties
                ReturnInstance.UnservedStopAndGoPenalties = BAM.NextByte();

                //Get grid position
                ReturnInstance.StartingGridPosition = BAM.NextByte();

                //Get driver status
                nb = BAM.NextByte();
                ReturnInstance.CurrentDriverStatus = (DriverStatus)nb;


                //Get result status
                nb = BAM.NextByte();
                ReturnInstance.FinalResultStatus = (ResultStatus)nb;

                return ReturnInstance;
            }

        }

        public enum DriverStatus
        {
            InGarage = 0,
            FlyingLap = 1,
            InLap = 2,
            OutLap = 3,
            OnTrack = 4
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