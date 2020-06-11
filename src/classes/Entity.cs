using System;
using System.Numerics;

#pragma warning disable 0626

namespace Void.GLua {
    /// <summary>
    /// @CSharpLua.Ignore
    /// </summary>
    public class Entity
    {

        public bool IsPlayer()
        {
            throw new NotImplementedException();
        }

        public Player ToPlayer()
        {
            throw new NotImplementedException();
        }

        public int GetBoneCount()
        {
            throw new NotImplementedException();
        }

        public int EntIndex()
        {
            throw new NotImplementedException();
        }

        public string GetClass()
        {
            throw new NotImplementedException();
        }

        public string GetModel()
        {
            throw new NotImplementedException();
        }

        public void SetColor(Color color) 
        {
            throw new NotImplementedException();
        }

        public Color GetColor()
        {
            throw new NotImplementedException();
        }

        public Vector GetPos()
        {
            throw new NotImplementedException();
        }

        public bool IsOnFire()
        {
            throw new NotImplementedException();
        }

        public void Ignite() 
        {
            throw new NotImplementedException();
        }

        public void Extinguish()
        {
            throw new NotImplementedException();
        }

        public Vector SetPos(Vector pos)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// @CSharpLua.Ignore
    /// </summary>
    public static class Ents
    {
        public extern static Entity[] GetAll();

        /// <summary>
        /// @CSharpLua.Template = "ents.FindByClass({0})"
        /// </summary>
        public extern static Entity[] FindByClass(string str);

        /// <summary>
        /// @CSharpLua.Template = "Entity({0})"
        /// </summary>
        public extern static Entity GetByID(int id);
    }
}