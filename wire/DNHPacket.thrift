struct DNHPacket {
	1: i32 uid,
	2: string data,
}

service DNHService {
	void sendPacket(1: DNHPacket packet),
	DNHPacket retrievePacket(1: i32 uid)
}
