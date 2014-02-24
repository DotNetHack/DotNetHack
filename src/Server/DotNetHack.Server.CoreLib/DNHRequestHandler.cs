using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Security.AccessControl;
using DotNetHack.RPC;
using Thrift.Collections;

namespace DotNetHack.Server.CoreLib
{
    /// <summary>
    /// DNHRequestHandler
    /// </summary>
    public class DNHRequestHandler : DNHService.Iface
    {
        /// <summary>
        /// DNHServerParameters
        /// </summary>
        public struct DNHServerParameters
        {
            public string WorkingDirectory;
        }

        /// <summary>
        /// Initialize
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
        private int _nextSessionId = 1;
        private bool _initialized;
        private readonly Dictionary<int, Player> _players = new Dictionary<int, Player>();

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

            GameState.Players.Add(new Player
            {
                Id = 0,
                Name = userName,
                Location = new Location
                {
                    X = 0,
                    Y = 0,
                    Z = 0,
                },
                Effects = new List<Effect>
                {
                    new Effect
                    {
                        Type = new EffectType(),
                        Expression = "",
                        Duration = 0,
                    }
                },
                Status = StatusEffectType.Blinded,
                Damage = new List<DamageDescriptor>()
                {
                    new DamageDescriptor()
                    {
                        BodyRegion = BodyRegion.Face,
                        Severity = InjurySeverityScore.Minor,
                    },
                },
                Race = Race.Human,
                Role = Role.Archeologist,
            });

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
            Player player1;
            PlayerUpdate(session, delegate(Player player)
            {
                switch (direction)
                {
                    case Direction.Left:
                        player.Location.X--;
                        break;
                    case Direction.Right:
                        player.Location.X++;
                        break;
                    case Direction.Up:
                        player.Location.Y--;
                        break;
                    case Direction.Down:
                        player.Location.Y++;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("direction");
                }
            }, out player1);

            return new ActionResult
            {
                GameState = GameState,
                ActiveAmbient = new THashSet<Sound>(),
                Message = "",
                Session = session,
                Sound = new Sound
                {
                    SoundFile = "step.wav",
                    Attenuation = 100,
                },
                Player = player1
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
            Player player;
            PlayerUpdate(session, delegate(Player player1)
            {
                switch (target.SelectorType)
                {
                    case TargetType.TargetSelf:
                        switch (spell.SpellType)
                        {
                            case SpellType.Alteration:
                                break;
                            case SpellType.Conjuration:
                                break;
                            case SpellType.Destruction:
                                break;
                            case SpellType.Illusion:
                                break;
                            case SpellType.Restoration:
                                player1.Damage.Clear();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        break;
                    case TargetType.TargetLocation:
                        break;
                    case TargetType.TargetActor:
                        switch (spell.SpellType)
                        {
                            case SpellType.Alteration:
                                break;
                            case SpellType.Conjuration:
                                break;
                            case SpellType.Destruction:
                                break;
                            case SpellType.Illusion:
                                break;
                            case SpellType.Restoration:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        break;
                    case TargetType.TargetThing:
                        switch (spell.SpellType)
                        {
                            case SpellType.Alteration:
                                break;
                            case SpellType.Conjuration:
                                lock (GameState.Npcs)
                                {
                                    GameState.Npcs.Add(new NPC
                                    {
                                        Location = new Location
                                        {
                                            X = player1.Location.X + 1,
                                            Y = player1.Location.Y,
                                            Z = player1.Location.Z,
                                        },
                                        Name = player1.Name + "'s Monster",
                                        Effects = new List<Effect>
                                        {
                                            new Effect
                                            {
                                                Duration = 1,
                                                Type = new EffectType {},
                                                Expression = "",
                                            }
                                        },
                                        Status = StatusEffectType.Cursed,
                                        NpcType = NPCType.Monster,
                                        Health = 100,
                                    });
                                }
                                break;
                            case SpellType.Destruction:
                                break;
                            case SpellType.Illusion:
                                break;
                            case SpellType.Restoration:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }, out player);

            return new ActionResult
            {
                GameState = GameState,
                ActiveAmbient = new THashSet<Sound>(),
                Message = "",
                Sound = new Sound
                {
                    SoundFile = spell.Name + ".wav",
                    Attenuation = 100,
                },
                Session = session,
            };
        }

        private void PlayerUpdate(Session session, Action<Player> action, out Player player)
        {
            player = GameState.Players.Single(s => s.Id == session.PlayerId);

            lock (player)
            {
                action(player);
            }

            session.Seq = DateTime.Now.Ticks;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public ActionResult Quaff(Session session, TargetSelector target)
        {
            Player player;
            PlayerUpdate(session, delegate(Player player1)
            {
                // player1.Status = StatusEffectType.Invisible;
            }, out player);

            return new ActionResult
            {
                GameState = GameState,
                ActiveAmbient = new THashSet<Sound>(),
                Message = "",
                Sound = new Sound
                {
                    Attenuation = 100,
                    SoundFile = "quaff.wav"
                },
                Session = session
            };
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public ActionResult Open(Session session, TargetSelector target)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public ActionResult Close(Session session, TargetSelector target)
        {
            return new ActionResult
            {

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<Spell> MySpells(Session session, string expression)
        {
            return new List<Spell>()
            {
                new Spell()
                {
                    Name = "Frost Bolt",
                    Effect = new Effect()
                    {
                        Duration = 1,
                        Expression = "",
                        Type = new EffectType()
                        {

                        }
                    }
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<Item> MyItems(Session session, string expression)
        {
            return new List<Item>
            {
                new Item
                {
                    Name = "Axe",
                    Type = ItemType.Weapon,
                }
            };
        }
    }
}
