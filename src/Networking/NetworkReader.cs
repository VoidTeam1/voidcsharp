using System;
using VoidSharp;

namespace VoidSharp.Networking
{
    public class NetworkReader
    {
        /// <summary>
        /// @CSharpLua.Template = "net.ReadString()"
        /// </summary>
        public string ReadString()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// @CSharpLua.Template = "net.ReadInt({0})"
        /// </summary>
        public object ReadInt(int bitCount)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// @CSharpLua.Template = "net.ReadUInt({0})"
        /// </summary>
        public object ReadUInt(int bitCount)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// @CSharpLua.Template = "net.ReadBool()"
        /// </summary>
        public bool ReadBool()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// @CSharpLua.Template = "net.ReadDouble()"
        /// </summary>
        public double ReadDouble()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// @CSharpLua.Template = "net.ReadFloat()"
        /// </summary>
        public float WriteFloat()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// @CSharpLua.Template = "net.ReadEntity()"
        /// </summary>
        public Entity ReadEntity()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// @CSharpLua.Template = "net.ReadVector()"
        /// </summary>
        public Vector ReadVector()
        {
            throw new NotImplementedException();
        }

        public Color ReadColor()
        {
            dynamic gmodColor = null;
            /*
            [[
                gmodColor = net.ReadColor()
            ]]
            */
            return Color.FromGmodColor(gmodColor);
        }
    }
}