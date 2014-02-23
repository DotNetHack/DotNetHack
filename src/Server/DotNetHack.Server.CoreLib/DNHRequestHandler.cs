using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using DotNetHack.RPC;

namespace DotNetHack.Server.CoreLib
{
    /// <summary>
    /// DNHRequestHandler
    /// </summary>
    public class DNHRequestHandler : DNHService.Iface
    {
        public struct DNHServerParameters
        {
            public string WorkingDirectory;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Initialize(DNHServerParameters parameters)
        {
            lock (_syncRoot)
            {
                Debug.WriteLine("Creating request handler");

                GameState = new GameState();

                _initialized = true;
            }
        }

        #region backing store

        private readonly object _syncRoot = new object();
        private readonly string _currentWorkingDirectory = Directory.GetCurrentDirectory();
        private int _nextSessionId = 1;
        private bool _initialized;

        #endregion

        public GameState GameState { get; set; }

        /// <summary>
        /// BeginSession
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        public Session BeginSession(string userName, string passwordHash)
        {
            _nextSessionId++;

            // GameState.Players.Add(new Player());

            return new Session
            {
                PlayerId = 0,
                Id = _nextSessionId,
                Seq = DateTime.Now.Ticks,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public ActionResult Move(Session session, Direction direction)
        {
            return new ActionResult
            {
                GameState = GameState,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="spell"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public ActionResult Cast(Session session, Spell spell, TargetSelector target)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public ActionResult Quaff(Session session, TargetSelector target)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public ActionResult Wield(Session session, TargetSelector target)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public ActionResult Attack(Session session, TargetSelector target)
        {
            throw new NotImplementedException();
        }
    }
}
