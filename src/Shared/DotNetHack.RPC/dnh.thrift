namespace csharp DotNetHack.RPC

struct Session {
	1: i32 id
	2: i64 seq,
	3: i32 playerId,
	4: i64 startTime
}

enum MessageType {
	Combat,
	Chat,
	Ambient,
}

enum InjurySeverityScore { 
	Minor,
	Moderate,
	Serious,
	Severe,
	Critical,
	Maximal,
}

// There are nine AIS chapters corresponding to nine body regions:
// http://en.wikipedia.org/wiki/Injury_Severity_Score
enum BodyRegion {
	Head,
	Face,	// including the facial skeleton, nose, mouth, eyes and ears
	Neck,
	Thorax,
	Abdomen,
	Spine,
	UpperExtremity,
	LowerExtremity,
	Other,
}

// a damage descriptor defines one instance of damage and when the damage occured
struct DamageDescriptor {
	1: BodyRegion bodyRegion,
	2: InjurySeverityScore severity,
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

enum Race { 
	Human,
	Elf,
	Dwarf,
	Gnome,
	Orc
}

enum Role { 
	Archeologist,
	Barbarian,
	Healer,
	Knight,
	Monk,
	Priest,
	Ranger,
	Rogue,
	Samurai,
	Tourist,
	Valkyrie,
	Wizard
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

struct Player {
	1: i32 id,
	2: string name,
	3: Location location,
	4: list<Effect> effects
	5: StatusEffectType status
	6: Race race,
	7: Role role,
	8: list<DamageDescriptor> damage,
	9: list<Item> inventory
}

// types of non-player controlled characters
enum NPCType {
	Monster,
	Villager,
	Shopkeeper
}

// a non-player controlled character
struct NPC {
	1: string name,
	2: i32 health,
	3: Location location,
	4: list<Effect> effects,
	5: StatusEffectType status,
	6: NPCType npcType,
	7: list<Item> inventory
}

// the game state contains all players and npcs
struct GameState {
	1: list<Player> players,
	2: list<NPC> npcs,
	4: list<Message> broadcast
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

struct ActionResult {
	1: Session session,
	2: optional string message,
	3: optional Sound sound,
	4: set<Sound> activeAmbient,
	5: GameState gameState,
	6: Player player
}

exception DNHException {
  1: string message
}

// Thrift also lets you define constants for use across languages. Complex
// types and structs are specified using JSON notation.
//
// const i32 INT32CONSTANT = 9853
// const map<string,string> MAPCONSTANT = {'hello':'world', 'goodnight':'moon'}

const map<BodyRegion, BodyRegion> BODY_DEPENDENCIES =  { 
	BodyRegion.Head : BodyRegion.Spine, 
	BodyRegion.LowerExtremity : BodyRegion.Spine 
}

service DNHService {

  // Function: beginSession
  // Description: starts a session given the userName and password on the server.
  // Param: userName - the name of the user
  // Param: passwordHash - the password hash of the user
  // Returns: returns the session that becomes active should beginSession succeed.
	Session BeginSession(1: string userName, 2: string passwordHash)

  // Function: move
  // Description: moves the player on the server
	ActionResult Move(1: Session session, 2: Direction direction)  

  // Function: cast
	// Description: casts the specified spell at the target; if the spell
  // lands the action results will contain the details.
	ActionResult Cast(1: Session session, 2: Spell spell, 3: TargetSelector target)

  // Function: quaff
  // Description: Quaffs a potion for the player.
	ActionResult Quaff(1: Session session, 2: TargetSelector target)

  // Function: wield
  // Wields a weapon for the player.
	ActionResult Wield(1: Session session, 2: TargetSelector target)

	// Function: attack
	// Description:
	// The server retains what weapon the player is weilding; thus the client 
  // only needs to pass the target information. The server too will determine
  // if the hit lands, etc. 
	ActionResult Attack(1: Session session, 2: TargetSelector target)

	// Function: open
	// Description: 
	// Opens anything that is openable; doors, chests, etc.
	ActionResult Open(1: Session session, 2: TargetSelector target)

	// Function: close
	// Description: 
	// Closes anything that is openable; doors, chests, etc.
	ActionResult Close(1: Session session, 2: TargetSelector target)

	// Function: MySpells
	// Description: 
	// the server retains a list of spells known by the player; these are asked for
  // and updated.
	list<Spell> MySpells(1: Session session, 2: string expression)

	// Function: MyItems
	// Desciption:
	// returns a list of kept items.
	list<Item> MyItems(1: Session session, 2: string expression)
}

