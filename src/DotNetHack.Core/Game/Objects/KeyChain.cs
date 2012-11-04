using DotNetHack.Core.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core.Game.Objects
{
    /// <summary>
    /// KeyChain
    /// <remarks>Stores all keys that the player has come across.</remarks>
    /// </summary>
    public class KeyChain
    {
        /// <summary>
        /// Creates a new instance of keychain.
        /// </summary>
        public KeyChain()
        {
            KeyStore = new List<IKey>();
            KeyStore.Add(new Key(Guid.Empty));
        }

        /// <summary>
        /// AddKey, adds a key to the key chain
        /// </summary>
        /// <param name="aKey"></param>
        public void AddKey(IKey aKey) { KeyStore.Add(aKey); }

        /// <summary>
        /// RemoveKey, removes a key from the key chain.
        /// </summary>
        /// <param name="aKey"></param>
        public void RemoveKey(IKey aKey) { KeyStore.Remove(aKey); }

        /// <summary>
        /// HasKey, determines if the key is contained in the key chain.
        /// </summary>
        /// <param name="aKey"></param>
        /// <returns></returns>
        public bool HasKey(IKey aKey)
        {
            return KeyStore.FirstOrDefault<IKey>(
                k => k.KeyGuid.Equals(aKey.KeyGuid)) != null;
        }

        /// <summary>
        /// HasKey, determines if the key is contained in the key chain.
        /// </summary>
        /// <param name="aKey"></param>
        /// <returns></returns>
        public bool HasKeyGuid(Guid aGuid)
        {
            return KeyStore.FirstOrDefault<IKey>(
                k => k.KeyGuid.Equals(aGuid)) != null;
        }

        /// <summary>
        /// <c>CanUnLock</c>, determines if this KeyChain <c>CanUnLock</c> whatever 
        /// <see cref="IHasLock"/> has been passed.
        /// </summary>
        /// <param name="aHasLock">Anything that has a lock.</param>
        /// <returns><value>true - if the *thing* that has a lock can be unlocked.</value></returns>
        public bool CanUnLock(IHasLock aHasLock) { return HasKeyGuid(aHasLock.KeyRef); }

        /// <summary>
        /// A keychain is a collection of Guids
        /// </summary>
        public List<IKey> KeyStore { get; set; }
    }
}
