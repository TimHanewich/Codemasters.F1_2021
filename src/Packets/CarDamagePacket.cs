using System;
using TimHanewich.Toolkit;
using System.Collections.Generic;

namespace Codemasters.F1_2021
{
    public class CarDamagePacket : Packet
    {

        public CarDamageData[] FieldCarDamageData {get; set;}

        public override void LoadBytes(byte[] bytes)
        {
            ByteArrayManager BAM = new ByteArrayManager(bytes);
            base.LoadBytes(BAM.NextBytes(24));

            List<CarDamageData> DamageData = new List<CarDamageData>();
            for (int t = 0; t < 22; t++)
            {
                DamageData.Add(CarDamageData.Create(BAM.NextBytes(39)));
            }
            FieldCarDamageData = DamageData.ToArray();
        }

        public class CarDamageData //39 bytes
        {
            public WheelDataArray TyreWear {get; set;}
            public WheelDataArray TyreDamage {get; set;}
            public WheelDataArray BrakeDamage {get; set;}
            public byte FrontLeftWingDamage {get; set;}
            public byte FrontRightWingDamange {get; set;}
            public byte RearWingDamage {get; set;}
            public byte FloorDamage {get; set;}
            public byte DiffuserDamange {get; set;}
            public byte SidepodDamage {get; set;}
            public bool DrsFault {get; set;}
            public byte GearBoxDamage {get; set;}
            public byte EngineDamage {get; set;}
            public byte EngineMGUHWear {get; set;}
            public byte EngineESWear {get; set;}
            public byte EngineCEWear {get; set;}
            public byte EngineICEWear {get; set;}
            public byte EngineMGUKWear {get; set;}
            public byte EngineTCWear {get; set;}

            public static CarDamageData Create(byte[] bytes)
            {
                CarDamageData ToReturn = new CarDamageData();

                ByteArrayManager BAM = new ByteArrayManager(bytes);

                //Tyre wear
                ToReturn.TyreWear = new WheelDataArray();
                ToReturn.TyreWear.RearLeft = BitConverter.ToSingle(BAM.NextBytes(4));
                ToReturn.TyreWear.RearRight = BitConverter.ToSingle(BAM.NextBytes(4));
                ToReturn.TyreWear.FrontLeft = BitConverter.ToSingle(BAM.NextBytes(4));
                ToReturn.TyreWear.FrontRight = BitConverter.ToSingle(BAM.NextBytes(4));

                //Tyre Damage
                ToReturn.TyreDamage = new WheelDataArray();
                ToReturn.TyreDamage.RearLeft = Convert.ToSingle(BAM.NextByte());
                ToReturn.TyreDamage.RearRight = Convert.ToSingle(BAM.NextByte());
                ToReturn.TyreDamage.FrontLeft = Convert.ToSingle(BAM.NextByte());
                ToReturn.TyreDamage.FrontRight = Convert.ToSingle(BAM.NextByte());

                //Brake damage
                ToReturn.BrakeDamage = new WheelDataArray();
                ToReturn.BrakeDamage.RearLeft = Convert.ToSingle(BAM.NextByte());
                ToReturn.BrakeDamage.RearRight = Convert.ToSingle(BAM.NextByte());
                ToReturn.BrakeDamage.FrontLeft = Convert.ToSingle(BAM.NextByte());
                ToReturn.BrakeDamage.FrontRight = Convert.ToSingle(BAM.NextByte());

                //Wing damage
                ToReturn.FrontLeftWingDamage = BAM.NextByte();
                ToReturn.FrontRightWingDamange = BAM.NextByte();
                ToReturn.RearWingDamage = BAM.NextByte();
                
                //More damage
                ToReturn.FloorDamage = BAM.NextByte();
                ToReturn.DiffuserDamange = BAM.NextByte();
                ToReturn.SidepodDamage = BAM.NextByte();
                ToReturn.DrsFault = Convert.ToBoolean(BAM.NextByte());
                ToReturn.GearBoxDamage = BAM.NextByte();
                ToReturn.EngineDamage = BAM.NextByte();
                ToReturn.EngineMGUHWear = BAM.NextByte();
                ToReturn.EngineESWear = BAM.NextByte();
                ToReturn.EngineICEWear = BAM.NextByte();
                ToReturn.EngineMGUKWear = BAM.NextByte();
                ToReturn.EngineTCWear = BAM.NextByte();

                return ToReturn;
            }
        }

    }
}