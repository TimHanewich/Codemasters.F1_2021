using System;

namespace Codemasters.F1_2021
{
    public enum PacketType
    {
        Motion = 0, //1464 bytes
        Session = 1, //625 bytes
        Lap = 2, //970 bytes
        Event = 3, //36 bytes
        Participants = 4, //1257 bytes
        CarSetup = 5, //1102 bytes
        CarTelemetry = 6, //1347 bytes
        CarStatus = 7, //1058 bytes
        FinalClassification = 8, //839 bytes    New to F1 2020.
        LobbyInfo = 9, //1191 bytes   New to F1 2020,
        CarDamage = 10, //882 bytes. New to F1 2021
        SessionHistory = 11 //1155 bytes. New to F1 2021
    }
}