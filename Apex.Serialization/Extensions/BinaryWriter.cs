﻿using Apex.Serialization.Internal;
using System.Runtime.CompilerServices;

namespace Apex.Serialization.Extensions
{
    internal class BinaryWriter<TStream> : IBinaryWriter
        where TStream : struct, IBinaryStream
    {
        public Binary<TStream> _instance;

        public BinaryWriter(Binary<TStream> instance)
        {
            _instance = instance;
        }

        public void Write(string input)
        {
            _instance._stream.Write(input);
        }

        public void Write<T>(T value) where T : struct 
        {
            _instance._stream.ReserveSize(Unsafe.SizeOf<T>());
            _instance._stream.Write(value);
        }

        public void WriteObject<T>(T value)
        {
            _instance.WriteObjectEntry(value);
        }
    }
}
