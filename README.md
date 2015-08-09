# EA.Challenge.ChatApplication
EA Challenge chat application and self learning


# ChatAPI 
This is a console based Self Hosted Web API. The port number can be manipulated in the App.Config here: 

Port: https://github.com/banerjeesaikat6/EA.Challenge.ChatApplication/blob/master/EA.Test.ChatAPI/EA.Test.ChatAPI/App.config#L9

Address: https://github.com/banerjeesaikat6/EA.Challenge.ChatApplication/blob/master/EA.Test.ChatAPI/EA.Test.ChatAPI/App.config#L8

Get and Post Calls

GET - /api/user/GetUsers/{id} - All users except user with id
GET - /api/user/GetUserHeartBeat/{id} - Gets if the user is connected
GET - /api/Messages/GetMessage/fromId/{fromId}/toId/{toId} - Gets messages based on from and to userIds
POST - /api/Messages/SendMessage - Sends message to the Chat Server
POST - /api/User/Connect - Connect user
POST - /api/User/Disconnect - Disconnect user

# ChatClient - Windows application

This is a windows application, which talks to the Chat server with the help of the Chat API.

User connects to the system
A list of connected users is populated
User can select one chat buddy from the populated list
User can initiate chatting
User can disconnect

