using System;
using System.Collections.Generic;
using System.Drawing;

namespace Codemasters.F1_2021
{
    public static class CodemastersToolkit
        {
            public static PacketType GetPacketType(byte[] bytes)
            {
                if (bytes.Length == 1464)
                {
                    return PacketType.Motion;
                }
                else if (bytes.Length == 625)
                {
                    return PacketType.Session;
                }
                else if (bytes.Length == 970)
                {
                    return PacketType.Lap;
                }
                else if (bytes.Length == 36)
                {
                    return PacketType.Event;
                }
                else if (bytes.Length == 1257)
                {
                    return PacketType.Participants;
                }
                else if (bytes.Length == 1102)
                {
                    return PacketType.CarSetup;
                }
                else if (bytes.Length == 1347)
                {
                    return PacketType.CarTelemetry;
                }
                else if (bytes.Length == 1058)
                {
                    return PacketType.CarStatus;
                }
                else if (bytes.Length == 839)
                {
                    return PacketType.FinalClassification;
                }
                else if (bytes.Length == 1191)
                {
                    return PacketType.LobbyInfo;
                }
                else if (bytes.Length == 882)
                {
                    return PacketType.CarDamage;
                }
                else if (bytes.Length == 1155)
                {
                    return PacketType.SessionHistory;
                }
                else
                {
                    throw new Exception("Packet type with length " + bytes.Length.ToString("#,##0") + " not recognized.");
                }
            }

            public static Track GetTrackFromTrackId(byte id)
            {
                return (Track)id;
            }

            public static Driver GetDriverFromDriverId(byte id)
            {
                return (Driver)id;
            }

            public static Team GetTeamFromTeamId(byte id)
            {
                return (Team)id;
            }

            public static SurfaceType GetSurfaceTypeFromSurfaceTypeId(byte id)
            {
                if (id == 0)
                {
                    return SurfaceType.Tarmac;
                }
                else if (id == 1)
                {
                    return SurfaceType.RumbleStrip;
                }
                else if (id == 2)
                {
                    return SurfaceType.Concrete;
                }
                else if (id == 3)
                {
                    return SurfaceType.Rock;
                }
                else if (id == 4)
                {
                    return SurfaceType.Gravel;
                }
                else if (id == 5)
                {
                    return SurfaceType.Mud;
                }
                else if (id == 6)
                {
                    return SurfaceType.Sand;
                }
                else if (id == 7)
                {
                    return SurfaceType.Grass;
                }
                else if (id == 8)
                {
                    return SurfaceType.Water;
                }
                else if (id == 9)
                {
                    return SurfaceType.Cobblestone;
                }
                else if (id == 10)
                {
                    return SurfaceType.Metal;
                }
                else if (id == 11)
                {
                    return SurfaceType.Ridged;
                }
                else
                {
                    return (SurfaceType)id;
                }
            }

            public static Color GetTeamColorByTeam(Team t)
            {


                Color c = Color.FromArgb(255, 255, 255, 255);

                if (t == Team.Mercedes)
                {
                    c = Color.FromArgb(255, 0, 210, 190);
                }
                else if (t == Team.Haas)
                {
                    c = Color.FromArgb(255, 255, 255, 255);
                }
                else if (t == Team.McLaren)
                {
                    c = Color.FromArgb(255, 255, 152, 0);
                }
                else if (t == Team.AlfaRomeo)
                {
                    c = Color.FromArgb(255, 144, 0, 0);
                }
                else if (t == Team.RedBullRacing)
                {
                    c = Color.FromArgb(255, 6, 0, 239);
                }
                else if (t == Team.Alpine)
                {
                    c = Color.FromArgb(255, 0, 144, 255);
                }
                else if (t == Team.Ferrari)
                {
                    c = Color.FromArgb(255, 220, 0, 0);
                }
                else if (t == Team.AlphaTauri)
                {
                    c = Color.FromArgb(255, 43, 69, 98);
                }
                else if (t == Team.Williams)
                {
                    c = Color.FromArgb(255, 0, 90, 255);
                }
                else if (t == Team.AstonMartin)
                {
                    c = Color.FromArgb(255, 0, 111, 98);
                }

                return c;
            }

            /// <summary>
            /// This returns the name that should be displayed in a leaderboard (i.e. "L. Hamilton")
            /// </summary>
            public static string GetDriverDisplayNameFromDriver(Driver d)
            {
                string s = "Unknown";

                if (d == Driver.LewisHamilton)
                {
                    s = "L. Hamilton";
                }
                else if (d == Driver.ValtteriBottas)
                {
                    s = "V. Bottas";
                }
                else if (d == Driver.RomainGrosjean)
                {
                    s = "R. Grosjean";
                }
                else if (d == Driver.KevinMagnussen)
                {
                    s = "K. Magnussen";
                }
                else if (d == Driver.ValtteriBottas)
                {
                    s = "V. Bottas";
                }
                else if (d == Driver.CarlosSainz)
                {
                    s = "C. Sainz";
                }
                else if (d == Driver.LandoNorris)
                {
                    s = "L. Norris";
                }
                else if (d == Driver.KimiRaikkonen)
                {
                    s = "K. Raikkonen";
                }
                else if (d == Driver.AntonioGiovinazzi)
                {
                    s = "A. Giovinazzi";
                }
                else if (d == Driver.MaxVerstappen)
                {
                    s = "M. Verstappen";
                }
                else if (d == Driver.AlexanderAlbon)
                {
                    s = "A. Albon";
                }
                else if (d == Driver.DanielRicciardo)
                {
                    s = "D. Ricciardo";
                }
                else if (d == Driver.NicoHulkenburg)
                {
                    s = "N. Hulkenburg";
                }
                else if (d == Driver.SebastianVettel)
                {
                    s = "S. Vettel";
                }
                else if (d == Driver.CharlesLeclerc)
                {
                    s = "C. Leclerc";
                }
                else if (d == Driver.PierreGasly)
                {
                    s = "P. Gasly";
                }
                else if (d == Driver.DaniilKvyat)
                {
                    s = "D. Kvyat";
                }
                else if (d == Driver.GeorgeRussell)
                {
                    s = "G. Russell";
                }
                else if (d == Driver.NicholasLatifi)
                {
                    s = "N. Latifi";
                }
                else if (d == Driver.RobertKubica)
                {
                    s = "R. Kubica";
                }
                else if (d == Driver.SergioPerez)
                {
                    s = "S. Perez";
                }
                else if (d == Driver.LanceStroll)
                {
                    s = "L. Stroll";
                }
                else if (d == Driver.EstebanOcon)
                {
                    s = "E. Ocon";
                }
                else if (d == Driver.NicholasLatifi)
                {
                    s = "N. Latifi";
                }

                return s;
            }

            public static string GetLapTimeDisplayFromSeconds(float seconds)
            {
                int number_of_minutes = (int)Math.Floor(seconds / 60);
                float remaining = seconds - (number_of_minutes * 60);
                string s = number_of_minutes.ToString() + ":" + remaining.ToString("#00.000");
                return s;
            }            
        
            public static string CarNameFromTeam(Team t)
            {
                string ToReturn = "2020 Challenger";

                if (t == Team.Mercedes)
                {
                    ToReturn = "W12";
                }
                else if (t == Team.RedBullRacing)
                {
                    ToReturn = "RB16B";
                }
                else if (t == Team.McLaren)
                {
                    ToReturn = "MCL35M";
                }
                else if (t == Team.Ferrari)
                {
                    ToReturn = "SF21";
                }
                else if (t == Team.AstonMartin)
                {
                    ToReturn = "AMR21";
                }
                else if (t == Team.Alpine)
                {
                    ToReturn = "A521";
                }
                else if (t == Team.AlphaTauri)
                {
                    ToReturn = "AT02";
                }
                else if (t == Team.AlfaRomeo)
                {
                    ToReturn = "C41";
                }
                else if (t == Team.Haas)
                {
                    ToReturn = "VF-21";
                }
                else if (t == Team.Williams)
                {
                    ToReturn = "FW43B";
                }

                return ToReturn;
            }

            #region "Friendly Names"

            public static string GetTrackFriendlyName(Track t)
            {
                string ToReturn = t.ToString();

                if (t == Track.Melbourne)
                {
                    ToReturn = "Melbourne";
                }
                else if (t == Track.PaulRicard)
                {
                    ToReturn = "Paul Ricard";
                }
                else if (t == Track.Shanghai)
                {
                    ToReturn = "China";
                }
                else if (t == Track.Sakhir)
                {
                    ToReturn = "Bahrain";
                }
                else if (t == Track.Catalunya)
                {
                    ToReturn = "Spain";
                }
                else if (t == Track.Monaco)
                {
                    ToReturn = "Monaco";
                }
                else if (t == Track.Montreal)
                {
                    ToReturn = "Canada";
                }
                else if (t == Track.Silverstone)
                {
                    ToReturn = "Silverstone";
                }
                else if (t == Track.Hockenheim)
                {
                    ToReturn = "Hockenheim";
                }
                else if (t == Track.Hungaroring)
                {
                    ToReturn = "Hungaroring";
                }
                else if (t == Track.Spa)
                {
                    ToReturn = "Spa (Belgium)";
                }
                else if (t == Track.Monza)
                {
                    ToReturn = "Italy";
                }
                else if (t == Track.Singapore)
                {
                    ToReturn = "Singapore";
                }
                else if (t == Track.Suzuka)
                {
                    ToReturn = "Japan";
                }
                else if (t == Track.AbuDhabi)
                {
                    ToReturn = "Abu Dhabi";
                }
                else if (t == Track.Texas)
                {
                    ToReturn = "United States";
                }
                else if (t == Track.Brazil)
                {
                    ToReturn = "Brazil";
                }
                else if (t == Track.Austria)
                {
                    ToReturn = "Austria";
                }
                else if (t == Track.Sochi)
                {
                    ToReturn = "Russia";
                }
                else if (t == Track.Mexico)
                {
                    ToReturn = "Mexico";
                }
                else if (t == Track.Baku)
                {
                    ToReturn = "Azerbaijan";
                }
                else if (t == Track.SakhirShort)
                {
                    ToReturn = "Bahrain (Short)";
                }
                else if (t == Track.SilverstoneShort)
                {
                    ToReturn = "Silverstone (Short)";
                }
                else if (t == Track.TexasShort)
                {
                    ToReturn = "US (Short)";
                }
                else if (t == Track.SuzukaShort)
                {
                    ToReturn = "Japan (Short)";
                }
                else if (t == Track.Hanoi)
                {
                    ToReturn = "Vietnam";
                }
                else if (t == Track.Zandvoort)
                {
                    ToReturn = "Netherlands";
                }

                return ToReturn;
            }

            public static string GetDriverFriendlyName(Driver d)
            {
                string ToReturn = d.ToString();

                if (d == Driver.LewisHamilton)
                {
                    ToReturn = "Lewis Hamilton";
                }
                else if (d == Driver.ValtteriBottas)
                {
                    ToReturn = "Valtteri Bottas";
                }
                else if (d == Driver.CharlesLeclerc)
                {
                    ToReturn = "Charles Leclerc";
                }
                else if (d == Driver.SebastianVettel)
                {
                    ToReturn = "Sebastian Vettel";
                }
                else if (d == Driver.MaxVerstappen)
                {
                    ToReturn = "Max Verstappen";
                }
                else if (d == Driver.AlexanderAlbon)
                {
                    ToReturn = "Alex Albon";
                }
                else if (d == Driver.CarlosSainz)
                {
                    ToReturn = "Carlos Sainz";
                }
                else if (d == Driver.LandoNorris)
                {
                    ToReturn = "Lando Norris";
                }
                else if (d == Driver.DanielRicciardo)
                {
                    ToReturn = "Daniel Ricciardo";
                }
                else if (d == Driver.EstebanOcon)
                {
                    ToReturn = "Esteban Ocon";
                }
                else if (d == Driver.PierreGasly)
                {
                    ToReturn = "Pierre Gasly";
                }
                else if (d == Driver.DaniilKvyat)
                {
                    ToReturn = "Daniil Kvyat";
                }
                else if (d == Driver.SergioPerez)
                {
                    ToReturn = "Sergio Perez";
                }
                else if (d == Driver.LanceStroll)
                {
                    ToReturn = "Lance Stroll";
                }
                else if (d == Driver.KimiRaikkonen)
                {
                    ToReturn = "Kimi Raikkonen";
                }
                else if (d == Driver.AntonioGiovinazzi)
                {
                    ToReturn = "Antonio Giovinazzi";
                }
                else if (d == Driver.KevinMagnussen)
                {
                    ToReturn = "Kevin Magnussen";
                }
                else if (d == Driver.RomainGrosjean)
                {
                    ToReturn = "Romain Grosjean";
                }
                else if (d == Driver.GeorgeRussell)
                {
                    ToReturn = "George Russell";
                }
                else if (d == Driver.NicholasLatifi)
                {
                    ToReturn = "Nicholas Latifi";
                }

                return ToReturn;
            }

            public static string GetSessionTypeFriendlyName(SessionPacket.SessionType session_type)
            {
                switch (session_type)
                {
                    case SessionPacket.SessionType.Unknown:
                        return "Unknown";
                    case SessionPacket.SessionType.P1:
                        return "Practice 1";
                    case SessionPacket.SessionType.P2:
                        return "Practice 2";
                    case SessionPacket.SessionType.P3:
                        return "Practice 3";
                    case SessionPacket.SessionType.ShortPractice:
                        return "Short Practice";
                    case SessionPacket.SessionType.Q1:
                        return "Qualifying 1";
                    case SessionPacket.SessionType.Q2:
                        return "Qualifying 2";
                    case SessionPacket.SessionType.Q3:
                        return "Qualifying 3";
                    case SessionPacket.SessionType.ShortQualifying:
                        return "Short Qualifying";
                    case SessionPacket.SessionType.OneShotQualifying:
                        return "One Shot Qualifying";
                    case SessionPacket.SessionType.Race:
                        return "Race";
                    case SessionPacket.SessionType.Race2:
                        return "Race 2";
                    case SessionPacket.SessionType.TimeTrial:
                        return "Time Trial";
                    default:
                        return "Unknown Session (" + session_type.ToString() + ")";
                }
            }

            public static string GetTeamFriendlyName(Team t)
            {
                string ToReturn = t.ToString();

                if (t == Team.Mercedes)
                {
                    ToReturn = "Mercedes";
                }
                else if (t == Team.Ferrari)
                {
                    ToReturn = "Ferrari";
                }
                else if (t == Team.RedBullRacing)
                {
                    ToReturn = "Red Bull";
                }
                else if (t == Team.McLaren)
                {
                    ToReturn = "McLaren";
                }
                else if (t == Team.Alpine)
                {
                    ToReturn = "Alpine";
                }
                else if (t == Team.AlphaTauri)
                {
                    ToReturn = "Alpha Tauri";
                }
                else if (t == Team.AstonMartin)
                {
                    ToReturn = "Aston Martin";
                }
                else if (t == Team.AlfaRomeo)
                {
                    ToReturn = "Alfa Romeo";
                }
                else if (t == Team.Haas)
                {
                    ToReturn = "Haas";
                }
                else if (t == Team.Williams)
                {
                    ToReturn = "Williams";
                }

                return ToReturn;
            }

            public static string GetDriverStatusFriendlyName(LapPacket.DriverStatus driver_status)
            {
                string ToReturn = "?";

                if (driver_status == LapPacket.DriverStatus.FlyingLap)
                {
                    ToReturn = "Flying Lap";
                }
                else if (driver_status == LapPacket.DriverStatus.InGarage)
                {
                    ToReturn = "In Garage";
                }
                else if (driver_status == LapPacket.DriverStatus.InLap)
                {
                    ToReturn = "In Lap";
                }
                else if (driver_status == LapPacket.DriverStatus.OnTrack)
                {
                    ToReturn = "On Track";
                }
                else if (driver_status == LapPacket.DriverStatus.OutLap)
                {
                    ToReturn = "Out Lap";
                }
                
                return ToReturn;
            }

            #endregion
        
            #region "Tyre Compounds for Tracks"

            public static TyreCompound GetSoftTyreCompoundForTrack(Track t)
            {
                TyreCompound Mediums = GetMediumTyreCompoundForTrack(t);
                if (Mediums == TyreCompound.C4)
                {
                    return TyreCompound.C5;
                }
                else if (Mediums == TyreCompound.C3)
                {
                    return TyreCompound.C4;
                }
                else if (Mediums == TyreCompound.C2)
                {
                    return TyreCompound.C3;
                }
                else
                {
                    throw new Exception("Unable to get soft compound for Track '" + t.ToString() + "'");
                }
            }
            
            public static TyreCompound GetMediumTyreCompoundForTrack(Track t)
            {
                List<KeyValuePair<Track, TyreCompound>> KVPs = new List<KeyValuePair<Track, TyreCompound>>();
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Melbourne, TyreCompound.C3));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.PaulRicard, TyreCompound.C3));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Shanghai, TyreCompound.C3));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Sakhir, TyreCompound.C3));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Catalunya, TyreCompound.C2));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Monaco, TyreCompound.C4));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Montreal, TyreCompound.C4));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Silverstone, TyreCompound.C2));
                
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Hungaroring, TyreCompound.C3));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Spa, TyreCompound.C3));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Monza, TyreCompound.C3));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Singapore, TyreCompound.C4));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Suzuka, TyreCompound.C2));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.AbuDhabi, TyreCompound.C4));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Texas, TyreCompound.C3));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Brazil, TyreCompound.C2));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Austria, TyreCompound.C3));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Sochi, TyreCompound.C4));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Mexico, TyreCompound.C3));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Baku, TyreCompound.C3));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.SakhirShort, TyreCompound.C3));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.SilverstoneShort, TyreCompound.C2));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.TexasShort, TyreCompound.C3));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.SuzukaShort, TyreCompound.C2));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Hanoi, TyreCompound.C3));
                KVPs.Add(new KeyValuePair<Track, TyreCompound>(Track.Zandvoort, TyreCompound.C2));

                foreach (KeyValuePair<Track, TyreCompound> kvp in KVPs)
                {
                    if (kvp.Key == t)
                    {
                        return kvp.Value;
                    }
                }

                throw new Exception("Unable to find tyre compound for track '" + t.ToString() + "'");
            }

            public static TyreCompound GetHardTyreCompoundForTrack(Track t)
            {
                TyreCompound Mediums = GetMediumTyreCompoundForTrack(t);
                if (Mediums == TyreCompound.C4)
                {
                    return TyreCompound.C3;
                }
                else if (Mediums == TyreCompound.C3)
                {
                    return TyreCompound.C2;
                }
                else if (Mediums == TyreCompound.C2)
                {
                    return TyreCompound.C1;
                }
                else
                {
                    throw new Exception("Unable to get hard compound for Track '" + t.ToString() + "'");
                }
            }
            
            #endregion

            #region "3 Driver display letters"

            public static string GetDriverThreeLetters(Driver d)
            {
                List<KeyValuePair<Driver, string>> KVPs = new List<KeyValuePair<Driver, string>>();
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.MaxVerstappen, "VER"));
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.ValtteriBottas, "BOT"));
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.LewisHamilton, "HAM"));
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.LandoNorris, "NOR"));
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.AlexanderAlbon, "ALB"));
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.CarlosSainz, "SAI"));
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.DaniilKvyat, "KVY"));
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.LanceStroll, "STR"));
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.EstebanOcon, "OCO"));
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.PierreGasly, "GAS"));
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.DanielRicciardo, "RIC"));
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.SebastianVettel, "VET"));
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.CharlesLeclerc, "LEC"));
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.KimiRaikkonen, "RAI"));
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.AntonioGiovinazzi, "GIO"));
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.GeorgeRussell, "RUS"));
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.KevinMagnussen, "MAG"));
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.RomainGrosjean, "GRO"));
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.NicholasLatifi, "LAT"));
                KVPs.Add(new KeyValuePair<Driver, string>(Driver.SergioPerez, "PER"));

                foreach (KeyValuePair<Driver, string> KVP in KVPs)
                {
                    if (KVP.Key == d)
                    {
                        return KVP.Value;
                    }
                }

                //If we've gotten this far, we dont have it
                string displayname = d.ToString();
                return displayname.Substring(0, 3).ToUpper();
            }

            #endregion
        }

}