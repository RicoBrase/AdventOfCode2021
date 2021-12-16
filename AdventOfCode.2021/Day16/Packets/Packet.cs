using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day16.Packets;

public class Packet
{
    public int BitLength { get; init; }
    public long Version { get; init; }
    public long PacketType { get; init; }
    public long Value { get; set; }

    public List<Packet> ChildPackets { get; } = new();

    public override int GetHashCode()
    {
        return HashCode.Combine(Version, PacketType, Value, ChildPackets);
    }

    public override bool Equals(object obj)
    {
        if (obj is Packet packet)
            return Version == packet.Version
                   && PacketType == packet.PacketType
                   && Value == packet.Value
                   && ChildPackets.SequenceEqual(packet.ChildPackets);
        return false;
    }
}