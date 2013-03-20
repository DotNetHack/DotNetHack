struct DNHPacket {
	1: i32 uid,
	2: string data,
}

service DNHService {
	i32 authenticate(1: string userName, 2: string password),
	void sendPacket(1: DNHPacket packet),
	DNHPacket retrievePacket(1: i32 uid)
}
