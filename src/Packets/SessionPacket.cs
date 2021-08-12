using System;
using System.Collections.Generic;
using TimHanewich.Toolkit;

namespace Codemasters.F1_2021
{
    public class SessionPacket : Packet
    {

        public WeatherCondition CurrentWeatherCondition { get; set; }
        public byte TrackTemperatureCelsius { get; set; }
        public byte AirTemperatureCelsius { get; set; }
        public byte TotalLapsInRace { get; set; }
        public ushort TrackLengthMeters { get; set; }
        public SessionType SessionTypeMode { get; set; }
        public Track SessionTrack { get; set; }
        public FormulaType Formula { get; set; }
        public ushort SessionTimeLeft { get; set; }
        public ushort SessionDuration { get; set; }
        public byte PitSpeedLimitKph { get; set; }
        public bool GamePaused { get; set; }
        public bool IsSpectating { get; set; }
        public byte CarIndexBeingSpectated { get; set; }
        public bool SliProNativeSupport { get; set; }
        public byte NumberOfMarshallZones { get; set; }
        public MarshallZone[] MarshallZones { get; set; }
        public SafetyCarStatus CurrentSafetyCarStatus { get; set; }
        public bool IsNetworkGame { get; set; }
        public byte NumberOfWeatherForecastSamples {get; set;}
        public WeatherForecastSample[] WeatherForecastSamples {get; set;}

        //Every property below is new to F1 2021
        public ForecastAccuracy CurrentForecastAccuracy {get; set;}
        public byte AIDifficulty {get; set;} //0 - 110
        public uint SeasonLinkIdentifier {get; set;}
        public uint WeekendLinkIdentifier {get; set;}
        public uint SessionLinkIdentifier {get; set;}
        public byte PitStopWindowIdealLap {get; set;}
        public byte PitStopWindowLatestLap {get; set;}
        public byte PitStopRejoinPosition {get; set;}
        public bool SteeringAssist {get; set;}
        public BrakingAssistLevel BrakingAssist {get; set;}
        public GearBoxAssistLevel GearBoxAssist {get; set;}
        public bool PitAssist {get; set;}
        public bool PitReleaseAssist {get; set;}
        public bool ErsAssist {get; set;}
        public bool DrsAssist {get; set;}
        public DynamicRacingLineAssistLevel DynamicRacingLine {get; set;}
        public byte DynamicRacingLineType {get; set;} //0 = 2D, 1 = 3D



        public override void LoadBytes(byte[] bytes)
        {
            ByteArrayManager BAM = new ByteArrayManager(bytes);

            //Load header
            base.LoadBytes(BAM.NextBytes(24));

            //Get weather
            byte nb = BAM.NextByte();
            if (nb == 0)
            {
                CurrentWeatherCondition = WeatherCondition.Clear;
            }
            else if (nb == 1)
            {
                CurrentWeatherCondition = WeatherCondition.LightClouds;
            }
            else if (nb == 2)
            {
                CurrentWeatherCondition = WeatherCondition.Overcast;
            }
            else if (nb == 3)
            {
                CurrentWeatherCondition = WeatherCondition.LightRain;
            }
            else if (nb == 4)
            {
                CurrentWeatherCondition = WeatherCondition.HeavyRain;
            }
            else if (nb == 5)
            {
                CurrentWeatherCondition = WeatherCondition.Storm;
            }


            //Get track temperature
            TrackTemperatureCelsius = BAM.NextByte();

            //Get air temperature
            AirTemperatureCelsius = BAM.NextByte();

            //Get total laps
            TotalLapsInRace = BAM.NextByte();

            //get track length
            TrackLengthMeters = BitConverter.ToUInt16(BAM.NextBytes(2), 0);

            //Get session type
            nb = BAM.NextByte();
            SessionTypeMode = (SessionType)nb;

            //Get track
            SessionTrack = CodemastersToolkit.GetTrackFromTrackId(BAM.NextByte());

            //Get formula
            nb = BAM.NextByte();
            if (nb == 0)
            {
                Formula = FormulaType.Formula1Modern;
            }
            else if (nb == 1)
            {
                Formula = FormulaType.Formula1Classic;
            }
            else if (nb == 2)
            {
                Formula = FormulaType.Formula2;
            }
            else if (nb == 3)
            {
                Formula = FormulaType.Formula1Generic;
            }


            //Get session time left
            SessionTimeLeft = BitConverter.ToUInt16(BAM.NextBytes(2), 0);

            //Get session duration
            SessionDuration = BitConverter.ToUInt16(BAM.NextBytes(2), 0);

            //Get pit speed limit
            PitSpeedLimitKph = BAM.NextByte();

            //get game paused
            nb = BAM.NextByte();
            if (nb == 0)
            {
                GamePaused = false;
            }
            else if (nb == 1)
            {
                GamePaused = true;
            }

            //Get is spectating
            nb = BAM.NextByte();
            if (nb == 0)
            {
                IsSpectating = false;
            }
            else if (nb == 1)
            {
                IsSpectating = true;
            }


            //Get spectating car index
            CarIndexBeingSpectated = BAM.NextByte();

            //Get sli pro native support
            nb = BAM.NextByte();
            if (nb == 0)
            {
                SliProNativeSupport = false;
            }
            else if (nb == 1)
            {
                SliProNativeSupport = true;
            }

            //Get number of marshall zones
            NumberOfMarshallZones = BAM.NextByte();

            //Get marshall zones
            List<MarshallZone> MZs = new List<MarshallZone>();
            int t = 1;
            for (t = 1; t <= 21; t++)
            {
                MZs.Add(MarshallZone.Create(BAM.NextBytes(5)));
            }


            //Get safety car status
            nb = BAM.NextByte();
            if (nb == 0)
            {
                CurrentSafetyCarStatus = SafetyCarStatus.None;
            }
            else if (nb == 1)
            {
                CurrentSafetyCarStatus = SafetyCarStatus.Full;
            }
            else if (nb == 2)
            {
                CurrentSafetyCarStatus = SafetyCarStatus.Virtual;
            }

            //Get network game boolean
            nb = BAM.NextByte();
            if (nb == 0)
            {
                IsNetworkGame = false;
            }
            else if (nb == 1)
            {
                IsNetworkGame = true;
            }


            //Get number of weather forecast samples
            NumberOfWeatherForecastSamples = BAM.NextByte();

            //Get the next 20 weather forecast samples
            List<WeatherForecastSample> wfss = new List<WeatherForecastSample>();
            for (t = 0; t < 56 ;t++)
            {
                wfss.Add(WeatherForecastSample.Create(BAM.NextBytes(8)));
            }
            WeatherForecastSamples = wfss.ToArray();

            //Get forecast accuracy
            CurrentForecastAccuracy = (ForecastAccuracy)BAM.NextByte();

            //Get AI difficulty
            AIDifficulty = BAM.NextByte();

            //Get link identifiers
            SeasonLinkIdentifier = BitConverter.ToUInt32(BAM.NextBytes(4), 0);
            WeekendLinkIdentifier = BitConverter.ToUInt32(BAM.NextBytes(4), 0);
            SessionLinkIdentifier = BitConverter.ToUInt32(BAM.NextBytes(4), 0);

            //Pit stop window parts
            PitStopWindowIdealLap = BAM.NextByte();
            PitStopWindowLatestLap = BAM.NextByte();
            PitStopRejoinPosition = BAM.NextByte();

            //Assists
            SteeringAssist = Convert.ToBoolean(BAM.NextByte());
            BrakingAssist = (BrakingAssistLevel)BAM.NextByte();
            GearBoxAssist = (GearBoxAssistLevel)BAM.NextByte();
            PitAssist = Convert.ToBoolean(BAM.NextByte());
            PitReleaseAssist = Convert.ToBoolean(BAM.NextByte());
            ErsAssist = Convert.ToBoolean(BAM.NextByte());
            DrsAssist = Convert.ToBoolean(BAM.NextByte());
            DynamicRacingLine = (DynamicRacingLineAssistLevel)BAM.NextByte();
            DynamicRacingLineType = BAM.NextByte();
        }




        public class MarshallZone
        {
            public float ZoneStart { get; set; }
            public FiaFlag ZoneFlag { get; set; }

            public static MarshallZone Create(byte[] bytes)
            {
                MarshallZone ReturnInstance = new MarshallZone();
                ByteArrayManager BAM = new ByteArrayManager(bytes);

                //Get zone start
                ReturnInstance.ZoneStart = BitConverter.ToSingle(BAM.NextBytes(4), 0);

                //Get zone flag
                byte nb = BAM.NextByte();
                if (nb == 0)
                {
                    ReturnInstance.ZoneFlag = FiaFlag.None;
                }
                else if (nb == 1)
                {
                    ReturnInstance.ZoneFlag = FiaFlag.Green;
                }
                else if (nb == 2)
                {
                    ReturnInstance.ZoneFlag = FiaFlag.Blue;
                }
                else if (nb == 3)
                {
                    ReturnInstance.ZoneFlag = FiaFlag.Yellow;
                }
                else if (nb == 4)
                {
                    ReturnInstance.ZoneFlag = FiaFlag.Red;
                }

                return ReturnInstance;
            }

        }

        public class WeatherForecastSample //8 bytes
        {
            public SessionType SessionTypeMode {get; set;}
            public byte TimeOffSet {get; set;}
            public WeatherCondition ForecastedWeatherCondition {get; set;}
            public byte TrackTemperatureCelsius {get; set;}
            public byte TrackTemperatureChange {get; set;} //0 = up, 1 = down, 2 = no change
            public byte AirTemperatureCelsius {get; set;}
            public byte AirTemperatureChange {get; set;} //0 = up, 1 = down, 2 = no change
            public byte RainPercentage {get; set;}


            public static WeatherForecastSample Create(byte[] bytes)
            {
                WeatherForecastSample ToReturn = new WeatherForecastSample();
                ByteArrayManager BAM = new ByteArrayManager(bytes);

                //Get session type
                byte nb = BAM.NextByte();
                if (nb == 0)
                {
                    ToReturn.SessionTypeMode = SessionType.Unknown;
                }
                else if (nb == 1)
                {
                    ToReturn.SessionTypeMode = SessionType.P1;
                }
                else if (nb == 2)
                {
                    ToReturn.SessionTypeMode = SessionType.P2;
                }
                else if (nb == 3)
                {
                    ToReturn.SessionTypeMode = SessionType.P3;
                }
                else if (nb == 4)
                {
                    ToReturn.SessionTypeMode = SessionType.ShortPractice;
                }
                else if (nb == 5)
                {
                    ToReturn.SessionTypeMode = SessionType.Q1;
                }
                else if (nb == 6)
                {
                    ToReturn.SessionTypeMode = SessionType.Q2;
                }
                else if (nb == 7)
                {
                    ToReturn.SessionTypeMode = SessionType.Q3;
                }
                else if (nb == 8)
                {
                    ToReturn.SessionTypeMode = SessionType.ShortQualifying;
                }
                else if (nb == 9)
                {
                    ToReturn.SessionTypeMode = SessionType.OneShotQualifying;
                }
                else if (nb == 10)
                {
                    ToReturn.SessionTypeMode = SessionType.Race;
                }
                else if (nb == 11)
                {
                    ToReturn.SessionTypeMode = SessionType.Race2;
                }
                else if (nb == 12)
                {
                    ToReturn.SessionTypeMode = SessionType.TimeTrial;
                }


                //Get time offset
                ToReturn.TimeOffSet = BAM.NextByte();

                //Get weather
                nb = BAM.NextByte();
                if (nb == 0)
                {
                    ToReturn.ForecastedWeatherCondition = WeatherCondition.Clear;
                }
                else if (nb == 1)
                {
                    ToReturn.ForecastedWeatherCondition = WeatherCondition.LightClouds;
                }
                else if (nb == 2)
                {
                    ToReturn.ForecastedWeatherCondition = WeatherCondition.Overcast;
                }
                else if (nb == 3)
                {
                    ToReturn.ForecastedWeatherCondition = WeatherCondition.LightRain;
                }
                else if (nb == 4)
                {
                    ToReturn.ForecastedWeatherCondition = WeatherCondition.HeavyRain;
                }
                else if (nb == 5)
                {
                    ToReturn.ForecastedWeatherCondition = WeatherCondition.Storm;
                }

                //Get track temperature
                ToReturn.TrackTemperatureCelsius = BAM.NextByte();

                //Track temperature change
                ToReturn.TrackTemperatureChange = BAM.NextByte();

                //Get air temperature
                ToReturn.AirTemperatureCelsius = BAM.NextByte();

                //Air temperature change
                ToReturn.AirTemperatureChange = BAM.NextByte();

                //rain percentage
                ToReturn.RainPercentage = BAM.NextByte();

                return ToReturn;
            }

        }

        public enum WeatherCondition
        {
            Clear = 0,
            LightClouds = 1,
            Overcast = 2,
            LightRain = 3,
            HeavyRain = 4,
            Storm = 5
        }

        public enum SafetyCarStatus
        {
            None,
            Full,
            Virtual
        }

        public enum FormulaType
        {
            Formula1Modern,
            Formula1Classic,
            Formula2,
            Formula1Generic
        }

        public enum SessionType
        {
            Unknown = 0,
            P1 = 1,
            P2 = 2,
            P3 = 3,
            ShortPractice = 4,
            Q1 = 5,
            Q2 = 6,
            Q3 = 7,
            ShortQualifying = 8,
            OneShotQualifying = 9,
            Race = 10,
            Race2 = 11,
            TimeTrial = 12
        }
    
        public enum ForecastAccuracy
        {
            Perfect = 0,
            Approximate = 1
        }
    
        public enum BrakingAssistLevel
        {
            Off = 0,
            Low = 1,
            Medium = 2,
            High = 3
        }

        public enum GearBoxAssistLevel
        {
            Manual = 1,
            ManualAndSuggested = 2,
            High = 3
        }

        public enum DynamicRacingLineAssistLevel
        {
            Off = 0,
            CornersOnly = 1,
            Full = 2
        }
    }

}