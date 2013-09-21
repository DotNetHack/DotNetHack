/**
 *  bool        Boolean, one byte
 *  byte        Signed byte
 *  i16         Signed 16-bit integer
 *  i32         Signed 32-bit integer
 *  i64         Signed 64-bit integer
 *  double      64-bit floating point value
 *  string      String
 *  map<t1,t2>  Map from one type to another
 *  list<t1>    Ordered list of one type
 *  set<t1>     Set of unique elements of one type
 */

enum CommandType {
  MOVE = 1,
  USE = 2,
  ATTACK = 3
}

enum ObjectType {
	ITEM,
	ACTOR,
	PLAYER
}

struct DNHObject { 
	1: i32 id,
	2: ObjectType type
	3: i32 x,
	4: i32 y,
	5: i32 z
}

struct DNHGameState { 
	1: i64 seq,
	2: list<DNHObject> objects
}

struct DNHActionResult {
	1: i64 seq,
	2: bool success,
	3: DNHGameState gameState
	4: i32 playerID
}

struct DNHLocation {
	1: i32 X, 
	2: i32 Y,
	3: i32 Z
}

/**
 * Description: This packet contains a user identifier and some raw data.
 */
struct DNHPacket {
	1: i64 seq,
	2: string RawData
}

/**
 * Description: The core DNh service.
 */
service DNHService {
	DNHActionResult MoveTo(1: i32 playerId, i32 x, i32 y, i32 z),
	DNHActionResult Pickup(1: i32 playerId),
	DNHActionResult DropItem(1: i32 playerId, 2: i32 itemId),
	DNHActionResult Login(1: string name, 2: string hash),
	DNHActionResult Update(1: i32 playerId);
}

/**
 * Description: Service for pushing back information
 */
service DNHPushService {
	DNHActionResult Callback(1: DNHPacket packet);
}
