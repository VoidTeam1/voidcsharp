using System;

namespace Void.GLua {
    /// <summary>
    /// @CSharpLua.Ignore
    /// </summary>
    public class Player : Entity {
        public string Nick() {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// @CSharpLua.Ignore
    /// </summary>
    public static class Players {
        public static Player[] GetAll() {
            throw new NotImplementedException();
        }
    }
}