using System.Threading.Tasks;

public class FakeWebService : IWebService {

	public int SleepDuration {get; set;}

	public FakeWebService() {
		SleepDuration = 2000;
	}

	private Task Sleep() {
		return Task.Delay (SleepDuration);
	}

	public async Task<User> Login(string username, string password) {
		await this.Sleep ();
		return new User { Id = "1", Username = username };
	}

	public async Task<User> Register(User user) {
		await this.Sleep ();
		return user;
	}

	public async Task<User[]> GetFriends(string userId) {
		await this.Sleep ();
		return new[] {
			new User { Id = "2", Username = "bobama" },
			new User { Id = "3", Username = "bobloblaw" },
			new User { Id = "4", Username = "gmichael" }
		};
	}

	public async Task<User> AddFriend(string userId, string username) {
		await this.Sleep ();
		return new User { Id = "5", Username = username };
	}

	public async Task<Conversation[]> GetConversations(string userId) {
		await this.Sleep ();
		return new[] {
			new Conversation { Id = "1", UserId = "2" },
			new Conversation { Id = "2", UserId = "3" },
			new Conversation { Id = "3", UserId = "4" }
		};
	}

	public async Task<Message[]> GetMessages(string conversationId) {
		await this.Sleep ();
		return new[] {
			new Message {
				Id = "1",
				ConversationId = conversationId,
				UserId = "2",
				Text = "Hey"
			},
			new Message {
				Id = "2",
				ConversationId = conversationId,
				UserId = "1",
				Text = "What's Up?"
			},
			new Message {
				Id = "3",
				ConversationId = conversationId,
				UserId = "2",
				Text = "Have you seen that new movie?"
			},
			new Message {
				Id = "4",
				ConversationId = conversationId,
				UserId = "1",
				Text = "It's great!"
			}
		};
	}

	public async Task<Message> SendMessage(Message message) {
		await Sleep ();
		return message;
	}
}
