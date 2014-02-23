
struct Session {
	1: i32 id
	2: i64 seq,
	3: i32 playerId,
}

enum MessageType {
	Combat,
	Chat,
	Ambient,
}

struct Message {
	1: i64 sequence
	2: string text,
	3: MessageType messageType
}

// a sound is comprised of a file and volume
struct Sound {
	1: string soundFile,
	2: i32 attenuation
}

enum ItemType { 
	Armor,
	Weapon,
	Scroll,
	Tome,
	Potion,
	Currency,
	Key,
	Tool,
	Food,
	Other
}

enum EffectType {
		
}

enum StatusEffectType {
	Blinded,
	Bloodied,
	Dazed,
	Deafened,
	Dying,
	Immobilized,
	Prone,
	Resist,
	Restrained,
	Running,
	Shielded,
	Slowed,
	Stunned,
	Unconscious,
	Vulnerable,
	Concealed,
	Cursed,
	Hidden,
	Invisible,
	Weakened
}

struct Effect {
	1: i32 duration,
	2: EffectType type,
	3: string expression
}

struct Location {
	1: i32 x,
	2: i32 y,
	3: i32 z
}

struct Item {
	1: string name,
	2: Location location,
	3: ItemType type
}

struct ActionResult {
	1: Session session,
	2: optional string message,
	3: optional Sound sound
}

struct Player {
	1: i32 id,
	2: string name,
	3: Location location,
	4: i32 health,
	5: list<Effect> effects
	6: StatusEffectType status
}

// a non-player controlled character
struct NPC {
	1: string name,
	2: i32 health,
	3: Location location,
	4: list<Effect> effects
	5: StatusEffectType status
}

// the game state contains all players and npcs
struct GameState {
	1: list<Player> players,
	2: list<NPC> npcs,
	3: list<Sound> activeAmbient,
	4: list<Message> messages
}

// direction specifies 4 distinct directions.
enum Direction {
	Left,
	Right,
	Up,
	Down
}

// the various types of spells
enum SpellType {
	Alteration,
	Conjuration,
	Destruction,
	Illusion,
	Restoration,
}

// a spell; contains the name of the spell and the effect of the spell
struct Spell {
	1: string name,
	2: Effect effect,
	3: SpellType spellType
}

// The target type; this is used in a target selector
enum TargetType {
	TargetSelf,
	TargetLocation,
	TargetActor,
	TargetThing
}

// The target selector can be used to select nearly anything. Including
// self, a location, an item or an actor (player / NPC)
struct TargetSelector {
	1: TargetType selectorType,
	2: Location location,
	3: i32 objectId
}

service DNHService {
  
  // Function: beginSession
  // Description: starts a session given the userName and password on the server.
  // Param: userName - the name of the user
  // Param: passwordHash - the password hash of the user
  // Returns: returns the session that becomes active should beginSession succeed.
	Session beginSession(1: string userName, 2: string passwordHash)

  // Function: move
  // Description: moves the player on the server
	ActionResult move(1: Session session, 2: Direction direction)  

  // Function: cast
	// Description: casts the specified spell at the target; if the spell
  // lands the action results will contain the details.
	ActionResult cast(1: Session session, 2: Spell spell, 3: TargetSelector target)

  // Function: quaff
  // Description: Quaffs a potion for the player.
	ActionResult quaff(1: Session session, 2: TargetSelector target)

  // Function: wield
  // Wields a weapon for the player.
	ActionResult wield(1: Session session, 2: TargetSelector target)

	// Function: attack
	// Description:
	// The server retains what weapon the player is weilding; thus the client 
  // only needs to pass the target information. The server too will determine
  // if the hit lands, etc. 
	ActionResult attack(1: Session session, 2: TargetSelector target)
}

