using System;
using System.Collections.Generic;
using TimHanewich.Toolkit;

namespace Codemasters.F1_2021
{
    public class SessionHistoryPacket : Packet
    {

        public byte ForCarIndex {get; set;} //The index of the car this is intended for
        public byte NumberOfLaps {get; set;} //Includes current partial lap
        public byte NumberOfTyreStints {get; set;}
        public byte BestLapTimeLapNumber {get; set;}
        public byte BestSector1TimeLapNumber {get; set;}
        public byte BestSector2TimeLapNumber {get; set;}
        public byte BestSector3TimeLapNumber {get; set;}
        public LapHistoryData[] CarLapHistoryData {get; set;} //lap history data for this car
        public TyreStintHistoryData[] CarTyreStintHistoryData {get; set;} //tyre stint history for this car

        public override void LoadBytes(byte[] bytes)
        {
            ByteArrayManager BAM = new ByteArrayManager(bytes);
            base.LoadBytes(BAM.NextBytes(24));

            ForCarIndex = BAM.NextByte();
            NumberOfLaps = BAM.NextByte();
            NumberOfTyreStints = BAM.NextByte();
            BestLapTimeLapNumber = BAM.NextByte();
            BestSector1TimeLapNumber = BAM.NextByte();
            BestSector2TimeLapNumber = BAM.NextByte();
            BestSector3TimeLapNumber = BAM.NextByte();

            //History data
            List<LapHistoryData> historyDatas = new List<LapHistoryData>();
            for (int t = 0; t < 100; t++)
            {
                historyDatas.Add(LapHistoryData.Create(BAM.NextBytes(11)));
            }
            CarLapHistoryData = historyDatas.ToArray();

            //Stint Data
            List<TyreStintHistoryData> stintHistories = new List<TyreStintHistoryData>();
            for (int t = 0; t < 8; t++)
            {
                stintHistories.Add(TyreStintHistoryData.Create(BAM.NextBytes(3)));
            }
            CarTyreStintHistoryData = stintHistories.ToArray();
        }


        public class LapHistoryData
        {
            public uint LapTimeMilliseconds {get; set;}
            public ushort Sector1TimeMilliseconds {get; set;}
            public ushort Sector2TimeMilliseconds {get; set;}
            public ushort Sector3TimeMilliseconds {get; set;}
            public byte LapValidBitFlags {get; set;}

            public static LapHistoryData Create(byte[] bytes)
            {
                LapHistoryData ToReturn = new LapHistoryData();

                ByteArrayManager BAM = new ByteArrayManager(bytes);

                //Lap time
                ToReturn.LapTimeMilliseconds = BitConverter.ToUInt32(BAM.NextBytes(4));

                //Sector times
                ToReturn.Sector1TimeMilliseconds = BitConverter.ToUInt16(BAM.NextBytes(2));
                ToReturn.Sector2TimeMilliseconds = BitConverter.ToUInt16(BAM.NextBytes(2));
                ToReturn.Sector3TimeMilliseconds = BitConverter.ToUInt16(BAM.NextBytes(2));

                //Lap valid bit flags
                ToReturn.LapValidBitFlags = BAM.NextByte();

                return ToReturn;
            }
        }

        public class TyreStintHistoryData
        {
            public byte EndLap {get; set;}
            public byte ActualTyreCompound {get; set;}
            public byte VisualTyreCompound {get; set;}

            public static TyreStintHistoryData Create(byte[] bytes)
            {
                TyreStintHistoryData ToReturn = new TyreStintHistoryData();

                ByteArrayManager BAM = new ByteArrayManager(bytes);

                //End lap
                ToReturn.EndLap = BAM.NextByte();

                //Tyre compounds
                ToReturn.ActualTyreCompound = BAM.NextByte();
                ToReturn.VisualTyreCompound = BAM.NextByte();

                return ToReturn;
            }
        }
    }
}