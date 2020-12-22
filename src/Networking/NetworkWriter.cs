using System;
using VoidSharp;

namespace VoidSharp.Networking
{
    public class NetworkWriter
    {

        /// <summary>
        /// @CSharpLua.Template = "net.WriteString({0})"
        /// </summary>
        public void WriteString(string str)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// @CSharpLua.Template = "net.WriteInt({0}, {1})"
        /// </summary>
        public void WriteInt(int num, int bitCount)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// @CSharpLua.Template = "net.WriteUInt({0}, {1})"
        /// </summary>
        public void WriteUInt(int num, int bitCount)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// @CSharpLua.Template = "net.WriteBool({0})"
        /// </summary>
        public void WriteBool(bool boolean)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// @CSharpLua.Template = "net.WriteDouble({0})"
        /// </summary>
        public void WriteDouble(double num)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// @CSharpLua.Template = "net.WriteFloat({0})"
        /// </summary>
        public void WriteFloat(float num)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// @CSharpLua.Template = "net.WriteEntity({0})"
        /// </summary>
        public void WriteEntity(Entity entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// @CSharpLua.Template = "net.WriteVector({0})"
        /// </summary>
        public void WriteVector(Vector vector)
        {
            throw new NotImplementedException();
        }

        public void WriteColor(Color color)
        {
            dynamic gmodColor = color.ToGmodColor();
            /*
            [[
                net.WriteColor(gmodColor)
            ]]
            */
        }

        /// <summary>
        /// @CSharpLua.Template = "net.Send({0})"
        /// </summary>
        public void Send(Player player)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// @CSharpLua.Template = "net.Send({0})"
        /// </summary>
        public void Send(Player[] players)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// @CSharpLua.Template = "net.Broadcast()"
        /// </summary>
        public void Broadcast()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// CLIENTSIDE ONLY
        /// @CSharpLua.Template = "net.SendToServer()"
        /// </summary>
        public void SendToServer()
        {
            throw new NotImplementedException();
        }
        
    }
}