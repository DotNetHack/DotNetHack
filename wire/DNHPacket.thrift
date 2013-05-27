
enum CommandType {
  MOVE = 1,
  USE = 2,
  ATTACK = 3
}

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

struct DNHObject {
	1: i32 ObjectID
}

struct DNHLocation {
	1: i32 X,
	2: i32 Y,
	3: i32 Z
}

struct DNHGameState {
	
}


/**
 * Description: This packet contains a user identifier and some raw data.
 */
struct DNHPacket {
	1: i32 ID,
	2: string Data
}

/**
 * Description: The response for authentication
 */
struct DNHAuthResponse {
	1: i32 ID,
	2: string Message
}

service DNHService {
	DNHAuthResponse Authenticate(1: string userName, 2: string passwordHash)
}
