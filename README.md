# EA.Challenge.ChatApplication
EA Challenge chat application and self learning


# ChatAPI 
This is a console based Self Hosted Web API. The port number can be manipulated in the App.Config here: <br />
Port: https://github.com/banerjeesaikat6/EA.Challenge.ChatApplication/blob/master/EA.Test.ChatAPI/EA.Test.ChatAPI/App.config#L9<br />
Address: https://github.com/banerjeesaikat6/EA.Challenge.ChatApplication/blob/master/EA.Test.ChatAPI/EA.Test.ChatAPI/App.config#L8

Get and Post Calls

GET - /api/user/GetUsers/{id} - All users except user with id<br />
GET - /api/user/GetUserHeartBeat/{id} - Gets if the user is connected<br />
GET - /api/Messages/GetMessage/fromId/{fromId}/toId/{toId} - Gets messages based on from and to userIds<br />
POST - /api/Messages/SendMessage - Sends message to the Chat Server<br />
POST - /api/User/Connect - Connect user<br />
POST - /api/User/Disconnect - Disconnect user<br />

# ChatClient - Windows application

This is a windows application, which talks to the Chat server with the help of the Chat API.

User connects to the system<br />
A list of connected users is populated<br />
User can select one chat buddy from the populated list<br />
User can initiate chatting<br />
User can disconnect<br />

